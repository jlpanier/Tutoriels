using Tutoriel;

namespace Tutoriels.Code.Activities.DatePicker
{
    /// <summary>
    /// https://docs.microsoft.com/fr-fr/xamarin/android/user-interface/controls/pickers/date-picker
    /// </summary>
    public class DatePickerFragment : DialogFragment, DatePickerDialog.IOnDateSetListener
    {
        private Action<DateTime> _dateSelectedHandler;

        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            DatePickerFragment frag = new DatePickerFragment();
            frag._dateSelectedHandler = onDateSelected;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = DateTime.Now;
            DatePickerDialog dialog = new DatePickerDialog(Activity, this, currently.Year, currently.Month - 1, currently.Day);
            dialog.SetTitle("Chosir une date");
            dialog.SetMessage("Date for tutorial");
            dialog.SetIcon(Resource.Drawable.Sarthe);

            return dialog;
        }

        public void OnDateSet(DatePickerDialog view, int year, int monthOfYear, int dayOfMonth)
        {
            _dateSelectedHandler(new DateTime(year, monthOfYear + 1, dayOfMonth));
        }

        public void OnDateSet(Android.Widget.DatePicker view, int year, int month, int dayOfMonth)
        {
            _dateSelectedHandler(new DateTime(year, month + 1, dayOfMonth));
        }
    }

}