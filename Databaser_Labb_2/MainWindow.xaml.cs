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

		private void LoadData()
		{
			//Laddar in alla playlists

			var playlists = _dbContext.Playlists.ToList();

			PlayListListBox.ItemsSource = playlists;
			

			//var tracks = _dbcontext.PlaylistTracks.FirstOrDefault(p => p.PlaylistId == currentPlaylist.PlaylistId);
			//TrackListBox.ItemsSource = tracks;


			//VIll nu skriva ut alla tracks som är bunden till current playlist

			//Söker igenom alla PlaylistTracks
			try
			{

			}
			catch
			{

			}

			if (currentPlaylist != null)
			{
				//Goes through all the PLaylistTracks
				//Vad för låtar har du i denna spellistan
				foreach (var p in _dbContext.PlaylistTracks.ToList())
				{
					//if it finds a track that has a matching PlaylistId of your currentPlaylist
					//Den här låten finns i din spellista
					if (p.PlaylistId == currentPlaylist.PlaylistId)
					{
						//Found a matching playlistTrack that is in playlist
						//Add the track to the listBox of Tracks
						
						var k = _dbContext.Tracks.FirstOrDefault(t => t.TrackId == p.TrackId);
						TrackListBox.Items.Add(k);
					}
				}
			}
		}

		private void PlayListListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TrackListBox.Items.Clear();
			ListBox listBox = sender as ListBox;

			currentPlaylist = listBox.SelectedItem as Playlist;
			LoadData();
		}

		private void CreatePlaylistBtn_Click(object sender, RoutedEventArgs e)
		{
			LoadData();
		}
	}
}
