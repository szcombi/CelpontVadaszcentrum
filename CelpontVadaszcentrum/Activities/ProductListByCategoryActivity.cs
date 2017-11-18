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
using AndroidHUD;

namespace CelpontVadaszcentrum.Activities
{
    [Activity(Label = "ProductListByCategory")]
    public class ProductListByCategoryActivity : Activity
    {
        private ProductPreviewService ProductPreviewService;
        private DiscountedProductsPreviewService DiscountedProductsPreviewService;
        private ListView ProductPreviewsListView;
        private TextView SelectedCategory;
        private List<ProductPreview> ProductPreviews;
        private int CategoryID;
        private string CategoryName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductPreviewListLayout);

            CategoryID = Intent.GetIntExtra("CategoryID", 0);
            CategoryName = Intent.GetStringExtra("CategoryName");

            AndHUD.Shared.Show(this, "Termékek betöltése...", -1, MaskType.Clear);
            if (CategoryID == 0 && CategoryName.Equals("Akciós termékek")) {
                DiscountedProductsPreviewService = new DiscountedProductsPreviewService();
                ProductPreviews = DiscountedProductsPreviewService.GetDiscountedProducts();
            }
            else
            {
                ProductPreviewService = new ProductPreviewService();
                ProductPreviews = ProductPreviewService.GetProductsByCategoryID(CategoryID);

            }
            AndHUD.Shared.Dismiss(this);
            FindMyViews();
            SelectedCategory.Text = CategoryName;
           
            ProductPreviewsListView.Adapter = new ProductListByCategoryAdapter(this, ProductPreviews);
            ProductPreviewsListView.ItemClick += ProductPreviewsListView_ItemClick;

        }

        private void FindMyViews()
        {
            ProductPreviewsListView = FindViewById<ListView>(Resource.Id.ProductPreviewList);
            SelectedCategory = FindViewById<TextView>(Resource.Id.selectedCategoryInPreviewTXT);
        }

        private void ProductPreviewsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var productDetailActivity = new Intent(this, typeof(ProductDetailActivity));
            productDetailActivity.PutExtra("ProductID", ProductPreviews[e.Position].ID);
            StartActivity(productDetailActivity);
        }
    }
}