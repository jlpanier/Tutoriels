using System;

namespace Tutoriels.Code.Activities.Bluetooth
{
    public class BluetoothEventArgs : EventArgs
    {
        public enum TypeMessages { DeviceName, State, Toast, Read, Write }

        public string Message { get; private set; }
        public TypeMessages Type { get; private set; }

        public BluetoothEventArgs(TypeMessages type, string message)
        {
            Message = message;
            Type = type;
        }
    }
}