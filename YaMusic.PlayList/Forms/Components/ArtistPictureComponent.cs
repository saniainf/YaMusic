namespace YaMusic.PlayListView.Forms.Components
{
    internal class ArtistPictureComponent : PictureBox
    {
        public ArtistPictureComponent() : base()
        {
            Size = new Size(100, 100);
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            BackColor = Color.Silver;
        }
    }
}