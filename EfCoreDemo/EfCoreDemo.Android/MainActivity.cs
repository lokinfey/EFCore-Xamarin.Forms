using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Runtime.InteropServices;
using Mono.Data.Sqlite;

namespace EfCoreDemo.Droid
{
    [Activity(Label = "EfCoreDemo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        [DllImport("libsqlite.so")]
        internal static extern int sqlite3_shutdown();

        [DllImport("libsqlite.so")]
        internal static extern int sqlite3_initialize();
        protected override void OnCreate(Bundle bundle)
        {
            
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            sqlite3_shutdown();
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
sqlite3_initialize();
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

