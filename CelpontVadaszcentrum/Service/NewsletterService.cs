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
using CelpontVadaszcentrum.Model;
using CelpontVadaszcentrum.Repository;

namespace CelpontVadaszcentrum.Service
{
    public class NewsletterService
    {
        private static NewsletterRepository newsletterRepository = new NewsletterRepository();

        public NewsletterService()
        {
        }

        public String Subscribe(string email)
        {
            return newsletterRepository.SubscibeEmail(email);
        }

    }
}