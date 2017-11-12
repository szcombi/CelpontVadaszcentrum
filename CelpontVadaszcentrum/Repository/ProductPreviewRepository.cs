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
    public class ProductPreviewRepository
    {
        private static List<ProductPreview> ProductPreviews = new List<ProductPreview>();

        string url = "http://celpont.vadaszcentrum.hu/JSON_API/ProductsByCategory.php?id=";

        public ProductPreviewRepository()
        {
        }

        public List<ProductPreview> GetProductsByCategoryID(int ID)
        {
            Task.Run(() => this.LoadDataAsync(url + ID)).Wait();
            return ProductPreviews;
        }


        private async Task LoadDataAsync(string uri)
        {
            if (ProductPreviews != null)
            {
                string responseJsonString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

                        HttpResponseMessage response = await getResponse;

                        responseJsonString = await response.Content.ReadAsStringAsync();
                        ProductPreviews = JsonConvert.DeserializeObject<List<ProductPreview>>(responseJsonString);
                        

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