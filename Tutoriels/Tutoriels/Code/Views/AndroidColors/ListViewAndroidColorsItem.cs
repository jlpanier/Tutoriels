using Android.Graphics;

namespace Tutoriels.Code.Activities.AndroidColors
{
    public class ListViewAndroidColorsItem
    {
        public string Name { get; private set; }

        public Color Color { get; private set; }

        public ListViewAndroidColorsItem(Color color, string name)
        {
            Name = string.IsNullOrEmpty(name) ? color.GetType().Name : name;
            Color = color;
        }

        public ListViewAndroidColorsItem(Color color)
        {
            Color = color;
            Name = color.GetType().Name;
        }
    }
}