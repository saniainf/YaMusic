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
            groupBox1 = new GroupBox();
            btnReloadAlbum = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            dataGridView2 = new DataGridView();
            groupBox2 = new GroupBox();
            tabArtist = new TabControl();
            textBox2 = new TextBox();
            label6 = new Label();
            btnLoadPlayList = new Button();
            tabPlayLists = new TabControl();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnReloadAlbum);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(dataGridView2);
            groupBox1.Location = new Point(402, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(583, 251);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Альбом";
            // 
            // btnReloadAlbum
            // 
            btnReloadAlbum.Location = new Point(442, 19);
            btnReloadAlbum.Name = "btnReloadAlbum";
            btnReloadAlbum.Size = new Size(34, 23);
            btnReloadAlbum.TabIndex = 6;
            btnReloadAlbum.Text = "button1";
            btnReloadAlbum.UseVisualStyleBackColor = true;
            btnReloadAlbum.Click += ReloadAlbum;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(373, 217);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 5;
            label4.Text = "Лейбл:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(373, 192);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 4;
            label3.Text = "Жанр:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(373, 167);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 3;
            label2.Text = "Год выхода:";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(531, 23);
            label1.TabIndex = 2;
            label1.Text = "Большое длинное название";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(368, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(108, 94);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(6, 50);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(356, 185);
            dataGridView2.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tabArtist);
            groupBox2.Location = new Point(402, 303);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(583, 341);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Исполнитель";
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
            ClientSize = new Size(997, 656);
            Controls.Add(tabPlayLists);
            Controls.Add(btnLoadPlayList);
            Controls.Add(label6);
            Controls.Add(textBox2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormMain";
            Text = "YaPlayList";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private DataGridView dataGridView2;
        private GroupBox groupBox2;
        private Label label4;
        private Button btnReloadAlbum;
        private TextBox textBox2;
        private Label label6;
        private Button btnLoadPlayList;
        private TabControl tabArtist;
        private TabControl tabPlayLists;
    }
}