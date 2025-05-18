using Android.Views;

namespace Tutoriels.Code.Activities.Speech
{

    internal class ListViewAdapter : SimpleAdapter<ListViewAdapterItem>
    {
        protected override int LayoutResourceId => Resource.Layout.ListViewSpeechItem;

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
                holder.tvMessage = view.FindViewById<TextView>(Resource.Id.tvMessage);
                view.Tag = holder;
            }

            ListViewAdapterItem item = Items[position];
            holder.tvMessage.Text = item.Message;
            holder.tvMessage.Gravity = item.InOut ? GravityFlags.Left : GravityFlags.Right;

            return view;
        }
    }
}