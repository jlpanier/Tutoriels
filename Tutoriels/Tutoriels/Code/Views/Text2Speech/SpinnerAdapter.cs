using Android.Views;
using Xamarin.Essentials;

namespace Tutoriels.Code.Activities.Text2Speech
{
    internal class SpinnerAdapter : BaseArrayAdapter<Locale>
    {
        protected static int LayoutResourceId => Resource.Layout.SpinnerText2SpeechLanguageItem;

        public SpinnerAdapter(Activity context, List<Locale> items) : base(context, LayoutResourceId, items)
        {
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (Context is Activity act && view == null)
            {
                view = act.LayoutInflater.Inflate(LayoutResourceId, null);
            }

            SpinnerHolder holder = view.Tag as SpinnerHolder;

            if (holder == null)
            {
                holder = new SpinnerHolder();
                holder.tvName = view.FindViewById<TextView>(Resource.Id.tvName);
                holder.tvCountry = view.FindViewById<TextView>(Resource.Id.tvCountry);
                view.Tag = holder;
            }

            Locale item = GetItem(position);
            holder.tvName.Text = item.Name;
            holder.tvCountry.Text = string.IsNullOrEmpty(item.Country) ? string.Empty : $"({item.Country})";

            return view;
        }

        public override View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            return SetView(position, convertView, parent);
        }

        private View SetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (Context is Activity act && view == null)
            {
                view = act.LayoutInflater.Inflate(LayoutResourceId, null);
            }

            SpinnerHolder holder = view.Tag as SpinnerHolder;

            if (holder == null)
            {
                holder = new SpinnerHolder();
                holder.tvName = view.FindViewById<TextView>(Resource.Id.tvName);
                holder.tvCountry = view.FindViewById<TextView>(Resource.Id.tvCountry);
                view.Tag = holder;
            }

            Locale item = GetItem(position);
            holder.tvName.Text = item.Name;
            holder.tvCountry.Text = string.IsNullOrEmpty(item.Country) ? string.Empty : $"({item.Country})";

            return view;
        }

    }
}