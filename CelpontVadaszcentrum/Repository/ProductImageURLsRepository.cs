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
    public class ProductImageURLsRepository
    {
        private List<ProductImageDetail> temp = new List<ProductImageDetail>();
        private List<String> URLs = new List<string>();

        string url = "http://celpont.vadaszcentrum.hu/JSON_API/Images.php?id=";

        public ProductImageURLsRepository()
        {
            
        }

        public List<string> GetProductImageUrlsByProductId(int ID, string name)
        {
            Task.Run(() => this.LoadDataAsync(url+ID)).Wait();
            foreach (var item in temp)
            {
                URLs.Add("http://celpont.vadaszcentrum.hu/" + item.id_image + "-thickbox_leoconv/" + name + ".jpg");
            }
            return URLs;
        }
        
        

        private async Task LoadDataAsync(string uri)
        {
            if (URLs != null)
            {
                string responseJsonString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

                        HttpResponseMessage response = await getResponse;

                        responseJsonString = await response.Content.ReadAsStringAsync();
                        temp = JsonConvert.DeserializeObject<List<ProductImageDetail>>(responseJsonString);
                      
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