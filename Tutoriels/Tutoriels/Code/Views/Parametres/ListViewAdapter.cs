using Android.Views;

namespace Tutoriels.Code.Activities.Parametres
{
    internal class ListViewAdapter : SimpleAdapter<LabelValue>
    {
        protected override int LayoutResourceId => Resource.Layout.ListViewParametreItem;

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
                holder.tvTitre = view.FindViewById<TextView>(Resource.Id.tvTitre);
                holder.tvLabel = view.FindViewById<TextView>(Resource.Id.tvLabel);
                holder.tvValue = view.FindViewById<TextView>(Resource.Id.tvValue);
                view.Tag = holder;
            }

            LabelValue item = Items[position];
            switch (item.Type)
            {
                case LabelValue.TypeValue.Titre:
                case LabelValue.TypeValue.SousTitre:
                case LabelValue.TypeValue.Label:
                    holder.tvTitre.Visibility = ViewStates.Visible;
                    holder.tvLabel.Visibility = ViewStates.Gone;
                    holder.tvValue.Visibility = ViewStates.Gone;
                    holder.tvTitre.Text = item.Label;
                    holder.tvLabel.Text = item.Label;
                    holder.tvValue.Text = item.Valeur;
                    break;
                case LabelValue.TypeValue.Valeur:
                    holder.tvTitre.Visibility = ViewStates.Gone;
                    holder.tvLabel.Visibility = ViewStates.Visible;
                    holder.tvValue.Visibility = ViewStates.Visible;
                    holder.tvTitre.Text = item.Label;
                    holder.tvLabel.Text = item.Label;
                    holder.tvValue.Text = item.Valeur;
                    break;
            }
            return view;
        }

    }
}