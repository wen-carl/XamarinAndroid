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

namespace XamarinAndroid.Activity
{
    [Activity(Label = "CardViewActivity")]
    public class CardViewActivity : Android.App.Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_cardview);

            var tv = FindViewById<TextView>(Resource.Id.textView1);
            tv.Text = "CardViewActivity";
        }
    }
}