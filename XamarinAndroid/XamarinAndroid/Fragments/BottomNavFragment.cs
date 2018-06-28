using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinAndroid.Utils.ListView;

namespace XamarinAndroid.Fragments
{
    public class BottomNavFragment : Fragment
    {
        private int Count;
        public BottomNavFragment(int count) : base()
        {
            Count = count;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.layout_bottom_nav_fragment, null);

            ListView listView = view.FindViewById<ListView>(Resource.Id.listView);
            var temArr = GetData();
            var adapter = new ListViewAdapter<string>(inflater.Context, temArr, Resource.Layout.item_list_view);
            listView.Adapter = adapter;
            listView.ItemClick += (o, e) =>
            {
                Toast.MakeText(view.Context, e.Position.ToString(), ToastLength.Short).Show();
            };

            return view;
        }

        private string[] GetData()
        {
            var list = new List<string>(Count);
            for (int i = 0; i < Count; i ++)
            {
                list.Add(i.ToString());
            }

            return list.ToArray<string>();
        }
    }
}