using Android.Graphics;
using Android.Views;
using System.Reflection;

namespace Tutoriels.Code.Activities.AndroidColors
{
    class ListViewAndroidColorsAdaptator : SimpleAdapter<ListViewAndroidColorsItem>
    {
        protected override int LayoutResourceId => Resource.Layout.AndroidColorsItems;


        public ListViewAndroidColorsAdaptator(Activity context) : base(context)
        {
            Load();
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View? view = convertView;
            System.Diagnostics.Debug.Assert(Context != null);
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);
            System.Diagnostics.Debug.Assert(view!=null);

            ListViewAndroidColorsHolder? holder = view.Tag as ListViewAndroidColorsHolder;

            if (holder == null)
            {
                holder = new ListViewAndroidColorsHolder();
                holder.tvRed = view.FindViewById<TextView>(Resource.Id.tvRed);
                holder.tvGreen = view.FindViewById<TextView>(Resource.Id.tvGreen);
                holder.tvBlue = view.FindViewById<TextView>(Resource.Id.tvBlue);
                holder.tvName = view.FindViewById<TextView>(Resource.Id.tvName);
                holder.imgColor = view.FindViewById<ImageView>(Resource.Id.imgColor);
                view.Tag = holder;
            }

            System.Diagnostics.Debug.Assert(holder != null);

            ListViewAndroidColorsItem item = Items[position];
            holder.tvName.Text = item.Name;
            holder.tvRed.Text = item.Color.R.ToString();
            holder.tvGreen.Text = item.Color.G.ToString();
            holder.tvBlue.Text = item.Color.B.ToString();
            holder.imgColor.SetBackgroundColor(item.Color);

            return view;
        }

        private void Load()
        {
            var items = new List<ListViewAndroidColorsItem>();
            var color = Color.Maroon;
            Type t = color.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (var prop in props)
            {
                if (prop.GetIndexParameters().Length == 0 && prop.PropertyType.Name == "Color")
                {
                    var col = prop.GetValue(color);
                    if (col != null)
                    {
                        items.Add(new ListViewAndroidColorsItem((Color)col, prop.Name));
                    }
                }
            }
            Reset(items);
        }
    }
}