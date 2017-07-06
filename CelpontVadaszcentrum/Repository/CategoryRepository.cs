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
    public class CategoryRepository
    {
        private static List<Category> Categories = new List<Category>();

        string url = "http://celpont.vadaszcentrum.hu/JSON_API/Categories.php";

        public CategoryRepository()
        {
            Task.Run(() => this.LoadDataAsync(url)).Wait();
        }

        public List<Category> GetAllCategories()
        {
            return Categories;
        }
        

        private async Task LoadDataAsync(string uri)
        {
            if (Categories != null)
            {
                string responseJsonString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

                        HttpResponseMessage response = await getResponse;

                        responseJsonString = await response.Content.ReadAsStringAsync();
                        Categories = JsonConvert.DeserializeObject<List<Category>>(responseJsonString);
                        
                        //gyerekeket szülök Child listájához adom!
                        foreach (var child in Categories)
                        {
                            Categories.Find(p => p.Id_Category == child.Id_Parent)?.Children.Add(child);

                        }
                        Categories.RemoveAll(x => x.Level_Depth > 2);
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