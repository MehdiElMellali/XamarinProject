using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreamVideo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TraillorPage : ContentPage
	{
		public TraillorPage (string traillor)
		{
			InitializeComponent ();

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body style='background-color:black'>  <div style=' position: relative; padding-bottom: 56.25%; padding-top: 25px; margin-top: 50%;'> <iframe style='position: absolute; top: 0; left: 0; width: 100%; height: 100%;'  src='" + traillor + "' frameborder='0' allowfullscreen></iframe></div> </body></html>";

            browser.Source = htmlSource;
        }
    }
}