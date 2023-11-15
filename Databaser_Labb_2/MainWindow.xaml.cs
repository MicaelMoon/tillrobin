using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Databaser_Labb_2.Data;
using Databaser_Labb_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Databaser_Labb_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Playlist? currentPlaylist;
		private Labb2DBContext _dbContext;
		public MainWindow()
		{
			InitializeComponent();
			_dbContext = new Labb2DBContext();
			LoadData();
		}

		private async void LoadData()
		{
			//Laddar in allla playlists

			var playlists = await _dbContext.Playlists.ToListAsync();
			PlayListListBox.ItemsSource = playlists;

			currentPlaylist = PlayListListBox.SelectedItem as Playlist;

			//var tracks = _dbcontext.PlaylistTracks.FirstOrDefault(p => p.PlaylistId == currentPlaylist.PlaylistId);
			//TrackListBox.ItemsSource = tracks;


			//VIll nu skriva ut alla tracks som är bunden till current playlist

			//Söker igenom alla PlaylistTracks
			foreach(var t in _dbContext.PlaylistTracks)
			{
				if(t.PlaylistId == currentPlaylist.PlaylistId)
				{
					//Found a matching playlistTrack that is in playlist
					var k = _dbContext.Playlists.FirstOrDefault(p => p.PlaylistId == t.PlaylistId);
					TrackListBox.ItemsSource = k.Name;
				}
			}
		}

		private void CreatePlaylistBtn_Click(object sender, RoutedEventArgs e)
		{
			View1 newview = new View1();

			this.Content = newview;
			var newPlaylist = new Playlist();
		}
	}
}
