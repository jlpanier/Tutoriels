using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.DatePicker
{
    /// <summary>
    /// https://docs.microsoft.com/fr-fr/xamarin/android/user-interface/controls/pickers/date-picker
    /// </summary>
    [Activity(Label = "Tutorial")]
    public class TimePickerActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.TimePickerActivity;

        #endregion


        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViewById<Button>(Resource.Id.date_select_button).Click += (s, e) =>
            {
                TimePickerFragment frag = TimePickerFragment.NewInstance(OnTimeSelected);
                frag.Show(FragmentManager, "TimePickerFragment");
            };
        }

        private void OnTimeSelected(TimeSpan selected)
        {
            FindViewById<TextView>(Resource.Id.date_display).Text = selected.ToString();
        }
    }
}