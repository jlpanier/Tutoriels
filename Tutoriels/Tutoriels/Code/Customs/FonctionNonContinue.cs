using Android.Graphics;

namespace Tutoriels.Code.Customs
{
    /// <summary>
    /// Fonction non continue : tracé définie par un ensemble de deux points
    /// </summary>
    public class FonctionNonContinue
    {
        /// <summary>
        /// Couleur de la courbe
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Lignes de points
        /// </summary>
        public List<Line> Lines { get; set; }

        public decimal MinValueX
        {
            get
            {
                if (minValueX == null)
                {
                    Compute();
                }
                return minValueX ?? (decimal)0.0;
            }
        }
        private decimal? minValueX = null;

        public decimal MaxValueX
        {
            get
            {
                if (maxValueX == null)
                {
                    Compute();
                }
                return maxValueX ?? (decimal)0.0;
            }
        }
        private decimal? maxValueX = null;

        public decimal MinValueY
        {
            get
            {
                if (minValueY == null)
                {
                    Compute();
                }
                return minValueY ?? (decimal)0.0;
            }
        }
        private decimal? minValueY = null;

        public decimal MaxValueY
        {
            get
            {
                if (maxValueY == null)
                {
                    Compute();
                }
                return maxValueY ?? (decimal)0.0;
            }
        }
        private decimal? maxValueY = null;

        private void Compute()
        {
            minValueX = decimal.MaxValue;
            maxValueX = decimal.MinValue;
            minValueY = decimal.MaxValue;
            maxValueY = decimal.MinValue;
            foreach (var line in Lines)
            {
                if (minValueX > line.PointA.X) minValueX = line.PointA.X;
                if (minValueX > line.PointB.X) minValueX = line.PointB.X;
                if (maxValueX < line.PointA.X) maxValueX = line.PointA.X;
                if (maxValueX < line.PointB.X) maxValueX = line.PointB.X;

                if (minValueY > line.PointA.Y) minValueY = line.PointA.Y;
                if (minValueY > line.PointB.Y) minValueY = line.PointB.Y;
                if (maxValueY < line.PointA.Y) maxValueY = line.PointA.Y;
                if (maxValueY < line.PointB.Y) maxValueY = line.PointB.Y;
            }
        }
    }
}