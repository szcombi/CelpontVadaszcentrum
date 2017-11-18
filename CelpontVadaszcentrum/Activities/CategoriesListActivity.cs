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
using CelpontVadaszcentrum.Utility;

namespace CelpontVadaszcentrum.Activities
{
    [Activity(Label = "CategoriesListActivity")]
    public class CategoriesListActivity : Activity
    {
        
        private ListView CategoriesListView;
        private TextView SelectedCategory;
        private Category ClickedCategory;

        protected override async void OnCreate(Bundle bundle)
        {
            AndHUD.Shared.Show(this, "Termékkategóriák betöltése...", -1, MaskType.Clear);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CategoriesListLayout);                     
            AndHUD.Shared.Dismiss(this);
            FindMyViews();
            CategoriesListView.Adapter = new CategoriesListAdapter(this, CategoryHelper.Categories);
            CategoriesListView.ItemClick += CategoriesListView_ItemClick;
            //StartActivity(typeof (ProductDetailActivity));

        }

        private void FindMyViews()
        {
            CategoriesListView = FindViewById<ListView>(Resource.Id.CategoriesList);
            SelectedCategory = FindViewById<TextView>(Resource.Id.selectedCategoryTXT);
        }

        private void CategoriesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (ClickedCategory == null)
            {
                CategoriesListView.Adapter = new CategoriesListAdapter(this, CategoryHelper.Categories[e.Position].Children);
                ClickedCategory = CategoryHelper.Categories[e.Position];
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
                    productListByCategoryActivity.PutExtra("CategoryName", ClickedCategory.Children[e.Position].Name);
                    StartActivity(productListByCategoryActivity);
                }
            }
            SelectedCategory.Text = ClickedCategory.Name;


        }
    }
}

