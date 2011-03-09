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
        private void tsOpen_Click(object sender, EventArgs e)
        {
            //打开对话框
            DialogResult dr=openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog1.FileName);

                tb = TextBook.NewTextBook(fi.FullName, cacheDir);
              
                //查找是否有缓存的章节目录
                if (File.Exists(tb.CatalogsFileName))
                {
                    //如果存在则导入
                    tb=TextBook.Restore(tb.CatalogsFileName);
                }
                else
                {
                    //如果不存在则生成目录章节
                    TextBook.NewCatalog(ref tb);
                    TextBook.Save(tb);
                }

                //显示书名和作者
                this.Text = string.Format("文本小说阅读器 {0}-{1}", tb.BookName, tb.Author);
                

                bs.Add(tb);
                ToolStripMenuItem item = new ToolStripMenuItem(tb.BookName);
                item.Click += new EventHandler(books_Click);
                this.tsBooks.DropDownItems.Add(item);

                GenCategoriesMenu();
            }
        }

        private void GenCategoriesMenu()
        {
            tsCategories.DropDownItems.Clear();
            //生成章节目录列表
            new Thread(new ThreadStart(ShowCatalog)).Start();
        }


        private void ShowCatalog()
        {
            foreach (var item in tb.Catalogs.CatalogList)
            {
                ToolStripMenuItem tsmiCatalogItem = new ToolStripMenuItem(item.Value.Name);
                tsmiCatalogItem.Name = string.Format("catalog{0}", item.Key);
                tsmiCatalogItem.Click += new EventHandler(tsmiCatalogItem_Click);
                AddCatalog(tsmiCatalogItem);
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



        void tsmiCatalogItem_Click(object sender, EventArgs e)
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

            
            string[] cacheFiles = Directory.GetFiles(cacheDir, "*.txt.~");
            foreach(string cacheFile in cacheFiles)
            {
                TextBook t=TextBook.Restore(cacheFile);
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
            GenCategoriesMenu();
            //tb=TextBook.Restore(tb.CatalogsFileName);
        }

        private void clickToSeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("还没有做这个功能哦");
        }

        private void TextReader_Resize(object sender, EventArgs e)
        {
            Size s = this.ClientSize;
            s.Height -= 80;
            this.pContent.Size = s;

            this.btnPrevCatalog.Location=new Point(this.btnPrevCatalog.Location.X,s.Height + 5);
            this.btnNextCatalog.Location = new Point(this.btnNextCatalog.Location.X, s.Height + 5);


        }

        private void pContent_Resize(object sender, EventArgs e)
        {
            
            Panel p = sender as Panel;
            if (p.HasChildren)
            {
                TRTextBox content = (TRTextBox)p.Controls["content"];
                content.Size = p.Size;
            }
        }

        private void btnPrevCatalog_Click(object sender, EventArgs e)
        {
            if (tb.CurrentCatalog > 0)
            {
                tb.CurrentCatalog--;
                CatalogPuple puple = tb.Catalogs.CatalogList[tb.CurrentCatalog];
                this.pContent.Controls[0].Text = puple.Content;
            }
        }

        private void btnNextCatalog_Click(object sender, EventArgs e)
        {
            if (tb.CurrentCatalog + 1 < tb.Catalogs.Size)
            {
                tb.CurrentCatalog++;
                CatalogPuple puple = tb.Catalogs.CatalogList[tb.CurrentCatalog];
                this.pContent.Controls[0].Text = puple.Content;
            }
        }

        private void tsmiNightStyle_Click(object sender, EventArgs e)
        {
            TRTextBox content = (TRTextBox)this.pContent.Controls["content"];
            content.BackColor = Color.Black;
            content.ForeColor = Color.White;
        }

        private void tsmiNormal_Click(object sender, EventArgs e)
        {
            TRTextBox content = (TRTextBox)this.pContent.Controls["content"];
            content.BackColor = Color.White;
            content.ForeColor = Color.Black;
        }
    }
}
