using Microsoft.EntityFrameworkCore;
using System;
using YaMusic.PlayListView.Controllers;
using YaMusic.PlayListView.Domain;
using YaMusic.PlayListView.Forms.Components;
using YaMusic.PlayListView.Models;
using YaMusic.PlayListView.Repositories;

namespace YaMusic.PlayListView.Forms
{
    internal partial class FormMain : Form
    {
        private readonly PlayListController _controller;

        public FormMain(PlayListController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private async void _playListControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender is PlayListTrackListComponent playList)
            {
                if (playList.SelectedItems != null && playList.SelectedItems.Count > 0)
                {
                    var trackId = (int)playList.SelectedItems[0].Tag;
                    var artistsTabs = await _controller.GetArtistsTabAsync(trackId);
                    tabArtist.Controls.Clear();
                    tabArtist.Controls.AddRange(artistsTabs.ToArray());
                    //var artistsTab = _controller.GetArtistsTabAsync(trackId);


                    //foreach (var tab in artistsTab)
                    //{
                    //    tabArtist.Controls.Add(tab);
                    //}

                    //var trackInfo = await _playListRepo.GetTrack(trackId);
                    //var artist = trackInfo.Artists.FirstOrDefault()!;

                    //using AppDbContext dbContext = new();
                    //var query = dbContext.Tracks
                    //    .Include(t => t.Albums)
                    //    .Where(t => t.Artists.Any(a => a.Id == artist.Id))
                    //    .SelectMany(t => t.Albums)
                    //    .Distinct();

                    //var artistViewModel = query.ToList();

                    //listView1.Items.Clear();
                    //int i = 1;
                    //foreach (var album in artistViewModel)
                    //{
                    //    ListViewItem item = new(new string[] { i++.ToString(), album.Title, album.Year.ToString(), album.Genre });
                    //    item.Tag = album.Id;
                    //    listView1.Items.Add(item);
                    //}

                    textBox2.Text = trackId.ToString();
                }
            }
        }

        private void ReloadAlbum(object sender, EventArgs e)
        {

        }

        private async void btnLoadPlayList_Click(object sender, EventArgs e)
        {
            var playListTab = await _controller.GetPlayListTabAsync(1);
            playListTab.TrackList.SelectedIndexChanged += _playListControl_SelectedIndexChanged;
            tabPlayLists.Controls.Add(playListTab);
        }
    }
}