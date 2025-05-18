namespace Tutoriels.Code.Activities.IntentAction
{
    public class ListViewAndroidActionsItem
    {
        public readonly string Name;

        public enum EnumStatus { NotSet, Enable, Disable }

        public EnumStatus Status { get; set; }

        public ListViewAndroidActionsItem(string name)
        {
            Name = name;
            Status = EnumStatus.NotSet;
        }
    }
}