namespace Tutoriels.Code.Customs
{
    public class Coordonnee
    {
        public decimal X { get; private set; }
        public decimal Y { get; private set; }

        public Coordonnee(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }
    }
}