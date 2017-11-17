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
using CelpontVadaszcentrum.Utility;
using Android.Graphics;
using Square.Picasso;

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
        private ProductImageURLsService ProductImageURLsService;
        private Product Product;
        private int ProductID;
        private int ImageId;
        //private List<Bitmap> Images;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductDetailLayout);

            ProductID = Intent.GetIntExtra("ProductID", 0);

            ProductDetailService = new ProductDetailService();
            Product = ProductDetailService.GetProductByID(ProductID);

            ProductImageURLsService = new ProductImageURLsService();

            Product.Images = null;
            Product.Images = ProductImageURLsService.GetProductImageUrlsByID(ProductID, Product.Name);

            FindMyViews();
            Image.Click += Image_Click;
            SetViews();
        }

        private void Image_Click(object sender, EventArgs e)
        {
            //if(ImageId < Images.Count-1)
            if (ImageId < Product.Images.Count - 1)
            {
                ImageId++;                
            }
            else {
                ImageId = 0;
            }
            //Image.SetImageBitmap(Images[ImageId]);
            Picasso.With(this)
            .Load(Product.Images[ImageId])
            .MemoryPolicy(MemoryPolicy.NoCache)
            .Into(Image);
        }

        private void SetViews()
        {
            Name.Text = Product.Name;
            Price.Text = Product.Price.ToString("## ###")+" Ft";
            Description.TextFormatted = Html.FromHtml(Product.Description);


            Picasso.With(this)
            .Load(Product.Images[0])
            .MemoryPolicy(MemoryPolicy.NoCache)
            .Into(Image);
            ImageId = 0;

            /*
            Images = new List<Bitmap>();


            foreach (var url in Product.Images)
            {
                Images.Add(ImageHelper.GetImageBitmapFromUrl(url));
            }
            Image.Id = 0;
            Image.SetImageBitmap(Images[0]);
            */


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