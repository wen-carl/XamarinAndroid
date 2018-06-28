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

namespace XamarinAndroid.Utils.ListView
{
    class ListViewAdapter<T> : BaseAdapter
    {

        Context context;
        public T[] Items { get; private set; }

        public int LayoutId;

        public ListViewAdapter(Context context, T[] items, int layoutId)
        {
            this.context = context;
            this.Items = items;
            this.LayoutId = layoutId;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return Items[position] as Java.Lang.Object;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ListViewAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ListViewAdapterViewHolder;

            if (holder == null)
            {
                var inflater = LayoutInflater.FromContext(context);
                view = inflater.Inflate(Resource.Layout.item_list_view, parent, false);
                holder = new ListViewAdapterViewHolder(view);
                view.Tag = holder;
            }

            holder.TextContent.Text = Items[position] as string;

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return Items.Length;
            }
        }


    }

    class ListViewAdapterViewHolder : Java.Lang.Object
    {
        public ImageView Icon { get; private set; }

        public TextView TextContent { get; private set; }

        public ImageView Indicator { get; private set; }

        public ListViewAdapterViewHolder(View parent)
        {
            Icon = parent.FindViewById<ImageView>(Resource.Id.icon);
            TextContent = parent.FindViewById<TextView>(Resource.Id.tv_content);
            Indicator = parent.FindViewById<ImageView>(Resource.Id.indicator);
        }
    }
}