using Android.Bluetooth;
using Android.Content;
using System;

namespace Tutoriels.Code.Activities.Bluetooth
{
    public class BluetoothBroadcastReceiver : BroadcastReceiver
    {
        public event EventHandler<BluetoothScanModeEventArgs>? BluetoothScanModeChanged;

        public event EventHandler<BluetoothDevice>? BluetoothDeviceFound;

        public event EventHandler? BluetoothDiscoveryFinished;

        public BluetoothBroadcastReceiver()
        {
        }

        public override void OnReceive(Context? context, Intent? intent)
        {
            System.Diagnostics.Debug.Assert(intent != null);

            string? action = intent.Action;

            if (action == BluetoothDevice.ActionFound)
            {
                if (intent.GetParcelableExtra(BluetoothDevice.ExtraDevice) is BluetoothDevice device) 
                {
                    BluetoothDeviceFound?.Invoke(this, device);
                }
            }
            else if (action == BluetoothAdapter.ActionDiscoveryFinished)
            {
                BluetoothDiscoveryFinished?.Invoke(this, EventArgs.Empty);
            }
            else if (action == BluetoothAdapter.ActionScanModeChanged)
            {
                BluetoothScanModeChanged?.Invoke(this, new BluetoothScanModeEventArgs()
                {
                    ScanMode = (ScanMode)intent.GetIntExtra(BluetoothAdapter.ExtraScanMode, -1),
                    ConnectionState = intent.GetStringExtra(BluetoothAdapter.ExtraConnectionState),
                    DiscoverableDuration = intent.GetStringExtra(BluetoothAdapter.ExtraDiscoverableDuration),
                    LocalName = intent.GetStringExtra(BluetoothAdapter.ExtraLocalName),
                    PreviousConnectionState = intent.GetStringExtra(BluetoothAdapter.ExtraPreviousConnectionState),
                    PreviousScanMode = intent.GetStringExtra(BluetoothAdapter.ExtraPreviousScanMode),
                    PreviousState = intent.GetStringExtra(BluetoothAdapter.ExtraPreviousState),
                    State = intent.GetStringExtra(BluetoothAdapter.ExtraState),
                });
            }
        }
    }

}