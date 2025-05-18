using Android.Views;
using System.Reflection;

namespace Tutoriels.Code.Activities.AndroidIcons
{
    class ListViewAndroidIconAdaptator : SimpleAdapter<ListViewAndroidIconItem>
    {
        protected override int LayoutResourceId => Resource.Layout.ListViewAndroidIconItemLayout;

        public ListViewAndroidIconAdaptator(Activity context) : base(context)
        {
            var items = new List<ListViewAndroidIconItem>();
            foreach (FieldInfo field in typeof(Android.Resource.Drawable).GetFields())
            {
                if (field.FieldType == typeof(int))
                {
                    items.Add(new ListViewAndroidIconItem((int)field.GetValue(null), field.Name));
                }
            }
            Reset(items);
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View? view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);


            if (view.Tag is not ListViewAndroidIconHolder holder)
            {
                holder = new ListViewAndroidIconHolder();
                holder.txtLabel = view.FindViewById<TextView>(Resource.Id.txtLabel);
                holder.imgIcon = view.FindViewById<ImageView>(Resource.Id.imgIcon);
                view.Tag = holder;
            }

            ListViewAndroidIconItem item = Items[position];
            holder.txtLabel.Text = item.Name;
            holder.imgIcon.SetImageResource(item.ResourceId);

            return view;
        }
    }
}