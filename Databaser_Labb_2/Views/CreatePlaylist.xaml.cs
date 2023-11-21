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
using Databaser_Labb_2.Models;

namespace Databaser_Labb_2.Views
{
	/// <summary>
	/// Interaction logic for CreatePlaylist.xaml
	/// </summary>
	public partial class CreatePlaylist : UserControl
	{
		public CreatePlaylist()
		{
			InitializeComponent();
		}

		private void SubmitPlaylistBtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddTrack_Click(object sender, RoutedEventArgs e)
		{
			Playlist playlist = new Playlist();
			playlist.Name = PlaylistName.Text;

			MainWindow.
		}
	}
}
