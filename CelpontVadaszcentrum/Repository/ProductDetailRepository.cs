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
    public class ProductDetailRepository
    {
        private Product product = new Product();

        string url = "http://celpont.vadaszcentrum.hu/JSON_API/Product.php?id=";

        public ProductDetailRepository()
        {
            
        }

        public Product GetProductByID(int ID)
        {
            Task.Run(() => this.LoadDataAsync(url+ID)).Wait();
            return product;
        }
        
        

        private async Task LoadDataAsync(string uri)
        {
            if (product != null)
            {
                string responseJsonString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

                        HttpResponseMessage response = await getResponse;

                        responseJsonString = await response.Content.ReadAsStringAsync();
                        product = JsonConvert.DeserializeObject<Product>(responseJsonString);
                      
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