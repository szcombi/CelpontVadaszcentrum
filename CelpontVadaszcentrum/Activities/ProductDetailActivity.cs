using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using CelpontVadaszcentrum.Model;
using CelpontVadaszcentrum.Service;
using Java.Net;

namespace CelpontVadaszcentrum.Activities
{
    [Activity(Label = "ProductDetailActivity")]
    public class ProductDetailActivity : Activity
    {
        private TextView Name;
        private TextView Price;
        private TextView Description;
        private ImageView Image;
        private ProductDetailService ProductDetailService;
        private Product Product;
        private int ProductID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductDetailLayout);

            ProductID = Intent.GetIntExtra("ProductID", 0);
            ProductDetailService = new ProductDetailService();
            Product = ProductDetailService.GetProductByID(ProductID);
            FindMyViews();
            SetViews();
        }

        private void SetViews()
        {
            Name.Text = Product.Name;
            Price.Text = Product.Price.ToString("## ###")+" Ft";
            Description.TextFormatted = Html.FromHtml(Product.Description);
            //Image.SetImageBitmap();
            //string new_string = Regex.Replace(Description.Text, @"\n+", "\n");
            // Description.Text = new_string;
        }

        private void FindMyViews()
        {
            Name = FindViewById<TextView>(Resource.Id.txtProductName);
            Price = FindViewById<TextView>(Resource.Id.txtPrice);
            Description = FindViewById<TextView>(Resource.Id.txtDescription);
            Image = FindViewById<ImageView>(Resource.Id.imgProduct);
        }
    }
}