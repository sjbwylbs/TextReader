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
        delegate void AddCatalogItem(ToolStripMenuItem tsmi);
        private Thread redrawMenu;

        private static string APPLICATION_CAPTION = "{0}{1}{2}文本小说阅读器 By sjbwylbs Email:sjbwylbs@163.com";
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
                this.Text = string.Format(APPLICATION_CAPTION, tb.Author,"-"+tb.BookName,"        ");
                

                bs.Add(tb);
                ToolStripMenuItem item = new ToolStripMenuItem(tb.BookName);
                item.Click += new EventHandler(Books_Click);
                this.tsBooks.DropDownItems.Add(item);

                GenCategoriesMenu();
            }
        }

        private void GenCategoriesMenu()
        {
            if (redrawMenu!=null && redrawMenu.IsAlive)
            {
                redrawMenu.Abort("用户重复调用重画章节菜单");
            }
          
            tsCategories.DropDownItems.Clear();
            //生成章节目录列表
            redrawMenu=new Thread(new ThreadStart(ShowCatalog));
            redrawMenu.Start();

        }


        private void ShowCatalog()
        {
            for (int i = 0; i < tb.Catalogs.Count; i++)
            {
                CatalogPuple cp = tb.Catalogs[i];
                ToolStripMenuItem tsmiCatalogItem = new ToolStripMenuItem(cp.Name);
                tsmiCatalogItem.Name = string.Format("catalogs{0}",i);
                tsmiCatalogItem.Click += new EventHandler(tsmiCatalogItem_Click);
                AddCatalog(tsmiCatalogItem);
            }
        }


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

            CatalogPuple puple = tb.Catalogs[tb.CurrentCatalog];

            this.panelContent.Controls[0].Text = puple.Content;
            this.Text = string.Format(APPLICATION_CAPTION, this.tb.Author, "-"+this.tb.BookName,"~"+puple.Name+"        ");
        }

        
        private void TextReader_Load(object sender, EventArgs e)
        {
            this.Text = this.Text = string.Format(APPLICATION_CAPTION,"","","");
            Image bgimage=Image.FromFile(@"skins\black.gif");
            this.panelContent.BackgroundImage = bgimage;
            this.panelContent.BackgroundImageLayout = ImageLayout.Tile;
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
                item.Click += new EventHandler(Books_Click);
                this.tsBooks.DropDownItems.Add(item);
            }

            lbContent.BackgroundImage = bgimage;
            lbContent.BackgroundImageLayout = ImageLayout.Tile;
            //panelContent.Size = this.panelContent.Size;
            lbContent.ScrollBars = ScrollBars.Vertical;
            lbContent.Multiline = true;
            //lbContent.Enabled = false;
            lbContent.Font = new Font("微软雅黑", 20);
           

            //this.panelContent.Controls.Add(content);
            this.panelContent.Location = new Point(0, 0);
            this.lbContent.Location = this.lbContent.Parent.Location;
            this.panelContent.Size = this.ClientSize;
            this.pControl.Visible = false;
            ResetControl();
        }

        private void ResetControl()
        {

            Size s = this.ClientSize;
            this.panelContent.Size = s;
            this.lbContent.Size = s;

            //设置控制器的位置
            int x = (s.Width-this.pControl.Width)/2;
            int y = s.Height-this.pControl.Height;

            this.pControl.Location = new Point(x,y);
        }

        void Books_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            tb = bs.Find(b => b.BookName.Equals(tsmi.Text));
            GenCategoriesMenu();
            this.Text = string.Format(APPLICATION_CAPTION, this.tb.Author, "-"+this.tb.BookName, "        ");
            this.panelContent.ResetText();
            
        }

        private void TextReader_Resize(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void btnPrevCatalog_Click(object sender, EventArgs e)
        {
            if (tb.CurrentCatalog > 0)
            {
                tb.CurrentCatalog--;
                CatalogPuple puple = tb.Catalogs[tb.CurrentCatalog];
                this.panelContent.Controls[0].Text = puple.Content;

                this.Text = string.Format(APPLICATION_CAPTION, this.tb.Author, "-" + this.tb.BookName, "~" + puple.Name + "        ");

            }
        }

        private void btnNextCatalog_Click(object sender, EventArgs e)
        {
            if (tb.CurrentCatalog + 1 < tb.Catalogs.Count)
            {
                tb.CurrentCatalog++;
                CatalogPuple puple = tb.Catalogs[tb.CurrentCatalog];
                this.panelContent.Controls[0].Text = puple.Content;

                this.Text = string.Format(APPLICATION_CAPTION, this.tb.Author, "-" + this.tb.BookName, "~" + puple.Name + "        ");

            }
        }

        private void tsmiNightStyle_Click(object sender, EventArgs e)
        {
            lbContent.BackColor = Color.Black;
            lbContent.ForeColor = Color.White;
        
        }

        private void tsmiNormal_Click(object sender, EventArgs e)
        {
            lbContent.BackColor = Color.White;
            lbContent.ForeColor = Color.Black;
        
        }

        private void TextReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (redrawMenu != null && redrawMenu.IsAlive)
            {
                redrawMenu.Abort("用户强制关闭窗口");
            }
        }

        private void toolStripContainer1_ContentPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y > this.Height - pControl.Height && e.X > 0)
            {
                pControl.Visible = true;
            }
            else
            {
                pControl.Visible = false;
            }
      
        }

        private void lbContent_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y > this.Height - pControl.Height && e.X > 0)
            {
                pControl.Visible = true;
            }
            else
            {
                pControl.Visible = false;
            }
      

        }
    }
}
