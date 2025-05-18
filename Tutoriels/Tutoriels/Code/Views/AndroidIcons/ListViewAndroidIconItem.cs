
namespace Tutoriels.Code.Activities.AndroidIcons
{
    public class ListViewAndroidIconItem
    {
        public int ResourceId { get; private set; }
        public string Name { get; private set; }

        public ListViewAndroidIconItem(int res, string name)
        {
            Name = name;
            ResourceId = res;
        }

        public ListViewAndroidIconItem(int res)
        {
            Name = nameof(res);
            ResourceId = res;
        }
    }
}