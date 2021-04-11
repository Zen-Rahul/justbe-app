using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using JustBe.Droid.Client;
using System.Collections.Generic;

namespace JustBe.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //WebView webView = (WebView)FindViewById(Resource.Id.webView);
            WebView webView = new WebView(this);
            SetWebViewSettings(webView);

            SetContentView(webView);

        }

        private static void SetWebViewSettings(WebView webView)
        {
            webView.Settings.DomStorageEnabled = true;
            webView.Settings.AllowFileAccessFromFileURLs = true;
            webView.Settings.AllowContentAccess = true;
            webView.Settings.AllowFileAccess = true;
            webView.Settings.AllowUniversalAccessFromFileURLs = true;
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.SetPluginState(WebSettings.PluginState.On);
            WebView.SetWebContentsDebuggingEnabled(true);
            string indexHtmlPath = "file:///android_asset/www/index.html";


            webView.SetWebViewClient(new JustBeWebViewClient());
            //Load url and start web view
            webView.LoadUrl(indexHtmlPath);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void GetPermission()
        {
            var RequiredPermissions = new List<(string androidPermission, bool isRuntime)>
            {
                (Android.Manifest.Permission.ReadExternalStorage, true),
                (Android.Manifest.Permission.WriteExternalStorage, true)
            }.ToArray();
        }
    }
}
