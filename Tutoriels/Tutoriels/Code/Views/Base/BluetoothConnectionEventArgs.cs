﻿using Android.Bluetooth;
using System;

namespace Tutoriels.Code.Activities.Bluetooth
{
    public class BluetoothConnectionEventArgs : EventArgs
    {
        public enum BluetoothConnectionStatus { Failed, Connected }

        public BluetoothConnectionStatus Status { get; private set; }

        public BluetoothSocket Socket { get; private set; }

        public BluetoothConnectionEventArgs(BluetoothSocket socket, BluetoothConnectionStatus status)
        {
            Socket = socket;
            Status = status;
        }

        public BluetoothConnectionEventArgs(BluetoothSocket socket)
        {
            Socket = socket;
            Status = socket != null && socket.IsConnected ? BluetoothConnectionEventArgs.BluetoothConnectionStatus.Connected : BluetoothConnectionEventArgs.BluetoothConnectionStatus.Failed;
        }

        public BluetoothConnectionEventArgs()
        {
            Socket = null;
            Status = BluetoothConnectionEventArgs.BluetoothConnectionStatus.Failed;
        }
    }
}