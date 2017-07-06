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

namespace CelpontVadaszcentrum.Adapters
{
    public class CategoriesListAdapter : BaseAdapter<Category>
    {
        List<Category> items;
        Activity context;

        public CategoriesListAdapter(Activity context, List<Category> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Category this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];


            //var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + item.ImagePath + ".jpg");

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.CategoryRowView, null);
            }

            //convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = item.Name;
            //convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
            //convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.Price;
            //convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView).SetImageBitmap(imageBitmap);
            convertView.FindViewById<TextView>(Resource.Id.CategoryNameTextView).Text = item.Name;
            return convertView;
        }
    }
}