using AndroidX.ViewPager.Widget;

namespace Tutoriels.Code
{
    public abstract class PagerBaseAdapter<T> : PagerAdapter where T : Java.Lang.Object
    {
        public Activity Context { get; private set; }

        public List<T> Items { get; private set; }

        protected PagerBaseAdapter(Activity context)
        {
            Context = context;
            Items = new List<T>();
        }

        public override int GetItemPosition(Java.Lang.Object @object)
        {
            return base.GetItemPosition(@object);
        }

        public override int Count => Items.Count;

        public void Reset(IEnumerable<T> items)
        {
            Items.Clear();
            if (items != null) Items.AddRange(items);
        }

        public void Insert(T item)
        {
            Items.Add(item);
        }
    }

}
