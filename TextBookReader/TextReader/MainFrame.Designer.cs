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
            this.pControl = new System.Windows.Forms.Panel();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextCatalog = new System.Windows.Forms.Button();
            this.btnPrevCatalog = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lbContent = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsFile = new System.Windows.Forms.ToolStripButton();
            this.tsCategories = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBooks = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsSkins = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiNightStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNomalStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.pControl.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pControl);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelContent);
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripContainer1_ContentPanel_MouseMove);
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // pControl
            // 
            this.pControl.Controls.Add(this.btnNextPage);
            this.pControl.Controls.Add(this.btnPrevPage);
            this.pControl.Controls.Add(this.btnNextCatalog);
            this.pControl.Controls.Add(this.btnPrevCatalog);
            resources.ApplyResources(this.pControl, "pControl");
            this.pControl.Name = "pControl";
            // 
            // btnNextPage
            // 
            resources.ApplyResources(this.btnNextPage, "btnNextPage");
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.UseVisualStyleBackColor = true;
            // 
            // btnPrevPage
            // 
            resources.ApplyResources(this.btnPrevPage, "btnPrevPage");
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            // 
            // btnNextCatalog
            // 
            resources.ApplyResources(this.btnNextCatalog, "btnNextCatalog");
            this.btnNextCatalog.Name = "btnNextCatalog";
            this.btnNextCatalog.UseVisualStyleBackColor = true;
            this.btnNextCatalog.Click += new System.EventHandler(this.btnNextCatalog_Click);
            // 
            // btnPrevCatalog
            // 
            resources.ApplyResources(this.btnPrevCatalog, "btnPrevCatalog");
            this.btnPrevCatalog.Name = "btnPrevCatalog";
            this.btnPrevCatalog.UseVisualStyleBackColor = true;
            this.btnPrevCatalog.Click += new System.EventHandler(this.btnPrevCatalog_Click);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.lbContent);
            resources.ApplyResources(this.panelContent, "panelContent");
            this.panelContent.Name = "panelContent";
            // 
            // lbContent
            // 
            resources.ApplyResources(this.lbContent, "lbContent");
            this.lbContent.Name = "lbContent";
            this.lbContent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbContent_MouseMove);
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
            this.tsFile.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // tsCategories
            // 
            this.tsCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsCategories, "tsCategories");
            this.tsCategories.Name = "tsCategories";
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
            this.tsmiNightStyle,
            this.tsmiNomalStyle});
            resources.ApplyResources(this.tsSkins, "tsSkins");
            this.tsSkins.Name = "tsSkins";
            // 
            // tsmiNightStyle
            // 
            this.tsmiNightStyle.Name = "tsmiNightStyle";
            resources.ApplyResources(this.tsmiNightStyle, "tsmiNightStyle");
            this.tsmiNightStyle.Text = global::TextReader.Properties.Settings.Default.NightStyle;
            this.tsmiNightStyle.Click += new System.EventHandler(this.tsmiNightStyle_Click);
            // 
            // tsmiNomalStyle
            // 
            this.tsmiNomalStyle.Name = "tsmiNomalStyle";
            resources.ApplyResources(this.tsmiNomalStyle, "tsmiNomalStyle");
            this.tsmiNomalStyle.Text = global::TextReader.Properties.Settings.Default.NomalStyle;
            this.tsmiNomalStyle.Click += new System.EventHandler(this.tsmiNormal_Click);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextReader_FormClosing);
            this.Load += new System.EventHandler(this.TextReader_Load);
            this.Resize += new System.EventHandler(this.TextReader_Resize);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.pControl.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem tsmiNightStyle;
        private System.Windows.Forms.ToolStripMenuItem tsmiNomalStyle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripDropDownButton tsBooks;
        private System.Windows.Forms.Panel pControl;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextCatalog;
        private System.Windows.Forms.Button btnPrevCatalog;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TextBox lbContent;
    }
}

