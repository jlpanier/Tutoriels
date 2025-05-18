using Android.Bluetooth;
using Android.Util;
using System;
using System.Reflection;
using static Tutoriels.Code.Activities.BluetoothBaseActivity;

namespace Tutoriels.Code.Activities.Bluetooth
{
    /// <summary>
    /// This thread runs while listening for incoming connections. It behaves
    /// like a server-side client. It runs until a connection is accepted
    /// (or until cancelled).
    /// </summary>
    class AcceptThread : Java.Lang.Thread
    {
        private ServiceStates state;

        // The local server socket
        private readonly BluetoothServerSocket serverSocket;

        public event EventHandler<BluetoothConnectionEventArgs>? OnAcquireConnection;

        public AcceptThread(BluetoothServerSocket socket)
        {
            serverSocket = socket;
            state = ServiceStates.Listen;
        }

        public override void Run()
        {
            Name = $"AcceptThread";
            BluetoothSocket socket = null;

            while (state != ServiceStates.Connected)
            {
                try
                {
                    socket = serverSocket.Accept(); // Block until a connection is established.
                }
                catch 
                {
                    break;
                }
                if (socket != null)
                {
                    OnAcquireConnection?.Invoke(this, new BluetoothConnectionEventArgs(socket));
                }
            }
        }

        public void Cancel()
        {
            try
            {
                state = ServiceStates.Disconnected;
                serverSocket.Close();
            }
            catch 
            {
            }
        }
    }


}