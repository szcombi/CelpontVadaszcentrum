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
    public class CategoryService
    {
        private static CategoryRepository categoryRepository = new CategoryRepository();

        public CategoryService()
        {
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

    }
}