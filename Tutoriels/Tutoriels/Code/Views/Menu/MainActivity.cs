using Android.Content;
using Android.Locations;
using Android.Views;
using Common;
using Tutoriels.Code.Activities.Menu;

namespace Tutoriels.Code.Activities
{
    [Activity(Label = "Tutorial", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity, ILocationListener
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.Main;

        #endregion

        private LocationManager _locationManager;

        private MenuItemAdapter _adapter;

        #region Life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ListView lvTutorials = FindViewById<ListView>(Resource.Id.lvTutorials);
            lvTutorials.Adapter = _adapter = new MenuItemAdapter(this);

            // populate the listview with data
            lvTutorials.ItemClick += OnItemClick;
            lvTutorials.FastScrollEnabled = true;
            lvTutorials.ChoiceMode = ChoiceMode.Single;

            Button showPopupMenu = FindViewById<Button>(Resource.Id.popupButton);

            showPopupMenu.Click += (s, e) =>
            {

                PopupMenu menu = new PopupMenu(this, showPopupMenu);

                // with Android 4 Inflate can be called directly on the menu
                menu.Inflate(Resource.Menu.popup_menu);

                menu.MenuItemClick += (s1, arg1) =>
                {
                    Toast.MakeText(this, String.Format("{0} selected", arg1.Item.TitleFormatted), Android.Widget.ToastLength.Short).Show();
                };

                // Android 4 now has the DismissEvent
                menu.DismissEvent += (s2, arg2) =>
                {
                    Toast.MakeText(this, String.Format("menu dismissed"), Android.Widget.ToastLength.Short).Show();
                };

                menu.Show();
            };

            _locationManager = GetSystemService(Context.LocationService) as LocationManager;
        }

        protected override void OnResume()
        {
            base.OnResume();
            try
            {
                Criteria locationCriteria = new Criteria();

                locationCriteria.Accuracy = Accuracy.Coarse;
                locationCriteria.PowerRequirement = Power.NoRequirement;

                var locationProvider = _locationManager.GetBestProvider(locationCriteria, true);

                if (locationProvider != null)
                {
                    // Request location update every 2 sec or if change more than 1 meter
                    _locationManager.RequestLocationUpdates(locationProvider, 2000, 1, this);
                }
                else
                {
                    Toast.MakeText(this, String.Format("No location providers available"), ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }

        #endregion

        #region User Interface

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            MenuTutorial item = _adapter[e.Position];
            Type typeActivity = item.Menu.GetTypeValue();
            if (typeActivity != null)
            {
                var intent = new Intent(this.ApplicationContext, typeActivity);
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);
            }
        }

        #endregion

        #region menu

        /// <Docs>The options menu in which you place your items.</Docs>
        /// <returns>To be added.</returns>
        /// <summary>
        /// Android calls the OnCreateOptionsMenu method so that the app can specify the menu resource for an activity. 
        /// In this method, the top_menus.xml resource is inflated into the passed menu. 
        /// This code causes the new Edit, Save, and Preferences menu items to appear in the Toolbar. 
        /// </summary>
        /// <param name="menu">Menu.</param>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // Lot's of icon https://material.io/icons/#ic_accessibility
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        /// <Docs>The options menu in which you place your items.</Docs>
		/// <returns>To be added.</returns>
		/// <summary>
        ///         When a user taps a menu item, Android calls the OnOptionsItemSelected method and passes in the menu item that was selected.
        ///         In this example, the implementation just displays a toast to indicate which menu item was tapped.
        /// </summary>
		/// <param name="menu">Menu.</param>

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }

        #endregion

        #region Locationn GPS

        public void OnProviderEnabled(string provider)
        {
            Android.Widget.Toast.MakeText(this, String.Format("OnProviderEnabled is enable {0}", provider), Android.Widget.ToastLength.Short).Show();
        }

        public void OnProviderDisabled(string provider)
        {
            Android.Widget.Toast.MakeText(this, String.Format("OnProviderEnabled is disabled {0}", provider), Android.Widget.ToastLength.Short).Show();
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            Android.Widget.Toast.MakeText(this, String.Format("OnStatusChanged {0} {1}", provider, status), Android.Widget.ToastLength.Short).Show();
        }

        public void OnLocationChanged(Android.Locations.Location location)
        {
            Android.Widget.Toast.MakeText(this, String.Format("OnLocationChanged Lat {0} Long. {1}", location.Latitude, location.Longitude), Android.Widget.ToastLength.Short).Show();
        }

        #endregion
    }
}

