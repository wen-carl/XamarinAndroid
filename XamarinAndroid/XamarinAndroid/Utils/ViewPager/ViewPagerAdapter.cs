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
using Android.Support.V4.App;

namespace XamarinAndroid.Utils.ViewPager
{
    class ViewPagerAdapter : FragmentPagerAdapter
    {
        private List<Android.Support.V4.App.Fragment> Items;

        public ViewPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
        {
            Items = new List<Android.Support.V4.App.Fragment>();
        }

        public override int Count
        {
            get { return Items.Count; }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return Items[position];
        }

        public void AddFragment(Android.Support.V4.App.Fragment fragment)
        {
            Items.Add(fragment);
        }
    }
}