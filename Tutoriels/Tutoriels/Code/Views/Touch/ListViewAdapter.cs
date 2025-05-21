using Android.Views;

namespace Tutoriels.Code.Views.Touch
{
    internal class ListViewAdapter : SimpleAdapter<ListViewItem>
    {
        protected override int LayoutResourceId => Resource.Layout.ItemTouch;


        public ListViewAdapter(Activity context) : base(context)
        {
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View? view = convertView;
            System.Diagnostics.Debug.Assert(Context != null);
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);
            System.Diagnostics.Debug.Assert(view != null);

            ListViewHolder? holder = view.Tag as ListViewHolder;

            if (holder == null)
            {
                holder = new ListViewHolder();
                holder.tvText = view.FindViewById<TextView>(Resource.Id.tvText);
                view.Tag = holder;
            }

            System.Diagnostics.Debug.Assert(holder != null);
            System.Diagnostics.Debug.Assert(holder.tvText != null);

            var item = Items[position];
            holder.tvText.Text = item.Text;

            return view;
        }
    }
}
