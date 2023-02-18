using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace photosNews
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            noticias();
        }

        public async Task noticias()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://newsapi.org/v2/top-headlines?country=us&apiKey=f9ac29898e5a409ab3aa8208c0c78e8e");
            request.Method = HttpMethod.Get;
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                String json = content.ToString();
                var jsonObject = JObject.Parse(json);

                var status = jsonObject["status"];
                var results = jsonObject["totalResults"];
                var articles = jsonObject["articles"];

                Debug.WriteLine(articles);

            }
        }
    }
}
