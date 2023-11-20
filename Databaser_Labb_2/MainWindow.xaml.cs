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
using Databaser_Labb_2.Views;
using Databaser_Labb_2.MyWindows;
using Menu = Databaser_Labb_2.Models.Menu;

namespace Databaser_Labb_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public TrackChosen trackChosen;

		public Track currentTrack = null;

		private Labb2DBContext _dbContext;

		public Window1 window = new Window1();

		public Playlist? currentPlaylist;

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
			if (trackChosen != null)
			{
				trackChosen.DeleteTrackBtn.Visibility = Visibility.Collapsed;

				TrackListBox.Items.Clear();

				trackChosen.DeleteTrackBtn.Visibility = Visibility.Collapsed;//I am repeating this line of code because I dont know for the life of my why it doesnt work properly unless I have them both here.
			}


			ListBox listBox = sender as ListBox;


			currentPlaylist = listBox.SelectedItem as Playlist;

			LoadData();
		}

		private void TrackListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ListBox listBox = sender as ListBox;

			currentTrack = listBox.SelectedItem as Track;

			if (trackChosen == null)
			{
				trackChosen = new TrackChosen(); // Fel. Clear
				this.MainGrid.Children.Add(trackChosen);
			}
			else
			{
				trackChosen.DeleteTrackBtn.Visibility = Visibility.Visible;
			}
			
			Grid.SetColumn(trackChosen, 3);
			Grid.SetRow(trackChosen, 6);
		}

		private void CreatePlaylistBtn_Click(object sender, RoutedEventArgs e)
		{
			Menu.CreatePlaylist();

			LoadData();
		}

		private void DeletePlaylistBtn_Click(object sender, RoutedEventArgs e)
		{
			var trackToDelete = _dbContext.Tracks.FirstOrDefault(t => t.TrackId == currentTrack.TrackId);

			_dbContext.Tracks.Remove(trackToDelete);
		}
	}
}
