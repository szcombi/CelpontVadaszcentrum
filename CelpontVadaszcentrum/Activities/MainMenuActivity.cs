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
using CelpontVadaszcentrum.Repository;

namespace CelpontVadaszcentrum.Activities
{
    [Activity(Label = "CelpontVadaszcentrum")]
    public class MainMenuActivity : Activity
    {
        private Button ProductCatalog;
        private Button News;
        private Button Discounts;
        private Button Newsletter;
        private Button Contact;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenuLayout);
            FindMyViews();
            HandleClickEvents();

        }

        private void HandleClickEvents()
        {
            ProductCatalog.Click += ProductCatalog_Click;
            News.Click += News_Click;
            Discounts.Click += Discounts_Click;
            Newsletter.Click += Newsletter_Click;
            Contact.Click += Contact_Click;
        }

        private void Contact_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ContactActivity));
        }

        private void Newsletter_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NewsletterActivity));
        }

        private void Discounts_Click(object sender, EventArgs e)
        {
            var productListByCategoryActivity = new Intent(this, typeof(ProductListByCategoryActivity));
            productListByCategoryActivity.PutExtra("CategoryID", 0);
            productListByCategoryActivity.PutExtra("CategoryName", "Akciós termékek");
            StartActivity(productListByCategoryActivity);
        }

        private void News_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NewsActivity));
        }

        private void ProductCatalog_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CategoriesListActivity));
        }

        private void FindMyViews()
        {
            ProductCatalog = FindViewById<Button>(Resource.Id.catalogButton);
            News = FindViewById<Button>(Resource.Id.newsButton);
            Discounts = FindViewById<Button>(Resource.Id.discountsButton);
            Newsletter = FindViewById<Button>(Resource.Id.newsletterButton);
            Contact = FindViewById<Button>(Resource.Id.contactButton);
        }
    }
}