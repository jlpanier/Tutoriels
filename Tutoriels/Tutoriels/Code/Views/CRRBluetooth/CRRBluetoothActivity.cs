using Android.Bluetooth;
using Common;
using Java.Util;
using Tutoriels.Code.Activities.Bluetooth;
using static Tutoriels.Code.Activities.CRRBluetooth.CRRMessage;

namespace Tutoriels.Code.Activities.CRRBluetooth
{
    [Activity(Label = "Tutorial")]
    public class AlphaBluetoothActivity : BluetoothBaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.CRRBluetoothActivity;

        #endregion

        #region Propriétés

        public override UUID SecureKey => UUID.FromString("2261288f-4087-4a2f-b105-7bf51fb2702f");
        public override UUID InsecureKey => UUID.FromString("edde1b91-1948-4bee-96cf-dbe5f4dbe3ff");

        #endregion

        #region CRR

        #endregion

        #region Internal variable

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

            List<TypesMessages> items = new List<TypesMessages>();
            foreach (TypesMessages item in Enum.GetValues(typeof(TypesMessages)))
            {
                items.Add(item);
            }
            var dialogAdaptor = new SpinnerDialogAdapter(this, items);

            Spinner sp = FindViewById<Spinner>(Resource.Id.spTypeMessage);
            dialogAdaptor.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp.Adapter = dialogAdaptor;
            sp.ItemSelected += (s, e) =>
            {
                SendBluetoothMessage(dialogAdaptor[e.Position].GetCodeValue());
            };

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
            FindViewById<Button>(Resource.Id.btnStart).Click += (s, e) =>
            {
                SendBluetoothMessage(dialogAdaptor[sp.SelectedItemPosition].GetCodeValue());
            };

            _conversationArrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.message);
            FindViewById<ListView>(Resource.Id.lvText).Adapter = _conversationArrayAdapter;
        }

        #endregion

        #region bluetooth area

        /// <summary>
        /// Bluetooth : Reception message
        /// </summary>
        protected override void OnBluetoothReceive(string message)
        {
            CRRMessages codereception = CRRMessage.Parse(message);
            CRRMessage reception = new CRRMessage(codereception);
            CRRMessages codenext = reception.Next();
            if (codenext != CRRMessages.None)
            {
                SendBluetoothMessage(codenext.GetCodeValue());
            }
            _conversationArrayAdapter.Add($"{ConnectedDevice?.Name}: {codereception.GetStringValue()}");

        }

        /// <summary>
        /// Bluetooth : Send message
        /// </summary>
        protected override void OnBluetoothSend(string message)
        {
            CRRMessages codereception = CRRMessage.Parse(message);
            _conversationArrayAdapter.Add($"Me: {codereception.GetStringValue()}");
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
            }
        }

        #endregion
    }
}