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
using Android.Support.V7.App;
using Android.Support.Design.Widget;

namespace XamarinAndroid.Activity
{
    [Activity(Label = "SnackBarActivity")]
    public class SnackBarActivity : AppCompatActivity
    {
        private Button _btnTop;
        private Button _btnBottom;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_snackbar);

            // Create your application here
            FindViews();
            BindData();
            BindEvent();
        }

        private void FindViews()
        {
            _btnTop = FindViewById<Button>(Resource.Id.btn_top);
            _btnBottom = FindViewById<Button>(Resource.Id.btn_bottom);
        }

        private void BindData()
        {

        }

        private void BindEvent()
        {
            _btnTop.Click += (s, e) =>
            {
                
            };

            _btnBottom.Click += (s, e) =>
            {
                Snackbar.Make(_btnBottom, "ss", Snackbar.LengthLong).Show();
            };
        }
    }
}