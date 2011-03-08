namespace TextReader
{
    partial class TextReader
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextReader));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.pContent = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsFile = new System.Windows.Forms.ToolStripButton();
            this.tsCategories = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiListCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBooks = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsSkins = new System.Windows.Forms.ToolStripDropDownButton();
            this.夜间模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.普通模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pContent);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.listView1);
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // pContent
            // 
            resources.ApplyResources(this.pContent, "pContent");
            this.pContent.Name = "pContent";
            this.pContent.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.BackgroundImageTiled = true;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFile,
            this.tsCategories,
            this.tsBooks,
            this.tsSkins});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsFile
            // 
            this.tsFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsFile, "tsFile");
            this.tsFile.Name = "tsFile";
            this.tsFile.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsCategories
            // 
            this.tsCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsCategories.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiListCategories});
            resources.ApplyResources(this.tsCategories, "tsCategories");
            this.tsCategories.Name = "tsCategories";
            // 
            // tsmiListCategories
            // 
            this.tsmiListCategories.Name = "tsmiListCategories";
            resources.ApplyResources(this.tsmiListCategories, "tsmiListCategories");
            this.tsmiListCategories.Click += new System.EventHandler(this.clickToSeeToolStripMenuItem_Click);
            // 
            // tsBooks
            // 
            this.tsBooks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsBooks, "tsBooks");
            this.tsBooks.Name = "tsBooks";
            // 
            // tsSkins
            // 
            this.tsSkins.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsSkins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.夜间模式ToolStripMenuItem,
            this.普通模式ToolStripMenuItem});
            resources.ApplyResources(this.tsSkins, "tsSkins");
            this.tsSkins.Name = "tsSkins";
            // 
            // 夜间模式ToolStripMenuItem
            // 
            this.夜间模式ToolStripMenuItem.Name = "夜间模式ToolStripMenuItem";
            resources.ApplyResources(this.夜间模式ToolStripMenuItem, "夜间模式ToolStripMenuItem");
            this.夜间模式ToolStripMenuItem.Click += new System.EventHandler(this.夜间模式ToolStripMenuItem_Click);
            // 
            // 普通模式ToolStripMenuItem
            // 
            this.普通模式ToolStripMenuItem.Name = "普通模式ToolStripMenuItem";
            resources.ApplyResources(this.普通模式ToolStripMenuItem, "普通模式ToolStripMenuItem");
            this.普通模式ToolStripMenuItem.Click += new System.EventHandler(this.普通模式ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TextReader
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "TextReader";
            this.Load += new System.EventHandler(this.TextReader_Load);
            this.Resize += new System.EventHandler(this.TextReader_Resize);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsFile;
        private System.Windows.Forms.ToolStripDropDownButton tsCategories;
        private System.Windows.Forms.ToolStripDropDownButton tsSkins;
        private System.Windows.Forms.ToolStripMenuItem 夜间模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 普通模式ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem tsmiListCategories;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pContent;
        private System.Windows.Forms.ToolStripDropDownButton tsBooks;
    }
}

