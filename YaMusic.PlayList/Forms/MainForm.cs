using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Text.Json;
using YaMusic.PlayListView.Controllers;
using YaMusic.PlayListView.Domain;
using YaMusic.PlayListView.Forms.Components;
using YaMusic.PlayListView.Models;
using YaMusic.PlayListView.Repositories;
using YaMusic.PlayListView.Services.Models;

namespace YaMusic.PlayListView.Forms
{
    internal partial class FormMain : Form
    {
        private readonly MainController _controller;

        public FormMain(MainController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private async void btnLoadPlayList_Click(object sender, EventArgs e)
        {
            var playListTab = await _controller.GetPlayListTabAsync(1);
            playListTab.TrackList.SelectedIndexChanged += PlayListTrackList_SelectedIndexChanged;
            tabPlayLists.Controls.Add(playListTab);
        }

        private void PlayListTrackList_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender is PlayListTrackListComponent playList)
            {
                if (playList.SelectedItems != null && playList.SelectedItems.Count > 0)
                {
                    var trackId = (int)playList.SelectedItems[0].Tag;
                    LoadArtistTabsByTrack(trackId);
                    LoadAlbumTabsByTrack(trackId);
                }
            }
        }

        private async void LoadArtistTabsByTrack(int trackId)
        {
            var artistsTabs = await _controller.GetArtistsTabAsync(trackId);
            tabArtist.Controls.Clear();
            foreach (var tab in artistsTabs)
            {
                tabArtist.Controls.Add(tab);
            }
        }

        private async void LoadAlbumTabsByTrack(int trackId)
        {
            var albumTabs = await _controller.GetAlbumsTabAsync(trackId);
            tabAlbum.Controls.Clear();
            foreach (var tab in albumTabs)
            {
                tabAlbum.Controls.Add(tab);
            }
        }

        private async void btnLoadAlbum_Click(object sender, EventArgs e)
        {
            if (tabAlbum.TabPages.Count == 0) return;
            var selectedTab = tabAlbum.SelectedTab;
            var id = int.TryParse(selectedTab.Tag.ToString(), out int result) ? result : 0;
            if (id == 0) return;
            await _controller.UpdateAlbumAsync(id);
            var newTab = await _controller.GetAlbumTabByIdAsync(id);
            tabAlbum.Controls.Remove(selectedTab);
            tabAlbum.Controls.Add(newTab);
            tabAlbum.SelectedTab = newTab;
        }

        private void btnLoadArtist_Click(object sender, EventArgs e)
        {
            tbxSearch.Text = tabAlbum.SelectedTab?.Tag.ToString();
        }
    }
}