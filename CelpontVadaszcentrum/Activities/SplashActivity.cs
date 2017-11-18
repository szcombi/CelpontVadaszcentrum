using Android.App;
using Android.Content;
using CelpontVadaszcentrum.Activities;
using CelpontVadaszcentrum.Service;
using System.Threading;
using System.Threading.Tasks;
using CelpontVadaszcentrum.Model;
using System.Collections.Generic;
using CelpontVadaszcentrum.Utility;

[Activity(MainLauncher = true, Theme = "@style/Splash", NoHistory = true)]
public class SplashActivity : Activity
{
    private CategoryService CategoryService;


    protected override void OnResume()
    {
        base.OnResume();

        Task.Run(() =>
        {
            CategoryService = new CategoryService();
            CategoryHelper.Categories = CategoryService.GetAllCategories();
            StartActivity(new Intent(Application.Context, typeof(MainMenuActivity)));
        });
    }
}