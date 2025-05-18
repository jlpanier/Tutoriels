using Android.Content;

namespace Tutoriels.Code
{
    public abstract class BaseArrayAdapter<T> : ArrayAdapter<T>
    {
        protected BaseArrayAdapter(Context context, int layout) : base(context, layout)
        {
        }

        protected BaseArrayAdapter(Context context, int layout, List<T> items) : base(context, layout, items)
        {
        }

        public override long GetItemId(int position) => position;

        public T this[int position] => GetItem(position);
    }
}
