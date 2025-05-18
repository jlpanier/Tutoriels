namespace Tutoriels.Code.Customs
{
    public class Line
    {
        public Coordonnee PointA { get; private set; }
        public Coordonnee PointB { get; private set; }

        public Line(Coordonnee a, Coordonnee b)
        {
            PointA = a;
            PointB = b;
        }
    }
}