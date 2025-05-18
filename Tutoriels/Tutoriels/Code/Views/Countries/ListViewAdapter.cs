using Android.Views;

namespace Tutoriels.Code.Activities.Countries
{
    internal class ListViewAdapter : SimpleAdapter<Repository.Entities.Country>
    {
        protected override int LayoutResourceId => Resource.Layout.ListViewCountryItem;

        public ListViewAdapter(Activity context) : base(context)
        {
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            ListViewHolder holder = view.Tag as ListViewHolder;

            if (holder == null)
            {
                holder = new ListViewHolder();
                holder.tvLigne1 = view.FindViewById<TextView>(Resource.Id.tvLigne1);
                holder.tvLigne2 = view.FindViewById<TextView>(Resource.Id.tvLigne2);
                holder.imgFlag = view.FindViewById<ImageView>(Resource.Id.imgFlag);
                holder.imgProjection = view.FindViewById<ImageView>(Resource.Id.imgProjection);
                view.Tag = holder;
            }

            Repository.Entities.Country item = Items[position];
            holder.tvLigne1.Text = item.SHORTNAME;
            holder.tvLigne2.Text = item.LONGNAME;

            int resourceid = Context.Resources.GetIdentifier(item.FLAG, "drawable", Context.PackageName);
            holder.imgFlag.SetImageResource(resourceid > 0 ? resourceid : Android.Resource.Drawable.IcMenuInfoDetails);

            resourceid = Context.Resources.GetIdentifier(item.PROJECTION, "drawable", Context.PackageName);
            holder.imgProjection.SetImageResource(resourceid > 0 ? resourceid : Android.Resource.Drawable.IcMenuInfoDetails);

            return view;
        }
    }
}