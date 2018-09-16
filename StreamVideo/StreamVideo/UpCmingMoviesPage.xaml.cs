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
	public partial class UpCmingMoviesPage : ContentPage
	{
		public UpCmingMoviesPage ()
		{
			InitializeComponent ();
            GetUpComingMovies();

        }
        public async Task<List<UpComingMovies>> GetUpComingMovies()
        {
            SLLoader.IsVisible = true;
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://cinemo.azurewebsites.net/api/UpComingMovies");
            var employees = JsonConvert.DeserializeObject<List<UpComingMovies>>(response);
            MovieListView.ItemsSource = employees;
            SLMovies.IsVisible = true;

            return employees;
        }

        private void ListViewUpComing_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}