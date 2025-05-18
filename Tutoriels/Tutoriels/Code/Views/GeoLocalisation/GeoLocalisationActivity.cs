using Android.Locations;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.GeoLocalisation
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/xamarin/android/platform/maps-and-location/location
    /// </summary>
    [Activity(Label = "Tutorial")]
    public class GeoLocalisationActivity : BaseActivity, ILocationListener
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.GeoLocalisationActivity;

        #endregion

        #region Internal Variable

        private ListViewLocalisationAdapter _adapter;

        #endregion

        #region life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViewById<ListView>(Resource.Id.lvLocalisation).Adapter = _adapter = new ListViewLocalisationAdapter(this);


            FindViewById<RadioButton>(Resource.Id.radioBest).Checked = true;

            LocationManager locationManager = (LocationManager)GetSystemService(Android.Content.Context.LocationService);
            if (locationManager != null)
            {
                Criteria locationCriteria = new Criteria();
                locationCriteria.Accuracy = Accuracy.Coarse;
                locationCriteria.PowerRequirement = Power.NoRequirement;
                ChangeLocationUpdates(locationManager.GetBestProvider(locationCriteria, true));
            }

            FindViewById<RadioButton>(Resource.Id.radioBest).CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    Criteria locationCriteria = new Criteria();
                    locationCriteria.Accuracy = Accuracy.Coarse;
                    locationCriteria.PowerRequirement = Power.NoRequirement;
                    ChangeLocationUpdates(locationManager.GetBestProvider(locationCriteria, true));
                }
            };
            FindViewById<RadioButton>(Resource.Id.radioGpsProvider).CheckedChange += (s, e) => { if (e.IsChecked) ChangeLocationUpdates(LocationManager.GpsProvider); };
            FindViewById<RadioButton>(Resource.Id.radioNetworkProvider).CheckedChange += (s, e) => { if (e.IsChecked) ChangeLocationUpdates(LocationManager.NetworkProvider); };
            FindViewById<RadioButton>(Resource.Id.radioPassiveProvider).CheckedChange += (s, e) => { if (e.IsChecked) ChangeLocationUpdates(LocationManager.PassiveProvider); };
        }

        #endregion

        #region Géolocalisation

        private void ChangeLocationUpdates(string provider)
        {
            LocationManager locationManager = (LocationManager)GetSystemService(Android.Content.Context.LocationService);
            if (locationManager != null)
            {
                long minTime = 10000; // 2 sec.
                long mindistance = 0;
                try
                {
                    requestprovider = provider;
                    locationManager.RequestLocationUpdates(provider, minTime, mindistance, this);

                    _adapter.Add(new LocalisationItem(requestprovider, $"ChangeLocationUpdates"));
                    _adapter.NotifyDataSetChanged();
                }
                catch (Exception ex)
                {
                    Message(ex.Message);
                }
            }
        }
        private string requestprovider = "";

        public void OnLocationChanged(Location location)
        {
            _adapter.Add(new LocalisationItem(requestprovider, location, "LocationChanged"));
            _adapter.NotifyDataSetChanged();
        }

        public void OnProviderDisabled(string locationProvider)
        {
            _adapter.Add(new LocalisationItem(requestprovider, $"ProviderDisabled => {locationProvider}"));
            _adapter.NotifyDataSetChanged();
        }

        public void OnProviderEnabled(string locationProvider)
        {
            _adapter.Add(new LocalisationItem(requestprovider, $"ProviderEnabled => {locationProvider}"));
            _adapter.NotifyDataSetChanged();
        }

        public void OnStatusChanged(string locationProvider, Availability status, Bundle extras)
        {
            _adapter.Add(new LocalisationItem(requestprovider, $"StatusChanged => {locationProvider} statut {status}"));
            _adapter.NotifyDataSetChanged();
        }

        #endregion    
    }
}