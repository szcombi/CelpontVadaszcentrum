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
using Android.Webkit;
using AndroidHUD;

namespace CelpontVadaszcentrum.Activities
{
    [Activity(Label = "NewsActivity")]
    public class NewsActivity : Activity
    {
        private WebView webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AndHUD.Shared.Show(this, "Hírek betöltése...", -1, MaskType.Clear);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewsLayout);
            FindMyViews();
            webView.LoadUrl("http://celpont.vadaszcentrum.hu/hirek.html");
            AndHUD.Shared.Dismiss(this);

        }

        private void FindMyViews()
        {
            webView = FindViewById<WebView>(Resource.Id.newsWebView);
        }
    }
}