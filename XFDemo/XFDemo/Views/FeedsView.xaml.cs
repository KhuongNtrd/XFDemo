using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFDemo.Models;
using Acr.UserDialogs;

namespace XFDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeedsView : ContentPage
	{
		public FeedsView ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var httpClient = new HttpClient();

            UserDialogs.Instance.ShowLoading();

            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://graph.facebook.com/v3.1/me?fields=posts{full_picture,message}");
            request.Method = HttpMethod.Get;
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ProfileView.FbToken);

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();

                var feeds = JsonConvert.DeserializeObject<Feeds>(body);

                BindingContext = feeds;
            }

            UserDialogs.Instance.HideLoading();
        }
    }
}