using Android.Views;
using System.Globalization;

namespace Tutoriels.Code.Activities.Culture
{
    public class ListViewAdapter : SimpleAdapter<CultureInfo>
    {
        protected override int LayoutResourceId => Resource.Layout.CultureInfoItem;

        private readonly CultureInfo[] _items;

        public ListViewAdapter(Activity context) : base(context)
        {
            Reset(CultureInfo.GetCultures(CultureTypes.SpecificCultures));
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            ListViewHolder holder = view.Tag as ListViewHolder;

            if (holder == null)
            {
                holder = new ListViewHolder();
                holder.tvDisplayName = view.FindViewById<TextView>(Resource.Id.tvDisplayName);
                holder.tvEnglishName = view.FindViewById<TextView>(Resource.Id.tvEnglishName);
                holder.tvName = view.FindViewById<TextView>(Resource.Id.tvName);
                holder.tvNativeName = view.FindViewById<TextView>(Resource.Id.tvNativeName);
                holder.tvLCID = view.FindViewById<TextView>(Resource.Id.tvLCID);
                view.Tag = holder;
            }

            CultureInfo item = Items[position];
            holder.tvDisplayName.Text = item.DisplayName;
            holder.tvEnglishName.Text = item.EnglishName;
            holder.tvName.Text = item.Name;
            holder.tvNativeName.Text = item.NativeName;
            holder.tvLCID.Text = item.LCID.ToString();

            return view;
        }

    }
}