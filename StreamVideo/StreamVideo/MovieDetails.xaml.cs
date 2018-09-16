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
    public partial class MovieDetails : ContentPage
    {
        private  string _traillor;
        public MovieDetails(float id)
        {
            InitializeComponent();
            GetUpComingMovie(id);

        }

        private async void GetUpComingMovie(float id)
        {
            // GridMoviesDetail.IsVisible = false;

            try
            {
                SLLoader.IsVisible = true;

                HttpClient client = new HttpClient();
                var response =
                    await client.GetStringAsync("http://cinemo.azurewebsites.net/api/NowPlayingMovies/" + id);
                var movies = JsonConvert.DeserializeObject<NowPlaying>(response);

                LblMovieName.Text = movies.MovieName;
                LblRatedPgi.Text = movies.RatedPGI;
                LblType.Text = movies.MovieType;
                LblShowTime.Text = movies.ShowTime.ToString();
                LblPrint.Text = movies.MoviePrint;
                LblCast.Text = movies.Cast;
                LblPrice.Text = "$" + movies.TicketPrice;
                LblLanguage.Text = movies.MovieLanguage;
                LblDescription.Text = movies.Description;
                ImgDetail.Source = movies.PhotoFullPath;
                GridMoviesDetail.IsVisible = true;
                _traillor = movies.TrailorLink;

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

        private void BtnBookOrder_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrdersPage(LblMovieName.Text, LblPrice.Text.Substring(1)));
        }

        private void BtnTrailor_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TraillorPage(_traillor));
        }
    }
}