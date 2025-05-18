using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.DatePicker
{
    /// <summary>
    /// https://docs.microsoft.com/fr-fr/xamarin/android/user-interface/controls/pickers/date-picker
    /// </summary>
    [Activity(Label = "Tutorial")]
    public class DatePickerActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.DatePickerActivity;

        #endregion


        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViewById<Button>(Resource.Id.date_select_button).Click += (s, e) =>
            {
                DatePickerFragment frag = DatePickerFragment.NewInstance(OnDateSelected);
                frag.Show(FragmentManager, "DatePickerFragment");
            };
        }

        private void OnDateSelected(DateTime dateselected)
        {
            FindViewById<TextView>(Resource.Id.date_display).Text = dateselected.ToLongDateString();
        }
    }
}