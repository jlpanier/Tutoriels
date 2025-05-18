using Android.Bluetooth;
using Android.Util;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using static Tutoriels.Code.Activities.BluetoothBaseActivity;

namespace Tutoriels.Code.Activities.Bluetooth
{
    /// <summary>
    /// This thread runs during a connection with a remote device.
    /// It handles all incoming and outgoing transmissions.
    /// </summary>
    class ConnectedThread : Java.Lang.Thread
    {
        /// <summary>
        /// Message échanger entre les deux devices
        /// </summary>
        public event EventHandler<BluetoothEventArgs>? MessageHandler;

        public event EventHandler? LostConnecion;


        private readonly BluetoothSocket socket;
        private readonly Stream? inStream;
        private readonly Stream? outStream;

        private ServiceStates state = ServiceStates.Connected;

        public ConnectedThread(BluetoothSocket socket)
        {
            this.socket = socket;
            Stream? tmpIn = null;
            Stream? tmpOut = null;

            // Get the BluetoothSocket input and output streams
            try
            {
                tmpIn = socket.InputStream;
                tmpOut = socket.OutputStream;
            }
            catch 
            {
                // Nothing
            }

            inStream = tmpIn;
            outStream = tmpOut;
        }

        public override void Run()
        {
            byte[] buffer = new byte[1024];
            int bytes;

            while (state == ServiceStates.Connected && socket.IsConnected)
            {
                try
                {
                    bytes = inStream.Read(buffer, 0, buffer.Length);
                    MessageHandler?.Invoke(this, new BluetoothEventArgs(BluetoothEventArgs.TypeMessages.Read, Encoding.ASCII.GetString(buffer, 0, bytes)));
                }
                catch 
                {
                    LostConnecion?.Invoke(this, EventArgs.Empty);
                    break;
                }
            }
        }

        /// <summary>
        /// Write to the connected OutStream.
        /// </summary>
        /// <param name='message'>The bytes to write</param>
        public void Write(string message)
        {
            try
            {
                if (socket.IsConnected)
                {
                    byte[] outbuffer = Encoding.ASCII.GetBytes(message);
                    outStream.Write(outbuffer, 0, outbuffer.Length);

                    // Share the sent message back to the UI Activity
                    MessageHandler?.Invoke(this, new BluetoothEventArgs(BluetoothEventArgs.TypeMessages.Write, message));
                }
            }
            catch 
            {
                // Nothing
            }
        }

        public void Cancel()
        {
            try
            {
                state = ServiceStates.Disconnected;
                socket.Close();
            }
            catch 
            {
                // Nothing
            }
        }
    }
}