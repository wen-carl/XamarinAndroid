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
using Android.Support.V7.Widget;
using XamarinAndroid.Utils;

namespace XamarinAndroid
{
    [Activity(Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class RecyclerViewActivity : Android.App.Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_recyclerview);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            string[] temArr = { "1", "2", "3", "4", "5", "6", "7", "8" };
            var adapter = new RecyclerViewAdapter<string>(Resource.Layout.item_recyclerview, temArr);
            recyclerView.SetAdapter(adapter);
        }
    }
}