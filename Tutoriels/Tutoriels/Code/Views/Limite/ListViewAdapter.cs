using Android.Views;

namespace Tutoriels.Code.Activities.Limite
{
    internal class ListViewAdapter : SimpleAdapter<ListViewItem>
    {
        protected override int LayoutResourceId => Resource.Layout.LimiteItem;


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
                holder.tvN = view.FindViewById<TextView>(Resource.Id.tvN);
                holder.tvValue = view.FindViewById<TextView>(Resource.Id.tvValue);
                view.Tag = holder;
            }

            ListViewItem item = Items[position];
            holder.tvN.Text = item.N.ToString();
            holder.tvValue.Text = item.Display;
            return view;
        }
    }
}