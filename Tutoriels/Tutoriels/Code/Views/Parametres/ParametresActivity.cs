using Tutoriels.Code.Activities;
using Xamarin.Essentials;

namespace Tutoriels.Code.Activities.Parametres
{
    [Activity(Label = "Tutorial")]
    public class ParametresActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.ParametresActivity;

        #endregion

        #region Life cycle

        private ListViewAdapter _adapter;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FindViewById<ListView>(Resource.Id.ListViewParametres).Adapter = _adapter = new ListViewAdapter(this);
            Load();
        }

        #endregion

        private void Load()
        {
            List<LabelValue> items = new List<LabelValue>();

            items.Add(new LabelValue("DisplayMetrics", LabelValue.TypeValue.Label));
            items.Add(new LabelValue("Density", $"{Resources.DisplayMetrics.Density} dpi {Resources.DisplayMetrics.DensityDpi}"));
            items.Add(new LabelValue("Size", $"{Resources.DisplayMetrics.WidthPixels}x{Resources.DisplayMetrics.HeightPixels}"));
            items.Add(new LabelValue("ScaledDensity", $"{Resources.DisplayMetrics.ScaledDensity}"));
            items.Add(new LabelValue("Xdpi", $"{Resources.DisplayMetrics.Xdpi}"));
            items.Add(new LabelValue("Ydpi", $"{Resources.DisplayMetrics.Ydpi}"));

            items.Add(new LabelValue("Configuration", LabelValue.TypeValue.Label));
            items.Add(new LabelValue("DensityDpi", $"{Resources.Configuration.DensityDpi.ToString()}"));
            items.Add(new LabelValue("DescribeContents", $"{Resources.Configuration.DescribeContents()}"));

            items.Add(new LabelValue("Locale", LabelValue.TypeValue.Label));
            items.Add(new LabelValue("Country", $"{Resources.Configuration.Locale.Country}"));
            items.Add(new LabelValue("DisplayCountry", $"{Resources.Configuration.Locale.DisplayCountry}"));
            items.Add(new LabelValue("DisplayLanguage", $"{Resources.Configuration.Locale.DisplayLanguage}"));
            items.Add(new LabelValue("DisplayName", $"{Resources.Configuration.Locale.DisplayName}"));
            items.Add(new LabelValue("DisplayScript", $"{Resources.Configuration.Locale.DisplayScript}"));
            items.Add(new LabelValue("DisplayVariant", $"{Resources.Configuration.Locale.DisplayVariant}"));
            items.Add(new LabelValue("Language", $"{Resources.Configuration.Locale.Language}"));
            items.Add(new LabelValue("Script", $"{Resources.Configuration.Locale.Script}"));

            items.Add(new LabelValue("Connectivity", LabelValue.TypeValue.Label));

            foreach (var item in Connectivity.ConnectionProfiles)
            {
                items.Add(new LabelValue("Profiles", item.ToString()));
            }
            items.Add(new LabelValue("Connexion", Connectivity.NetworkAccess.ToString()));



            _adapter.Reset(items);
        }
    }
}