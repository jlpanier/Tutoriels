using Android.Text;
using Java.Lang;

namespace Tutoriels.Code.Activities.Canvas
{
    public class IntegerDigitInputFilter : Java.Lang.Object, IInputFilter
    {
        private int _min = 0;
        private int _max = 0;

        public IntegerDigitInputFilter(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public ICharSequence FilterFormatted(ICharSequence source, int start, int end, ISpanned dest, int dstart, int dend)
        {
            string val = dest.ToString().Insert(dstart, source.ToString());
            if (int.TryParse(val, out int input) && IsInRange(input))
            {
                return null;
            }
            return new Java.Lang.String(string.Empty);
        }

        private bool IsInRange(int input)
        {
            return _max > _min ? input >= _min && input <= _max : input >= _max && input <= _min;
        }
    }
}