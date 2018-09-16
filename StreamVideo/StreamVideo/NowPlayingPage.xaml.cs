using Newtonsoft.Json;
using StreamVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreamVideo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NowPlayingPage : ContentPage
	{
		public NowPlayingPage ()
		{
			InitializeComponent ();
            GetMovies();
        }

        public async void GetMovies()
        {
            SLMovies.IsVisible = false;

            try
            {
                SLLoader.IsVisible = true;
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://cinemo.azurewebsites.net/api/NowPlayingMovies");
                var movies = JsonConvert.DeserializeObject<List<NowPlaying>>(response);
                MovieListView.ItemsSource = movies;
                SLMovies.IsVisible = true;

            }
            catch (Exception e)
            {
                SLLoader.IsVisible = false;
                throw;
            }
            finally
            {
                SLLoader.IsVisible = false;
            }

        }
        private void MovieListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (((ListView)sender).SelectedItem == null)
                return;
            //Do stuff here with the SelectedItem ...

            var selectedItem = e.SelectedItem as NowPlaying;

            if (selectedItem != null)
            {
                var id = selectedItem.MovieId;
                Navigation.PushAsync(new MovieDetails(id));
            }
            ((ListView)sender).SelectedItem = null;

        }
    }
}