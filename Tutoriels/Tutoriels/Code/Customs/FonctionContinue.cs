using Android.Graphics;

namespace Tutoriels.Code.Customs
{
    /// <summary>
    /// Fonction continue : tracé définie par un ensemble de points continue
    /// </summary>
    public class FonctionContinue
    {
        /// <summary>
        /// Couleur de la courbe
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Lignes de points
        /// </summary>
        public List<Coordonnee> Lines { get; set; }

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
            foreach (Coordonnee line in Lines)
            {
                if (minValueX > line.X) minValueX = line.X;
                if (minValueX > line.X) minValueX = line.X;
                if (maxValueX < line.X) maxValueX = line.X;
                if (maxValueX < line.X) maxValueX = line.X;

                if (minValueY > line.Y) minValueY = line.Y;
                if (minValueY > line.Y) minValueY = line.Y;
                if (maxValueY < line.Y) maxValueY = line.Y;
                if (maxValueY < line.Y) maxValueY = line.Y;
            }
        }

        public FonctionContinue()
        {
            Color = Color.AntiqueWhite;
            Lines = new List<Coordonnee>();
        }

        public FonctionContinue(Color color)
        {
            Color = color;
            Lines = new List<Coordonnee>();
        }

        public FonctionContinue(Color color, List<Coordonnee> points)
        {
            Color = color;
            Lines = new List<Coordonnee>(points);
        }
    }
}