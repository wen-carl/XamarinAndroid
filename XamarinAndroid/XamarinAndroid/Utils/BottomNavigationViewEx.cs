using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamarinAndroid.Utils
{
    public static class BottomNavigationViewEx
    {
        private const string TAG = "BottomNavigationViewEx";

        public static BottomNavigationMenuView GetMenuView(this BottomNavigationView navView)
        {
            try
            {
                var mClass = navView.Class;
                var field = mClass.GetDeclaredField("mMenuView");
                field.Accessible = true;

                return field.Get(navView) as BottomNavigationMenuView;
            }
            catch (Java.Lang.Exception e)
            {
                Log.Error(TAG, e.Message, e);
            }

            return null;
        }

        public static void EnableShiftMode(this BottomNavigationView navView, bool enable)
        {
            try
            {
                var menuView = navView.GetMenuView();
                var shiftMode = menuView.Class.GetDeclaredField("mShiftingMode");

                shiftMode.Accessible = true;
                shiftMode.SetBoolean(menuView, enable);
                shiftMode.Accessible = false;
                shiftMode.Dispose();
            }
            catch (Java.Lang.Exception e)
            {
                Log.Error(TAG, e.Message, e);
            }
        }

        public static void EnableMenuItemShiftMode(this BottomNavigationView navView, bool enable)
        {
            try
            {
                var menuView = navView.GetMenuView();

                for (int i = 0; i < menuView.ChildCount; i++)
                {
                    if (!(menuView.GetChildAt(i) is BottomNavigationItemView item))
                        continue;

                    item.SetShiftingMode(enable);
                    item.SetChecked(item.ItemData.IsChecked);
                }

                menuView.UpdateMenuView();
            }
            catch (Java.Lang.Exception e)
            {
                Log.Error(TAG, e.Message, e);
            }
        }
    }
}