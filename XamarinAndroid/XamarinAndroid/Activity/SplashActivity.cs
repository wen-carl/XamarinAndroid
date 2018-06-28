using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAndroid.Activity
{
    [Activity(MainLauncher = true, Theme = "@style/MyTheme.Splash")]
    public class SplashActivity : Android.App.Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.layout_splash);
            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task startUpWork = new Task(()=>{
                SimulateStartup();
            });
            startUpWork.Start();
        }

        async private void SimulateStartup()
        {
            await Task.Delay(3000);
            StartActivity(new Intent(this, typeof(MainActivity)));
            Finish();
        }

        public override void OnBackPressed()
        {
            //base.OnBackPressed();
        }
    }
}