using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.AutoComplete
{
    [Activity(Label = "Tutorial")]
    public class AutoCompleteActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.AutoCompleteActivity;

        #endregion

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var textView = FindViewById<AutoCompleteTextView>(Resource.Id.autocomplete_country);
            textView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.ListCountries, Resources.GetStringArray(Resource.Array.countries));

            #region All Caps

            FindViewById<CheckBox>(Resource.Id.cbAllCaps).CheckedChange += (s, e) =>
            {
                textView.SetAllCaps(e.IsChecked);
            };

            #endregion

        }
    }
}