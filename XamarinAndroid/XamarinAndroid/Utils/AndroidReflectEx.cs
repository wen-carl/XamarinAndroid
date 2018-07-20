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

using Java.Lang;

namespace XamarinAndroid.Utils
{
    public static class AndroidReflectEx
    {
        public static V GetField<V>(this Java.Lang.Object obj, string name) where V : Java.Lang.Object
        {
            var mClass = obj.Class;
            var field = mClass.GetDeclaredField(name);
            field.Accessible = true;
            return field.Get(obj) as V;
        }

        public static void SetField(this Java.Lang.Object obj, string name, Java.Lang.Object value)
        {
            var mClass = obj.Class;
            var field = mClass.GetDeclaredField(name);
            field.Accessible = true;
            field.Set(obj, value);
        }
    }
}