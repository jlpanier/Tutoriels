using Android.Views;

namespace Tutoriels.Code.Activities.GeoLocalisation
{
    public class ListViewLocalisationAdapter : SimpleAdapter<LocalisationItem>
    {
        protected override int LayoutResourceId => Resource.Layout.GeoLocalisationItem;

        public ListViewLocalisationAdapter(Activity context) : base(context)
        {
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            LocalisationItemHolder holder = view.Tag as LocalisationItemHolder;

            if (holder == null)
            {
                holder = new LocalisationItemHolder();
                holder.tvItem1 = view.FindViewById<TextView>(Resource.Id.tvItem1);
                holder.tvItem2 = view.FindViewById<TextView>(Resource.Id.tvItem2);
                holder.tvItem3 = view.FindViewById<TextView>(Resource.Id.tvItem3);
                view.Tag = holder;
            }

            LocalisationItem item = Items[position];
            holder.tvItem1.Text = $"{item.DateOn.ToString("HH:mm:ss.fff")} - {item.Position}";
            holder.tvItem2.Text = item.Provider;
            holder.tvItem3.Text = item.Evenement;

            return view;
        }
    }
}