using Android;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Repository.Dbo;
using static Tutoriels.Code.BaseActivity;

namespace Tutoriels.Code.Activities
{
    [Activity(Label = "Tutorial", MainLauncher = true, Icon = "@drawable/icon", NoHistory = true)]
    public class SplashScreenActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.SplashScreen;

        #endregion

        private static List<string> Permissions = new List<string>()
        {
            Android.Manifest.Permission.WriteExternalStorage,
            Android.Manifest.Permission.ReadExternalStorage,
            Android.Manifest.Permission.AccessNetworkState,
            Android.Manifest.Permission.AccessWifiState,
            Android.Manifest.Permission.AccessCoarseLocation,
            Android.Manifest.Permission.AccessFineLocation,
            Android.Manifest.Permission.AccessNotificationPolicy,
        };

        private static List<string> PermissionsAndroid14 = new List<string>()
        {
            Android.Manifest.Permission.Bluetooth,
            Android.Manifest.Permission.BluetoothConnect,
            Android.Manifest.Permission.BluetoothScan,
            Android.Manifest.Permission.AccessNetworkState,
            Android.Manifest.Permission.AccessWifiState,
            Android.Manifest.Permission.AccessCoarseLocation,
            Android.Manifest.Permission.AccessFineLocation,
            Android.Manifest.Permission.AccessNotificationPolicy,
        };

        #region Life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViewById<TextView>(Resource.Id.txtLabel).Text = "Permissions...";
            FindViewById<TextView>(Resource.Id.txtAppVersion).Text = $"Version {PackageManager.GetPackageInfo(PackageName, 0).VersionName}";
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { Startup(); });
            startupWork.Start();
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            switch (requestCode)
            {
                case RequestCode.Permissions:
                    Startup();
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Demande les permissions, crée les répertoires nécessaires à l'applicationet et la base de données 
        /// </summary>
        public void Startup()
        {

            if (RequestPermissions().Any())
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.S)
                {
                    var demandes = RequestPermissions();
                    if (demandes.Any())
                    {
                        AndroidX.Core.App.ActivityCompat.RequestPermissions(this, new string[1] { demandes.First() }, RequestCode.Permissions);
                    }
                }
                else
                {
                    RequestPermissions(RequestPermissions().ToArray(), RequestCode.Permissions);
                }
            }
            else
            {
                StartApplication();
            }
        }

        private List<string> RequestPermissions()
        {
            List<string> demandes = new List<string>();
            var permissions = Build.VERSION.SdkInt >= BuildVersionCodes.S ? PermissionsAndroid14 : Permissions;
            foreach (var permission in permissions)
            {
                if (CheckSelfPermission(permission) != Permission.Granted)
                {
                    demandes.Add(permission);
                }
            }
            return demandes;
        }

        private void StartApplication()
        {
            string projectname = Application.Context.GetString(Resource.String.Project);
            Setup.Init(Assets, projectname);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}

