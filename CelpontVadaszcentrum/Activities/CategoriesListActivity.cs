using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using CelpontVadaszcentrum.Adapters;
using CelpontVadaszcentrum.Model;
using CelpontVadaszcentrum.Service;
using Javax.Security.Auth;
using Newtonsoft.Json;
using AndroidHUD;

namespace CelpontVadaszcentrum.Activities
{
    [Activity(Label = "CategoriesListActivity")]
    public class CategoriesListActivity : Activity
    {
        private CategoryService CategoryService;
        private ListView CategoriesListView;
        private List<Category> Categories;
        private Category ClickedCategory;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CategoriesListLayout);
            AndHUD.Shared.Show(this, "Termékkategóriák betöltése...", -1, MaskType.Clear);
            CategoryService = new CategoryService();
            Categories = CategoryService.GetAllCategories();
            AndHUD.Shared.Dismiss(this);
            CategoriesListView = FindViewById<ListView>(Resource.Id.CategoriesList);
            CategoriesListView.Adapter = new CategoriesListAdapter(this, Categories);
            CategoriesListView.ItemClick += CategoriesListView_ItemClick;
            //StartActivity(typeof (ProductDetailActivity));

        }

        private void CategoriesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (ClickedCategory == null)
            {
                CategoriesListView.Adapter = new CategoriesListAdapter(this, Categories[e.Position].Children);
                ClickedCategory = Categories[e.Position];
            }
            else
            {
                if (ClickedCategory.Children[e.Position].Children.Count != 0)
                {
                    CategoriesListView.Adapter = new CategoriesListAdapter(this, ClickedCategory.Children[e.Position].Children);
                    ClickedCategory = ClickedCategory.Children[e.Position];
                }
                else
                {
                    var productListByCategoryActivity = new Intent(this, typeof(ProductListByCategoryActivity));
                    productListByCategoryActivity.PutExtra("CategoryID", ClickedCategory.Children[e.Position].Id_Category);
                    StartActivity(productListByCategoryActivity);
                }
            }
           
           
        }
    }
}

