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
            gbxAlbum = new GroupBox();
            tabAlbum = new TabControl();
            gbxArtist = new GroupBox();
            tabArtist = new TabControl();
            textBox2 = new TextBox();
            label6 = new Label();
            btnLoadPlayList = new Button();
            tabPlayLists = new TabControl();
            gbxAlbum.SuspendLayout();
            gbxArtist.SuspendLayout();
            SuspendLayout();
            // 
            // gbxAlbum
            // 
            gbxAlbum.Controls.Add(tabAlbum);
            gbxAlbum.Location = new Point(402, 393);
            gbxAlbum.Name = "gbxAlbum";
            gbxAlbum.Size = new Size(583, 251);
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
            tabAlbum.Size = new Size(577, 229);
            tabAlbum.TabIndex = 6;
            // 
            // gbxArtist
            // 
            gbxArtist.Controls.Add(tabArtist);
            gbxArtist.Location = new Point(402, 46);
            gbxArtist.Name = "gbxArtist";
            gbxArtist.Size = new Size(583, 341);
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
            tabArtist.Size = new Size(577, 319);
            tabArtist.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(720, 14);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(265, 23);
            textBox2.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(669, 17);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 4;
            label6.Text = "Поиск:";
            // 
            // btnLoadPlayList
            // 
            btnLoadPlayList.Location = new Point(402, 9);
            btnLoadPlayList.Name = "btnLoadPlayList";
            btnLoadPlayList.Size = new Size(137, 23);
            btnLoadPlayList.TabIndex = 8;
            btnLoadPlayList.Text = "Выбрать плейлист";
            btnLoadPlayList.UseVisualStyleBackColor = true;
            btnLoadPlayList.Click += btnLoadPlayList_Click;
            // 
            // tabPlayLists
            // 
            tabPlayLists.Location = new Point(12, 9);
            tabPlayLists.Name = "tabPlayLists";
            tabPlayLists.SelectedIndex = 0;
            tabPlayLists.Size = new Size(384, 635);
            tabPlayLists.TabIndex = 9;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 656);
            Controls.Add(tabPlayLists);
            Controls.Add(btnLoadPlayList);
            Controls.Add(label6);
            Controls.Add(textBox2);
            Controls.Add(gbxAlbum);
            Controls.Add(gbxArtist);
            Name = "FormMain";
            Text = "YaPlayList";
            gbxAlbum.ResumeLayout(false);
            gbxArtist.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gbxAlbum;
        private GroupBox gbxArtist;
        private TextBox textBox2;
        private Label label6;
        private Button btnLoadPlayList;
        private TabControl tabArtist;
        private TabControl tabPlayLists;
        private TabControl tabAlbum;
    }
}