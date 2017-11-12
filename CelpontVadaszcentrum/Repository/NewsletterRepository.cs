using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CelpontVadaszcentrum.Model;
using Newtonsoft.Json;

namespace CelpontVadaszcentrum.Repository
{
    public class NewsletterRepository
    {
        private String Response = "";

        string url = "http://celpont.vadaszcentrum.hu/JSON_API/Newsletter.php?email=";

        public NewsletterRepository()
        {
            
        }

        public String SubscibeEmail(string email)
        {
            Task.Run(() => this.LoadDataAsync(url+email)).Wait();
            return Response;
        }
        
        

        private async Task LoadDataAsync(string uri)
        {
            if (Response != null)
            {
                string responseJsonString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

                        HttpResponseMessage response = await getResponse;

                        responseJsonString = await response.Content.ReadAsStringAsync();
                        Response = JsonConvert.DeserializeObject<String>(responseJsonString);
                      
                    }
                    catch (Exception ex)
                    {
                        //handle any errors here, not part of the sample app
                        string message = ex.Message;
                    }
                }
            }
        }
    }
}