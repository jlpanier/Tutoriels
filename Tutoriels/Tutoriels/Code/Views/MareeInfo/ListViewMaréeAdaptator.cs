using Android.Views;

namespace Tutoriels.Code.Activities.MareeInfo
{
    public class ListViewMaréeAdaptator : SimpleAdapter<DataInfoMarée>
    {
        protected override int LayoutResourceId => Resource.Layout.MareeInfoItem;


        public ListViewMaréeAdaptator(Activity context) : base(context)
        {
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            ListViewMaréeHolder holder = view.Tag as ListViewMaréeHolder;

            if (holder == null)
            {
                holder = new ListViewMaréeHolder();
                holder.tvCoefficient = view.FindViewById<TextView>(Resource.Id.tvCoefficient);
                holder.tvDate = view.FindViewById<TextView>(Resource.Id.tvDate);
                holder.tvHauteur = view.FindViewById<TextView>(Resource.Id.tvHauteur);
                view.Tag = holder;
            }

            DataInfoMarée item = Items[position];
            holder.tvCoefficient.Text = item.Coefficient.ToString();
            holder.tvDate.Text = item.Horaire.ToString();
            holder.tvHauteur.Text = $"{item.Hauteur.ToString()} m";

            return view;
        }

    }
}