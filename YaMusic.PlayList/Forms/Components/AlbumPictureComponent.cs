namespace YaMusic.PlayListView.Forms.Components
{
    internal class AlbumPictureComponent : PictureBox
    {
        public AlbumPictureComponent() : base()
        {
            Size = new Size(100, 100);
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            BackColor = Color.Silver;
        }
    }
}
