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
    public class ProductImageURLsService
    {
        private static ProductImageURLsRepository productImageURLsRepository = new ProductImageURLsRepository();

        public ProductImageURLsService()
        {
        }

        public List<string> GetProductImageUrlsByID(int ID, string name)
        {
            return productImageURLsRepository.GetProductImageUrlsByProductId(ID, name);
        }

    }
}