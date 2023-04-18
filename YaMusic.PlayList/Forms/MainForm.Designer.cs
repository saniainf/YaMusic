namespace YaMusic.PlayListView.Forms
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            gbxAlbum = new GroupBox();
            tabAlbum = new TabControl();
            gbxArtist = new GroupBox();
            tabArtist = new TabControl();
            tabPlayLists = new TabControl();
            statusStrip = new StatusStrip();
            tableLayoutPanel1 = new TableLayoutPanel();
            gbxPlayList = new GroupBox();
            toolStrip = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tbxSearch = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            btnLoadPlayList = new ToolStripButton();
            btnLoadAlbum = new ToolStripButton();
            btnLoadArtist = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            gbxAlbum.SuspendLayout();
            gbxArtist.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gbxPlayList.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // gbxAlbum
            // 
            gbxAlbum.Controls.Add(tabAlbum);
            gbxAlbum.Dock = DockStyle.Fill;
            gbxAlbum.Location = new Point(445, 310);
            gbxAlbum.Name = "gbxAlbum";
            gbxAlbum.Size = new Size(436, 301);
            gbxAlbum.TabIndex = 1;
            gbxAlbum.TabStop = false;
            gbxAlbum.Text = "Альбомы";
            // 
            // tabAlbum
            // 
            tabAlbum.Dock = DockStyle.Fill;
            tabAlbum.Location = new Point(3, 19);
            tabAlbum.Name = "tabAlbum";
            tabAlbum.SelectedIndex = 0;
            tabAlbum.Size = new Size(430, 279);
            tabAlbum.TabIndex = 6;
            // 
            // gbxArtist
            // 
            gbxArtist.Controls.Add(tabArtist);
            gbxArtist.Dock = DockStyle.Fill;
            gbxArtist.Location = new Point(445, 3);
            gbxArtist.Name = "gbxArtist";
            gbxArtist.Size = new Size(436, 301);
            gbxArtist.TabIndex = 2;
            gbxArtist.TabStop = false;
            gbxArtist.Text = "Исполнители";
            // 
            // tabArtist
            // 
            tabArtist.Dock = DockStyle.Fill;
            tabArtist.Location = new Point(3, 19);
            tabArtist.Name = "tabArtist";
            tabArtist.SelectedIndex = 0;
            tabArtist.Size = new Size(430, 279);
            tabArtist.TabIndex = 9;
            // 
            // tabPlayLists
            // 
            tabPlayLists.Dock = DockStyle.Fill;
            tabPlayLists.Location = new Point(3, 19);
            tabPlayLists.Name = "tabPlayLists";
            tabPlayLists.SelectedIndex = 0;
            tabPlayLists.Size = new Size(430, 586);
            tabPlayLists.TabIndex = 9;
            // 
            // statusStrip
            // 
            statusStrip.Location = new Point(0, 639);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(884, 22);
            statusStrip.TabIndex = 10;
            statusStrip.Text = "statusStrip1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(gbxAlbum, 1, 1);
            tableLayoutPanel1.Controls.Add(gbxArtist, 1, 0);
            tableLayoutPanel1.Controls.Add(gbxPlayList, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 25);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(884, 614);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // gbxPlayList
            // 
            gbxPlayList.Controls.Add(tabPlayLists);
            gbxPlayList.Dock = DockStyle.Fill;
            gbxPlayList.Location = new Point(3, 3);
            gbxPlayList.Name = "gbxPlayList";
            tableLayoutPanel1.SetRowSpan(gbxPlayList, 2);
            gbxPlayList.Size = new Size(436, 608);
            gbxPlayList.TabIndex = 3;
            gbxPlayList.TabStop = false;
            gbxPlayList.Text = "Плейлисты";
            // 
            // toolStrip
            // 
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tbxSearch, toolStripSeparator1, btnLoadPlayList, btnLoadAlbum, btnLoadArtist, toolStripSeparator2 });
            toolStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new Padding(3, 0, 3, 0);
            toolStrip.Size = new Size(884, 25);
            toolStrip.TabIndex = 12;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(45, 22);
            toolStripLabel1.Text = "Поиск:";
            // 
            // tbxSearch
            // 
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(340, 25);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // btnLoadPlayList
            // 
            btnLoadPlayList.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnLoadPlayList.Image = (Image)resources.GetObject("btnLoadPlayList.Image");
            btnLoadPlayList.ImageTransparentColor = Color.Magenta;
            btnLoadPlayList.Name = "btnLoadPlayList";
            btnLoadPlayList.Size = new Size(113, 22);
            btnLoadPlayList.Text = "Выбрать плейлист";
            btnLoadPlayList.Click += btnLoadPlayList_Click;
            // 
            // btnLoadAlbum
            // 
            btnLoadAlbum.Alignment = ToolStripItemAlignment.Right;
            btnLoadAlbum.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnLoadAlbum.Image = (Image)resources.GetObject("btnLoadAlbum.Image");
            btnLoadAlbum.ImageTransparentColor = Color.Magenta;
            btnLoadAlbum.Name = "btnLoadAlbum";
            btnLoadAlbum.Size = new Size(110, 22);
            btnLoadAlbum.Text = "Обновить альбом";
            btnLoadAlbum.Click += btnLoadAlbum_ClickAsync;
            // 
            // btnLoadArtist
            // 
            btnLoadArtist.Alignment = ToolStripItemAlignment.Right;
            btnLoadArtist.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnLoadArtist.Image = (Image)resources.GetObject("btnLoadArtist.Image");
            btnLoadArtist.ImageTransparentColor = Color.Magenta;
            btnLoadArtist.Name = "btnLoadArtist";
            btnLoadArtist.Size = new Size(140, 22);
            btnLoadArtist.Text = "Обновить исполнителя";
            btnLoadArtist.Click += btnLoadArtist_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 661);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            MinimumSize = new Size(900, 700);
            Name = "FormMain";
            Text = "YaPlayList";
            gbxAlbum.ResumeLayout(false);
            gbxArtist.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            gbxPlayList.ResumeLayout(false);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gbxAlbum;
        private GroupBox gbxArtist;
        private TabControl tabArtist;
        private TabControl tabPlayLists;
        private TabControl tabAlbum;
        private StatusStrip statusStrip;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox gbxPlayList;
        private ToolStrip toolStrip;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbxSearch;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnLoadPlayList;
        private ToolStripButton btnLoadArtist;
        private ToolStripButton btnLoadAlbum;
        private ToolStripSeparator toolStripSeparator2;
    }
}