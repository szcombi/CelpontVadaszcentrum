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
    public class ProductPreviewService
    {
        private static ProductPreviewRepository productPreviewRepository = new ProductPreviewRepository();

        public ProductPreviewService()
        {
        }

        public List<ProductPreview> GetProductsByCategoryID(int id)
        {
            return productPreviewRepository.GetProductsByCategoryID(id);
        }

    }
}