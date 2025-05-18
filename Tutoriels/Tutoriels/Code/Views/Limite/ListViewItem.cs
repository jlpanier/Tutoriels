namespace Tutoriels.Code.Activities.Limite
{
    public class ListViewItem
    {
        public int N { get; private set; }

        public decimal Value { get; private set; }

        public string Display => $"{Value.ToString("#.#######")}";

        public ListViewItem(int n, decimal valeur)
        {
            N = n;
            Value = valeur;
        }

        public ListViewItem(int n, double valeur)
        {
            N = n;
            Value = (decimal)valeur;
        }
    }
}