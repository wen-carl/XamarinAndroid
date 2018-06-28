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

namespace XamarinAndroid.Widget.MySnackBar
{
    public sealed class MySnackBar : BaseTransientBottomBar
    {
        protected MySnackBar(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected MySnackBar(ViewGroup parent, View content, IContentViewCallback contentViewCallback) : base(parent, content, contentViewCallback)
        {
        }
    }
}