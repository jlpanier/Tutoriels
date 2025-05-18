using Android.Bluetooth;
using Android.Views.InputMethods;
using Java.Util;
using Tutoriels.Code.Activities.Bluetooth;
using Tutoriel;

namespace Tutoriels.Code.Activities
{
    [Activity(Label = "Tutorial")]
    public class BluetoothActivity : BluetoothBaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.BluetoothActivity;

        #endregion

        #region Propriétés

        public override UUID SecureKey => UUID.FromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
        public override UUID InsecureKey => UUID.FromString("8ce255c0-200a-11e0-ac64-0800200c9a66");

        #endregion

        #region Internal variable

        private ListViewDevicesAdaptator _unboundedDevicesAdaptator = null;

        private ListViewDevicesAdaptator _boundedDevicesAdaptator = null;

        /// <summary>
        /// Adapter de la liste des messages 
        /// </summary>
        private ArrayAdapter<String> _conversationArrayAdapter;

        #endregion

        #region life cycle

        /// <summary>
        /// OnCreate est la première méthode à appeler lorsqu’une activité est créée. 
        /// OnCreate est toujours remplacée pour effectuer toutes les initialisations de démarrage qui peuvent être requis par une activité telles que :
        /// - Création de vues
        /// - Initialiser des variables
        /// - Liaison de données statiques aux listes
        /// Aide Windows: https://docs.microsoft.com/fr-fr/xamarin/android/
        /// https://developer.xamarin.com/guides/android/application_fundamentals/activity_lifecycle/
        /// Icon : http://modernuiicons.com/ 
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var lvUnbondedDevices = FindViewById<ListView>(Resource.Id.lvUnbondedDevices);
            lvUnbondedDevices.Adapter = _unboundedDevicesAdaptator = new ListViewDevicesAdaptator(this);
            lvUnbondedDevices.Visibility = Android.Views.ViewStates.Gone;
            lvUnbondedDevices.ItemClick += (s, e) =>
            {
                if (e.Position >= 0)
                {
                    BluetoothConnectUnbond(_unboundedDevicesAdaptator[e.Position].Device);
                }
            };
            FindViewById<TextView>(Resource.Id.tvNoBondedDevices).Visibility = Android.Views.ViewStates.Visible;

            _boundedDevicesAdaptator = new ListViewDevicesAdaptator(this, BluetoothBondedDevices);
            var lvBondedDevices = FindViewById<ListView>(Resource.Id.lvBondedDevices);
            lvBondedDevices.Adapter = _boundedDevicesAdaptator;
            lvBondedDevices.ItemClick += (s, e) =>
            {
                if (e.Position >= 0)
                {
                    BluetoothConnectBond(_boundedDevicesAdaptator[e.Position].Device);
                }
            };
            lvBondedDevices.Visibility = BluetoothBondedDevices.Any() ? Android.Views.ViewStates.Visible : Android.Views.ViewStates.Gone;
            FindViewById<TextView>(Resource.Id.tvNoBondedDevices).Visibility = BluetoothBondedDevices.Any() ? Android.Views.ViewStates.Gone : Android.Views.ViewStates.Visible;
            FindViewById<Button>(Resource.Id.btnScan).Click += (sender, e) =>
            {
                UIStatus(true);
                CancelDiscovery();
                _unboundedDevicesAdaptator.Reset();
                StartDiscovery();
            };

            FindViewById<EditText>(Resource.Id.edit_text_out).EditorAction += (s, e) =>
            {
                if (s is EditText edt && (e.ActionId == ImeAction.Done || e.ActionId == ImeAction.Next))
                {
                    SendBluetoothMessage(edt.Text);
                }
            };
            FindViewById<Button>(Resource.Id.button_send).Click += (sender, e) =>
            {
                SendBluetoothMessage(FindViewById<TextView>(Resource.Id.edit_text_out).Text);
            };

            _conversationArrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.message);
            FindViewById<ListView>(Resource.Id.lvText).Adapter = _conversationArrayAdapter;
        }

        #endregion

        #region bluetooth area

        /// <summary>
        /// Broadcast action bluetooth : remote device discovered
        /// </summary>
        /// <param name="device"></param>
        protected override void OnBluetoothDeviceFound(BluetoothDevice device)
        {
            base.OnBluetoothDeviceFound(device);
            if (!_unboundedDevicesAdaptator.Items.Any(_ => _.Address == device.Address))
            {
                _unboundedDevicesAdaptator.Add(new BluetoothDeviceItem(device));
            }
        }

        /// <summary>
        /// Broadcast action bluetooth : the local bluetooth adapter finished discovery
        /// </summary>
        protected override void OnBluetoothDiscoveryFinished()
        {
            base.OnBluetoothDiscoveryFinished();
            UIStatus(false);
        }

        /// <summary>
        /// Broadcast actionb bluetooth : indicates the bluetooth scan mode of the local adapter has changed
        /// </summary>
        protected override void OnBluetoothScanModeChanged(BluetoothScanModeEventArgs scanmode)
        {
            base.OnBluetoothScanModeChanged(scanmode);
            Message(scanmode.ToString());
        }

        /// <summary>
        /// Bluetooth : Reception message
        /// </summary>
        protected override void OnBluetoothReceive(string message)
        {
            _conversationArrayAdapter.Add($"{ConnectedDevice?.Name}: {message}");
        }

        /// <summary>
        /// Bluetooth : Send message
        /// </summary>
        protected override void OnBluetoothSend(string message)
        {
            _conversationArrayAdapter.Add($"Me: {message}");
        }

        /// <summary>
        /// Bluetooth : Bluetooth change status connexion
        /// </summary>
        protected override void OnBluetoothStatusChanged(BluetoothDevice device, ServiceStates state)
        {
            if (device != null)
            {
                BluetoothDeviceItem item = _boundedDevicesAdaptator.Items.FirstOrDefault(_ => _.Address == device.Address);
                if (item != null)
                {
                    item.State = state;
                    _boundedDevicesAdaptator.NotifyDataSetChanged();
                }
                else
                {
                    item = _unboundedDevicesAdaptator.Items.FirstOrDefault(_ => _.Address == device.Address);
                    if (item != null)
                    {
                        item.State = state;
                        _unboundedDevicesAdaptator.NotifyDataSetChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Bluetooth : send a message to other device
        /// </summary>
        /// <param name="message"></param>
        protected override void SendBluetoothMessage(string message)
        {
            base.SendBluetoothMessage(message);
            FindViewById<EditText>(Resource.Id.edit_text_out).Text = string.Empty;
        }

        #endregion

        #region User Interface

        private void UIStatus(bool processing)
        {
            if (processing)
            {
                FindViewById<ProgressBar>(Resource.Id.pbSearching).Visibility = Android.Views.ViewStates.Visible;
                FindViewById<TextView>(Resource.Id.tvNoUnbondedDevices).Visibility = Android.Views.ViewStates.Gone;
                FindViewById<ListView>(Resource.Id.lvUnbondedDevices).Visibility = Android.Views.ViewStates.Gone;
            }
            else
            {
                FindViewById<ProgressBar>(Resource.Id.pbSearching).Visibility = Android.Views.ViewStates.Gone;
                if (_unboundedDevicesAdaptator.Count > 0)
                {
                    FindViewById<ListView>(Resource.Id.lvUnbondedDevices).Visibility = Android.Views.ViewStates.Visible;
                }
                else
                {
                    FindViewById<TextView>(Resource.Id.tvNoUnbondedDevices).Visibility = Android.Views.ViewStates.Visible;
                }
            }
        }

        #endregion
    }
}