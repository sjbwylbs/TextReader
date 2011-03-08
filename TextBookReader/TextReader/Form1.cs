using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TextReader.Properties;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;

namespace TextReader
{
    public partial class TextReader : Form
    {
        private TRTextBox content;
        BookStore bs = new BookStore();
        TextBook tb;
        private string cacheDir;
        public TextReader()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开小说
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //打开对话框
            DialogResult dr=openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog1.FileName);

                tb = TextBook.NewTextBook(fi.FullName);
              
                //查找是否有缓存的章节目录
                if (File.Exists(CacheFile()))
                {
                    //如果存在则导入
                    ImportCatalog();
                }
                else
                {
                    //如果不存在则生成目录章节
                    GenCatalog();
                }

                //显示书名和作者
                this.Text = string.Format("文本小说阅读器 {0}-{1}", tb.BookName, tb.Author);
                foreach (ToolStripItem i in tsCategories.DropDownItems)
                {
                    //清除已有的列表
                    if (i.Name.Equals(this.toolStrip1.Name))
                        tsCategories.DropDownItems.Remove(i);
                }


                new Thread(new ThreadStart(ShowCatalog)).Start();
            }
        }

        private string CacheFile()
        {
            string cacheFile = Path.Combine(cacheDir, tb.FileName + ".~");
            return cacheFile;
        }

        private void GenCatalog()
        {
            Catalog catalog = new Catalog();
            catalog.FileName = CacheFile();
            NewCatalog(catalog);
            tb.Catalogs = catalog;
            BinaryFormatter bw = new BinaryFormatter();
            Stream sw = File.Create(catalog.FileName);
            bw.Serialize(sw, tb);
            sw.Close();
        }

        private void ImportCatalog(string cachefile)
        {
            Stream sr = File.OpenRead(cachefile);
            BinaryFormatter bf = new BinaryFormatter();
            tb = (TextBook)bf.Deserialize(sr);
            sr.Close();
        }

        private void ImportCatalog()
        {
            ImportCatalog(CacheFile());
        }

        private void ShowCatalog()
        {
            foreach (var item in tb.Catalogs.CatalogList)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(item.Value.Name);
                tsmi.Name = string.Format("catalog{0}", item.Key);
                tsmi.Click += new EventHandler(tsmi_Click);
                AddCatalog(tsmi);
            }
        }

        delegate void AddCatalogItem(ToolStripMenuItem tsmi);

        private void AddCatalog(ToolStripMenuItem tsmi)
        {
            if (this.InvokeRequired)
            {
                AddCatalogItem aci = new AddCatalogItem(AddCatalog);
                this.Invoke(aci, new object[] { tsmi });
            }
            else
            {
                tsCategories.DropDownItems.Add(tsmi);
            }
        }

        private void NewCatalog(Catalog catalog)
        {
            //以文本方式打开小说
            BufferedStream bs=new BufferedStream(File.OpenRead(tb.FullName));
            StreamReader sr = new StreamReader(bs,Encoding.Default);
            long position = 0;
            string buffer;
            Regex re = new Regex("书名:\\w{1,50}", RegexOptions.IgnorePatternWhitespace);

            while (string.IsNullOrEmpty(tb.BookName))
            {
                buffer = sr.ReadLine();
                tb.Lines++;
                if (!string.IsNullOrEmpty(buffer))
                {
                    position += buffer.Length;
                    Match m = re.Match(buffer);
                    if (m.Success)
                    {
                        tb.BookName = m.Value;
                        break;
                    }
                }
            }


            re = new Regex("作者:\\w{1,50}", RegexOptions.IgnorePatternWhitespace);

            while (string.IsNullOrEmpty(tb.Author))
            {
                buffer = sr.ReadLine();
                tb.Lines++;
                if (!string.IsNullOrEmpty(buffer))
                {
                    position += buffer.Length;
                    Match m = re.Match(buffer);
                    if (m.Success)
                    {
                        tb.Author = m.Value;
                        break;
                    }

                }
            }


            re = new Regex(@"第(一|二|三|四|五|六|七|八|九|十|零|百|千|万|\d){1,50}章.+\s", RegexOptions.IgnorePatternWhitespace);

            CatalogPuple cp = null;
            StringBuilder sb = new StringBuilder();
            while (!sr.EndOfStream)
            {
                buffer = sr.ReadLine();
                tb.Lines++;
                if (!string.IsNullOrEmpty(buffer))
                {
                    position += buffer.Length;
                
                    Match m=re.Match(buffer);
                    //判断章节
                    if (m.Success)
                    {
                        position += Environment.NewLine.Length;

                        if (cp != null)
                        {

                            //是章节保存内容
                            cp.Content = sb.ToString();
                            sb.Remove(0, sb.Length);
                        }

                        cp = new CatalogPuple();
                        cp.Position = position;
                        cp.Name = m.Value;
                        cp.Begin = tb.Lines;
                        if (catalog.Size > 1)
                        {
                            catalog.CatalogList[catalog.Size - 1].End = cp.Begin - 1;
                        }
                        catalog.CatalogList.Add(catalog.Size++, cp);
                    }
                    else
                    {
                        if (cp != null)
                        {
                            //不是章节则是内容
                            sb.AppendLine(buffer);
                        }
                    }
                }
                
            }
            sr.Close();
        }

        void tsmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            Regex re = new Regex("\\d+");
            Match m = re.Match(tsmi.Name);

            int position = int.Parse(m.Value);
            tb.CurrentCatalog = position;

            CatalogPuple puple = tb.Catalogs.CatalogList[tb.CurrentCatalog];

            this.pContent.Controls[0].Text = puple.Content;
        }

        
        private void TextReader_Load(object sender, EventArgs e)
        {
            Image bgimage=Image.FromFile(@"skins\black.gif");
            this.pContent.BackgroundImage = bgimage;
            this.pContent.BackgroundImageLayout = ImageLayout.Tile;
            cacheDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Settings.Default.CachePath);

            if (!Directory.Exists(cacheDir))
            {
                Directory.CreateDirectory(cacheDir);
            }

            
            string[] files = Directory.GetFiles(cacheDir, "*.txt.~");
            foreach(string s in files)
            {
                TextBook t = TextBook.NewTextBook(s);
                bs.Add(t);
                ToolStripMenuItem item = new ToolStripMenuItem(t.BookName);
                item.Click += new EventHandler(books_Click);
                this.tsBooks.DropDownItems.Add(item);
            }

            content = new TRTextBox();
            content.Name = "content";
            content.BackgroundImage = bgimage;
            content.BackgroundImageLayout = ImageLayout.Tile;
            content.Size = this.pContent.Size;
            content.ScrollBars = ScrollBars.Vertical;
            content.Multiline = true;
            content.Font = new Font("微软雅黑", 20);
            this.pContent.Controls.Add(content);
        }

        void books_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            tb = bs.Find(b => b.BookName.Equals(tsmi.Text));
            ImportCatalog();
        }

        private void clickToSeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenCatalog();
        }

        private void TextReader_Resize(object sender, EventArgs e)
        {
            Size s = this.ClientSize;
            s.Height -= 80;
            this.pContent.Size = s;

            this.button1.Location=new Point(this.button1.Location.X,s.Height + 5);
            this.button2.Location = new Point(this.button2.Location.X, s.Height + 5);


        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            
            Panel p = sender as Panel;
            if (p.HasChildren)
            {
                TRTextBox content = (TRTextBox)p.Controls["content"];
                content.Size = p.Size;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb.CurrentCatalog--;
            CatalogPuple puple = tb.Catalogs.CatalogList[tb.CurrentCatalog];

            this.pContent.Controls[0].Text = puple.Content;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tb.CurrentCatalog++;
            CatalogPuple puple = tb.Catalogs.CatalogList[tb.CurrentCatalog];

            this.pContent.Controls[0].Text = puple.Content;
        }

        private void 夜间模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TRTextBox content = (TRTextBox)this.pContent.Controls["content"];
            content.BackColor = Color.Black;
            content.ForeColor = Color.White;
        }

        private void 普通模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TRTextBox content = (TRTextBox)this.pContent.Controls["content"];
            content.BackColor = Color.White;
            content.ForeColor = Color.Black;
        }
    }
}
