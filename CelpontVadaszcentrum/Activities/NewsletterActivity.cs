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

namespace CelpontVadaszcentrum.Activities
{
    [Activity(Label = "NewsletterActivity")]
    public class NewsletterActivity : Activity
    {
        private NewsletterService NewsletterService;
        private EditText Email;
        private TextView Response;
        private Button Submit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewsletterLayout);
            FindMyViews();
            NewsletterService = new NewsletterService();
            Submit.Click += Submit_Click;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Response.Text = NewsletterService.Subscribe(Email.Text);
        }

        private void FindMyViews()
        {
            Email = FindViewById<EditText>(Resource.Id.emailTXT);
            Response = FindViewById<TextView>(Resource.Id.responseTXT);
            Submit = FindViewById<Button>(Resource.Id.submitEmailButton);
        }
    }
}