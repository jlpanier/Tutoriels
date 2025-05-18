using Android.Bluetooth;
using Android.Views;
using static Tutoriels.Code.Activities.BluetoothBaseActivity;

namespace Tutoriels.Code.Activities.Bluetooth
{
    class ListViewDevicesAdaptator : SimpleAdapter<BluetoothDeviceItem>
    {
        protected override int LayoutResourceId => Resource.Layout.ListViewDevices;

        public ListViewDevicesAdaptator(Activity context, IEnumerable<BluetoothDevice> devices) : base(context)
        {
            var items = new List<BluetoothDeviceItem>();
            foreach (BluetoothDevice device in devices)
            {
                items.Add(new BluetoothDeviceItem(device));
            }
            Reset(items);
        }

        public ListViewDevicesAdaptator(Activity context, IEnumerable<BluetoothDeviceItem> devices) : base(context)
        {
            Reset(devices);
        }

        public ListViewDevicesAdaptator(Activity context) : base(context)
        {
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View? view = convertView;
            view ??= Context.LayoutInflater.Inflate(LayoutResourceId, null);
            System.Diagnostics.Debug.Assert(view != null);
            System.Diagnostics.Debug.Assert(view.Tag != null);


            if (view.Tag is not ListViewDevicesHolder holder)
            {
                holder = new ListViewDevicesHolder
                {
                    imgConnection = view.FindViewById<ImageView>(Resource.Id.imgConnection),
                    tvName = view.FindViewById<TextView>(Resource.Id.tvName),
                    tvAddress = view.FindViewById<TextView>(Resource.Id.tvAddress),
                    tvBondState = view.FindViewById<TextView>(Resource.Id.tvBondState),
                    tvType = view.FindViewById<TextView>(Resource.Id.tvType)
                };
                view.Tag = holder;
            }

            BluetoothDeviceItem item = Items[position];
            holder.Position = position;
            switch (item.State)
            {
                case ServiceStates.Disconnected:
                    holder.imgConnection.SetBackgroundResource(Resource.Drawable.disconnected);
                    break;
                case ServiceStates.Listen:
                case ServiceStates.Connecting:
                    holder.imgConnection.SetBackgroundResource(Resource.Drawable.connecting);
                    break;
                case ServiceStates.Connected:
                    holder.imgConnection.SetBackgroundResource(Resource.Drawable.connected);
                    break;
            }
            holder.tvName.Text = item.Name;
            holder.tvAddress.Text = string.IsNullOrEmpty(item.Address) ? "None" : item.Address;
            holder.tvBondState.Text = item.BondState == Bond.None ? "None" : item.BondState.ToString();
            holder.tvType.Text = item.Device.Type switch
            {
                BluetoothDeviceType.Classic => "Classic",
                BluetoothDeviceType.Dual => "Dual",
                BluetoothDeviceType.Le => "Le",
                BluetoothDeviceType.Unknown => "Unknown",
                _ => "???",
            };
            return view;
        }
    }
}