using Tutoriel;

namespace Tutoriels.Code.Activities.DatePicker
{
    public class TimePickerFragment : DialogFragment, TimePickerDialog.IOnTimeSetListener
    {
        private Action<TimeSpan> TimeSelectedHandler;

        public static TimePickerFragment NewInstance(Action<TimeSpan> onTimeSelected)
        {
            var f = new TimePickerFragment();
            f.TimeSelectedHandler = onTimeSelected;
            return f;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = DateTime.Now;
            TimePickerDialog dialog = new TimePickerDialog(Activity, Resource.Style.Theme_Material, this, currently.Hour, currently.Minute, true);
            dialog.SetTitle("Chosir un temps");
            dialog.SetMessage("Time for tutorial");
            dialog.SetIcon(Resource.Drawable.Sarthe);

            return dialog;
        }

        public void OnTimeSet(TimePicker view, int hourOfDay, int minute)
        {
            TimeSelectedHandler(new TimeSpan(hourOfDay, minute, 0));
        }

    }

}