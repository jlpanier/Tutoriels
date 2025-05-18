using System.Reflection;

namespace Tutoriels.Code
{
    public abstract class SimpleAdapter<T> : BaseAdapter<T>
    {
        #region Overall

        /// <summary>
        /// Layout de nos items
        /// </summary>
        protected virtual int LayoutResourceId { get; }

        #endregion

        public Activity Context { get; private set; }

        public List<T> Items { get; private set; }

        protected SimpleAdapter(Activity context)
        {
            Context = context;
            Items = new List<T>();
        }

        public override long GetItemId(int position) => position;

        public override T this[int position] => Items[position];

        public override int Count => Items.Count;

        public void Reset(IEnumerable<T> items = null)
        {
            Items.Clear();
            if (items != null) Items.AddRange(items);
        }

        public void Add(T item)
        {
            Items.Add(item);
        }
    }
}
