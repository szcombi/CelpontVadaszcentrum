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
    public class DiscountedProductsPreviewService
    {
        private static DiscountedProductsPreviewRepository productPreviewRepository = new DiscountedProductsPreviewRepository();

        public DiscountedProductsPreviewService()
        {
        }

        public List<ProductPreview> GetDiscountedProducts()
        {
            return productPreviewRepository.GetDiscountedProducts();
        }

    }
}