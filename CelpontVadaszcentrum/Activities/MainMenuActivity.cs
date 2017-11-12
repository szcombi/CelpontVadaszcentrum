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

namespace CelpontVadaszcentrum.Activities
{
    [Activity(Label = "CelpontVadaszcentrum", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainMenuActivity : Activity
    {
        private Button ProductCatalog;
        private Button News;
        private Button Discounts;
        private Button Newsletter;

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
        }

        private void Newsletter_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NewsletterActivity));
        }

        private void Discounts_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
        }
    }
}