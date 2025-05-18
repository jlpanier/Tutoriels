using Android.Views;

namespace Tutoriels.Code.Activities.Unicodes
{
    public class ListViewUnicodesAdaptator : SimpleAdapter<ListViewUnicodesItem>
    {
        protected override int LayoutResourceId => Resource.Layout.UnicodeItem;


        public ListViewUnicodesAdaptator(Activity context) : base(context)
        {
            Load();
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            ListViewUnicodesHolder holder = view.Tag as ListViewUnicodesHolder;

            if (holder == null)
            {
                holder = new ListViewUnicodesHolder();
                holder.tvId = view.FindViewById<TextView>(Resource.Id.tvId);
                holder.tvValue1 = view.FindViewById<TextView>(Resource.Id.tvValue1);
                holder.tvValue2 = view.FindViewById<TextView>(Resource.Id.tvValue2);
                holder.tvValue3 = view.FindViewById<TextView>(Resource.Id.tvValue3);
                holder.tvValue4 = view.FindViewById<TextView>(Resource.Id.tvValue4);
                holder.tvValue5 = view.FindViewById<TextView>(Resource.Id.tvValue5);
                holder.tvValue6 = view.FindViewById<TextView>(Resource.Id.tvValue6);
                holder.tvValue7 = view.FindViewById<TextView>(Resource.Id.tvValue7);
                holder.tvValue8 = view.FindViewById<TextView>(Resource.Id.tvValue8);
                holder.tvValue9 = view.FindViewById<TextView>(Resource.Id.tvValue9);
                holder.tvValue10 = view.FindViewById<TextView>(Resource.Id.tvValue10);
                holder.tvValue11 = view.FindViewById<TextView>(Resource.Id.tvValue11);
                holder.tvValue12 = view.FindViewById<TextView>(Resource.Id.tvValue12);
                holder.tvValue13 = view.FindViewById<TextView>(Resource.Id.tvValue13);
                holder.tvValue14 = view.FindViewById<TextView>(Resource.Id.tvValue14);
                holder.tvValue15 = view.FindViewById<TextView>(Resource.Id.tvValue15);
                holder.tvValue16 = view.FindViewById<TextView>(Resource.Id.tvValue16);
                view.Tag = holder;
            }

            ListViewUnicodesItem item = Items[position];
            holder.tvId.Text = item.Code;
            holder.tvValue1.Text = ListViewUnicodesItem.Value(item.Id);
            holder.tvValue2.Text = ListViewUnicodesItem.Value(item.Id + 1);
            holder.tvValue3.Text = ListViewUnicodesItem.Value(item.Id + 2);
            holder.tvValue4.Text = ListViewUnicodesItem.Value(item.Id + 3);
            holder.tvValue5.Text = ListViewUnicodesItem.Value(item.Id + 4);
            holder.tvValue6.Text = ListViewUnicodesItem.Value(item.Id + 5);
            holder.tvValue7.Text = ListViewUnicodesItem.Value(item.Id + 6);
            holder.tvValue8.Text = ListViewUnicodesItem.Value(item.Id + 7);
            holder.tvValue9.Text = ListViewUnicodesItem.Value(item.Id + 8);
            holder.tvValue10.Text = ListViewUnicodesItem.Value(item.Id + 9);
            holder.tvValue11.Text = ListViewUnicodesItem.Value(item.Id + 10);
            holder.tvValue12.Text = ListViewUnicodesItem.Value(item.Id + 11);
            holder.tvValue13.Text = ListViewUnicodesItem.Value(item.Id + 12);
            holder.tvValue14.Text = ListViewUnicodesItem.Value(item.Id + 13);
            holder.tvValue15.Text = ListViewUnicodesItem.Value(item.Id + 14);
            holder.tvValue16.Text = ListViewUnicodesItem.Value(item.Id + 15);


            return view;
        }

        private void Load()
        {
            var items = new List<ListViewUnicodesItem>();
            for (int x = 32; x < 16 * 16 * 16 * 16; x += 16) items.Add(new ListViewUnicodesItem(x));
            Reset(items);
        }
    }

}