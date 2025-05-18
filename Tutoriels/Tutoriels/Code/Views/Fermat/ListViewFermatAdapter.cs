using Android.Views;

namespace Tutoriels.Code.Activities.Fermat
{
    public class ListViewFermatAdapter : SimpleAdapter<FermatItem>
    {
        protected override int LayoutResourceId => Resource.Layout.FermatItem;


        public ListViewFermatAdapter(Activity context) : base(context)
        {
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            ListViewFermatHolder holder = view.Tag as ListViewFermatHolder;

            if (holder == null)
            {
                holder = new ListViewFermatHolder();
                holder.tvDuration = view.FindViewById<TextView>(Resource.Id.tvDuration);
                holder.tvA = view.FindViewById<TextView>(Resource.Id.tvA);
                holder.tvB = view.FindViewById<TextView>(Resource.Id.tvB);
                holder.tvC = view.FindViewById<TextView>(Resource.Id.tvC);
                view.Tag = holder;
            }

            FermatItem item = Items[position];
            holder.tvA.Text = item.A.ToString();
            holder.tvB.Text = item.B.ToString();
            holder.tvC.Text = item.C.ToString();
            holder.tvDuration.Text = item.Duration.ToString(@"hh\:mm\:ss\.ffffff");

            return view;
        }

        public void Add(long a, long b, long c, TimeSpan ts) => Add(new FermatItem(a, b, c, ts));
    }
}