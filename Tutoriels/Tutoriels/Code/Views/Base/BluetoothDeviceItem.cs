using Android.Bluetooth;
using static Tutoriels.Code.Activities.BluetoothBaseActivity;

namespace Tutoriels.Code.Activities.Bluetooth
{
    internal class BluetoothDeviceItem
    {
        public BluetoothDevice Device;

        public string Name => Device?.Name;

        public string Address => Device?.Address;

        public Bond BondState => Device == null ? Bond.None : Device.BondState;

        public ServiceStates State;

        public BluetoothDeviceItem(BluetoothDevice device)
        {
            Device = device;
            State = ServiceStates.Disconnected;
        }

        public BluetoothDeviceItem()
        {
            Device = null;
            State = ServiceStates.Disconnected;
        }
    }
}