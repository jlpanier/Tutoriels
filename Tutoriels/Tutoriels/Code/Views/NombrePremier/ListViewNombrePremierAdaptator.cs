using Android.Views;

namespace Tutoriels.Code.Activities
{
    public class ListViewNombrePremierAdaptator : SimpleAdapter<NombrePremier>
    {
        protected override int LayoutResourceId => Resource.Layout.NombrePremierItem;


        public ListViewNombrePremierAdaptator(Activity context) : base(context)
        {
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            ListViewNombrePremierHolder holder = view.Tag as ListViewNombrePremierHolder;

            if (holder == null)
            {
                holder = new ListViewNombrePremierHolder();
                holder.tvIndex = view.FindViewById<TextView>(Resource.Id.tvIndex);
                holder.tvNombre = view.FindViewById<TextView>(Resource.Id.tvNombre);
                holder.tvDuration = view.FindViewById<TextView>(Resource.Id.tvDuration);
                view.Tag = holder;
            }

            NombrePremier item = Items[position];
            holder.tvIndex.Text = item.Index.ToString();
            holder.tvNombre.Text = item.Nombre.ToString();
            holder.tvDuration.Text = item.Duration.ToString(@"hh\:mm\:ss\.ffffff");

            return view;
        }

    }
}