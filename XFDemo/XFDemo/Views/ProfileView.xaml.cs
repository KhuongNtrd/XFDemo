using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using XFDemo.Models;

namespace XFDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentPage
    {
        public const string FbToken = "EAADVb0UW6BIBAAEB8gO9ZBx7d7c2U7NMm0WTBZCgHoIbf3cYpZCTBZB5S595bZB4mXSa9KCoBZAM83K3ZAHEwGk0iRylpN0L6Q504JsHF1p1O4DdpU1KmI3Qf2A0tGyQy6Ob2TjmfIxDqbwUSxLTHvXqiiCnqgJq4SNUcbIJyExSXU33ZBRngVuJ7Yz1rihNsDRCKBM4hOnNs5MEeqrX5BeBZAz7QpzQikZCYZD";

        public ProfileView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //using System.Net.Http;
            //using System.Net.Http.Headers;
            //using Newtonsoft.Json;

            var httpClient = new HttpClient();
            try
            {


                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://graph.facebook.com/v3.1/me?fields=id,name,picture,email,birthday");
                request.Method = HttpMethod.Post;
                //request.Content = new StringContent("sdasdasdasd");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", FbToken);

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    FacebookProfile profile = JsonConvert.DeserializeObject<FacebookProfile>(body);

                    BindingContext = profile;
                }
            }
            catch (Exception)
            {

            //    throw;
            }
        }

        private void Feed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeedsView());
        }
    }
}