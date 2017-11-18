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
    [Activity(Label = "ContactActivity")]
    public class ContactActivity : Activity
    {
        private TextView PhoneNumber;
        private TextView Email1;
        private TextView Email2;
        private ImageView Maps;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactLayout);
            FindMyViews();
            HandleClicks();
        }

        private void HandleClicks()
        {
            PhoneNumber.Click += PhoneNumber_Click;
            Email1.Click += Email1_Click;
            Email2.Click += Email2_Click;
            Maps.Click += Maps_Click;
        }

        private void Maps_Click(object sender, EventArgs e)
        {
            var geoUri = Android.Net.Uri.Parse("geo:46.9873956,16.6166643,17");            
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }

        private void Email2_Click(object sender, EventArgs e)
        {
            var email = new Intent(Android.Content.Intent.ActionSend);
            email.PutExtra(Android.Content.Intent.ExtraEmail, Email2.Text);
            email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello Email");
            email.SetType("message/rfc822");
            StartActivity(email);
        }

        private void Email1_Click(object sender, EventArgs e)
        {
            var email = new Intent(Android.Content.Intent.ActionSend);
            email.PutExtra(Android.Content.Intent.ExtraEmail, Email1.Text);
            email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello Email");
            email.SetType("message/rfc822");
            StartActivity(email);
        }

        private void PhoneNumber_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("tel:"+PhoneNumber.Text);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);
        }

        private void FindMyViews()
        {
            PhoneNumber = FindViewById<TextView>(Resource.Id.phoneNumberTXT);
            Email1 = FindViewById<TextView>(Resource.Id.email1TXT);
            Email2 = FindViewById<TextView>(Resource.Id.email2TXT);
            Maps = FindViewById<ImageView>(Resource.Id.mapsImageView);
        }
    }
}