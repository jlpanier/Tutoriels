using Android.Views;
using Common;
using Tutoriels.Code.Activities.CRRBluetooth;
using static Tutoriels.Code.Activities.CRRBluetooth.CRRMessage;

namespace Tutoriels.Code.Activities.Bluetooth
{
    class SpinnerDialogAdapter : ArrayAdapter<TypesMessages>
    {
        protected static int LayoutResourceId = Resource.Layout.SpinnerDialogItem;

        public List<TypesMessages> Items { get; private set; }

        public SpinnerDialogAdapter(Activity context, IEnumerable<TypesMessages> items) : base(context, LayoutResourceId)
        {
            Items = new List<TypesMessages>();
            Reset(items);
        }

        public SpinnerDialogAdapter(Activity context) : base(context, LayoutResourceId)
        {
            Items = new List<TypesMessages>();
        }

        public override long GetItemId(int position) => position;

        public TypesMessages this[int position] => Items[position];

        public override int Count => Items.Count;

        public void Reset(IEnumerable<TypesMessages> items = null)
        {
            Items.Clear();
            if (items != null) Items.AddRange(items);
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (Context is Activity act && view == null)
            {
                view = act.LayoutInflater.Inflate(LayoutResourceId, null);
            }

            SpinnerDialogHolder holder = view.Tag as SpinnerDialogHolder;

            if (holder == null)
            {
                holder = new SpinnerDialogHolder();
                holder.tvLibelle = view.FindViewById<TextView>(Resource.Id.tvLibelle);
                view.Tag = holder;
            }

            TypesMessages item = Items[position];
            holder.Position = position;
            holder.tvLibelle.Text = item.GetStringValue();

            return view;
        }

        public override View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (Context is Activity act && view == null)
            {
                view = act.LayoutInflater.Inflate(LayoutResourceId, null);
            }

            SpinnerDialogHolder holder = view.Tag as SpinnerDialogHolder;

            if (holder == null)
            {
                holder = new SpinnerDialogHolder();
                holder.tvLibelle = view.FindViewById<TextView>(Resource.Id.tvLibelle);
                view.Tag = holder;
            }

            TypesMessages item = Items[position];
            holder.Position = position;
            holder.tvLibelle.Text = item.GetStringValue();

            return view;
        }

    }
}