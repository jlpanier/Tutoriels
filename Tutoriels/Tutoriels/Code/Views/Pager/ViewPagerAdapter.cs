using Android.Views;
using Java.Lang;

namespace Tutoriels.Code.Activities.Pager
{
    // https://stacklima.com/viewpager-utilisant-des-fragments-dans-android-avec-un-exemple/
    internal class ViewPagerAdapter : PagerBaseAdapter<PagerItem>
    {
        public ViewPagerAdapter(Activity context):base(context)
        {
        }

        public override int Count => 3;

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View? view = null;
            try
            {
                switch (position)
                {
                    case 0:
                        view = container.FindViewById<ImageView>(Resource.Id.tvItem1);
                        break;
                    case 1:
                        view = container.FindViewById<ImageView>(Resource.Id.tvItem2);
                        break;
                    case 2:
                        view = container.FindViewById<ImageView>(Resource.Id.tvItem3);
                        break;
                    case 3:
                        view = container.FindViewById<ImageView>(Resource.Id.tvItem4);
                        break;
                    default:
                        view = container.FindViewById<ImageView>(Resource.Id.tvItem5);
                        break;
                }
            }
            catch(System.Exception ex)
            {
                // Nothing
            }
            return view;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            base.DestroyItem(container, position, @object);
            container.RemoveView((View)@object);
        }

        public override ICharSequence? GetPageTitleFormatted(int position)
        {
            return base.GetPageTitleFormatted(position);
        }

        public override int GetItemPosition(Java.Lang.Object @object)
        {
            return base.GetItemPosition(@object);
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object obj)
        {
            return view == obj;
        }


    }
}
