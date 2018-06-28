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

namespace XamarinAndroid.Utils
{
    class RecyclerViewAdapter<T> : RecyclerView.Adapter
    {
        public T[] Items { get; private set; }

        private int ItemLayout;

        public override int ItemCount
        {
            get { return Items.Length; }
        }

        public RecyclerViewAdapter(int itemLayout, T[] items) : base()
        {
            Items = items;
            ItemLayout = itemLayout;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder mHolder = holder as RecyclerViewHolder;
            mHolder.TextContent.Text = Items[position] as string;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(ItemLayout, parent, false);
            var holder = new RecyclerViewHolder(view);
            return holder;
        }
    }

    public class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextContent { get; private set; }
        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            TextContent = itemView.FindViewById<TextView>(Resource.Id.textView);
        }
    }
}