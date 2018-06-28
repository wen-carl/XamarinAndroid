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
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using XamarinAndroid.Utils;
using XamarinAndroid.Fragments;
using Android.Support.V4.View;
using XamarinAndroid.Utils.ViewPager;

namespace XamarinAndroid
{
    [Activity(Theme = "@style/Theme.MyTheme")]
    public class BottomNavgationActivity : AppCompatActivity
    {
        private Android.Support.V7.Widget.Toolbar mToolbar;

        private BottomNavigationView mBottomNav;

        private ViewPager mViewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_bottomnavigation);

            mToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (null != mToolbar)
            {
                SetSupportActionBar(mToolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);
            }

            mBottomNav = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            mBottomNav.NavigationItemSelected += OnNavigationItemSelected;
            BottomNavigationViewUtils.SetShiftMode(mBottomNav, false, false);

            mViewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            var adapter = new ViewPagerAdapter(this.SupportFragmentManager);
            var random = new Random();
            adapter.AddFragment(new BottomNavFragment(random.Next(10, 20)));
            adapter.AddFragment(new BottomNavFragment(random.Next(10, 30)));
            adapter.AddFragment(new BottomNavFragment(random.Next(10, 40)));
            adapter.AddFragment(new BottomNavFragment(random.Next(10, 50)));
            mViewPager.Adapter = adapter;

            mViewPager.PageSelected += OnViewPagerChanged;

            mBottomNav.SelectedItemId = Resource.Id.one;
            mToolbar.Title = GetText(Resource.String.one);
            mViewPager.CurrentItem = 0;
        }

        private void OnNavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            mToolbar.Title = e.Item.TitleCondensedFormatted.ToString(); ;

            int index = -1;
            switch (e.Item.ItemId)
            {
                case Resource.Id.one:
                    index = 0;
                    break;

                case Resource.Id.two:
                    index = 1;
                    break;

                case Resource.Id.three:
                    index = 2;
                    break;

                case Resource.Id.four:
                    index = 3;
                    break;

                default:
                    break;
            }

            if (-1 != index)
            {
                mViewPager.CurrentItem = index;
            }
        }

        private void OnViewPagerChanged(object sender, ViewPager.PageSelectedEventArgs e)
        {
            int index = e.Position;
            int id = -1;
            string title = null;
            switch (index)
            {
                case 0:
                    id = Resource.Id.one;
                    title = GetText(Resource.String.one);
                    break;
                case 1:
                    id = Resource.Id.two;
                    title = GetText(Resource.String.two);
                    break;
                case 2:
                    id = Resource.Id.three;
                    title = GetText(Resource.String.three);
                    break;
                case 3:
                    id = Resource.Id.four;
                    title = GetText(Resource.String.four);
                    break;
                default:
                    break;
            }

            if (-1 != id)
            {
                mBottomNav.SelectedItemId = id;
                mToolbar.Title = title;
            }
        }
    }
}