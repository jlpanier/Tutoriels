using Android.Content;
using Android.Views;
using Common;
using Tutoriels.Code.Activities.Menu;
using static Tutoriels.Code.Views.Main.MenuTutorial;

namespace Tutoriels.Code.Views.Main
{
    internal class MenuItemAdapter : SimpleAdapter<MenuTutorial>
    {
        protected override int LayoutResourceId => Resource.Layout.ItemMenu;

        public MenuItemAdapter(Activity activity) : base(activity)
        {
            List<MenuTutorial> items = new List<MenuTutorial>();
            foreach (TypeMenus menu in Enum.GetValues(typeof(TypeMenus)))
            {
                items.Add(new MenuTutorial(menu));
            }
            Reset(items.OrderBy(_ => _.Menu.GetStringValue()).ToList());
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            MenuItemHolder holder = view.Tag as MenuItemHolder;

            if (holder == null)
            {
                holder = new MenuItemHolder();
                holder.tvMenu = view.FindViewById<TextView>(Resource.Id.tvMenu);
                view.Tag = holder;
            }

            MenuTutorial item = Items[position];
            holder.tvMenu.Text = item.Menu.GetStringValue();

            return view;
        }
    }
}
