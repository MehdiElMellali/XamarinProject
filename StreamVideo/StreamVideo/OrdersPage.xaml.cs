using Newtonsoft.Json;
using StreamVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreamVideo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        private readonly string _movie;
        public OrdersPage(string movie,string price)
        {
            InitializeComponent();
            _movie = movie;

            LblPrice.Text = price;

            LblTotal.Text = price + "$";
        }

        private void EntName_Unfocused(object sender, FocusEventArgs e)
        {
            var name = EntName.Text;
            if (String.IsNullOrWhiteSpace(name))
            {
                LblNameWarning.IsVisible = true;
            }
            else
            {
                LblNameWarning.IsVisible = false;
            }
        }

        private void EntPhone_Unfocused(object sender, FocusEventArgs e)
        {
            var phone = EntPhone.Text;
            if (String.IsNullOrWhiteSpace(phone))
            {
                LblPhoneWarning.IsVisible = true;
            }
            else
            {
                LblPhoneWarning.IsVisible = false;
            }
        }

        private void PickerQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qty = PickerQty.Items[PickerQty.SelectedIndex];

            LblQty.Text = qty;
            double price = Convert.ToDouble(LblPrice.Text);
            double totlePrice = Convert.ToDouble(qty) * (double)price;

            LblTotal.Text = totlePrice + "$";

        }

        private async void btnBookNow_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(EntName.Text) || string.IsNullOrWhiteSpace(EntEmail.Text) || string.IsNullOrWhiteSpace(EntPhone.Text))
            {
                await DisplayAlert("Alert","Please fill all the fields","Alright");
            }
            else
            {
                Order order = new Order
                {
                    CustomerName = EntName.Text,
                    Email = EntEmail.Text,
                    Phone = EntPhone.Text,
                    MovieName = _movie,
                    BookingDate = DateTime.Now.ToString(),
                    Qty = LblQty.Text,
                    TotalPayment = LblTotal.Text
                };

                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(order);
                var content = new StringContent(json,Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync("http://cinemo.azurewebsites.net/api/Orders", content);
                if (result.StatusCode == HttpStatusCode.Created)
                {
                    await DisplayAlert("Congrats", "Your Ticket has been reserved", "Alright");

                }
            }
        }

        private void EntEmail_Unfocused(object sender, FocusEventArgs e)
        {
            var email = EntEmail.Text;
            var pattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&\'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";

            if (String.IsNullOrEmpty(email))
            {
                LblEmailWarning.IsVisible = true;
            }

            else if (!Regex.IsMatch(email, pattern))
            {
                LblEmailWarning.IsVisible = true;
            }
            else
            {
                LblEmailWarning.IsVisible = false;
            }
        }
    }
}