using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CelpontVadaszcentrum.Service;
using CelpontVadaszcentrum.Model;
using CelpontVadaszcentrum.Adapters;

namespace CelpontVadaszcentrum.Activities
{
    [Activity(Label = "ProductListByCategory")]
    public class ProductListByCategoryActivity : Activity
    {
        private ProductPreviewService ProductPreviewService;
        private ListView ProductPreviewsListView;
        private List<ProductPreview> ProductPreviews;
        private int CategoryID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductPreviewListLayout);

            CategoryID = Intent.GetIntExtra("CategoryID",0);

            ProductPreviewService = new ProductPreviewService();

            ProductPreviews = ProductPreviewService.GetProductsByCategoryID(CategoryID);
            ProductPreviewsListView = FindViewById<ListView>(Resource.Id.ProductPreviewList);
            ProductPreviewsListView.Adapter = new ProductListByCategoryAdapter(this, ProductPreviews);
            ProductPreviewsListView.ItemClick += ProductPreviewsListView_ItemClick;

        }

        private void ProductPreviewsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var productDetailActivity = new Intent(this, typeof(ProductDetailActivity));
            productDetailActivity.PutExtra("ProductID", ProductPreviews[e.Position].ID);
            StartActivity(productDetailActivity);
        }
    }
}