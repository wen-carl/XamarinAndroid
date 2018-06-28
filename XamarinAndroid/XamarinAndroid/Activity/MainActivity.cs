using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections;
using Android.Views;
using Android.Content;
using System;
using XamarinAndroid.Activity;

namespace XamarinAndroid
{
    [Activity(LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class MainActivity : ListActivity
    {
        private string[] Items;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            Items = new string[] {
                "SnackBar",
                "CardView",
                "RecyclerView",
                "BottomNavigationView",
                "NavigationLayout",
                "NestedScrollView + RecyclerView"
            };

            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Items);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            
            string content = Items[position];
            
            Type myClass = null; 
            switch (content)
            {
                case "SnackBar":
                    myClass = typeof(SnackBarActivity);
                    break;
                case "CardView":
                    myClass = typeof(CardViewActivity);
                    break;
                case "RecyclerView":
                    myClass = typeof(RecyclerViewActivity);
                    break;
                case "BottomNavigationView":
                    myClass = typeof(BottomNavgationActivity);
                    break;
                case "NavigationLayout":
                    break;
                case "NestedScrollView + RecyclerView":
                    break;
                default:
                    break;
            }

            if (null != myClass)
            {
                StartActivity(new Intent(this, myClass));
            }
            else
            {
                Toast.MakeText(this, content + " 开发中...", ToastLength.Short).Show();
            }
        }
    }
}

