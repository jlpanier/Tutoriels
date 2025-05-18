using Android.Graphics;
using System;
using System.Collections.Generic;

namespace Tutoriels.Code.Customs
{
    /// <summary>
    /// Fonction em serie de Fourier
    /// </summary>
    public class SerieFourier
    {
        /// <summary>
        /// Couleur de la courbe
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Periode de la fonction serie de Fourier
        /// </summary>
        public double Periode { get; set; }

        /// <summary>
        /// Periode de la fonction serie de Fourier
        /// </summary>
        public void SetCoefficient(double periode, decimal[] a, decimal[] b)
        {
            Periode = periode;
            int ordre = Math.Max(a.Length, b.Length);
            for (double x = -2 * Math.PI; x < 2 * Math.PI; x += Math.PI / 12)
            {
                decimal y = 0;
                for (int k = 1; k < ordre; k++)
                {
                    double t = 2.0 * Math.PI * k * x / Periode;
                    if (a.Length > k)
                    {
                        y += a[k] * (decimal)(Math.Cos(t));
                    }
                    if (b.Length > k)
                    {
                        y += b[k] * (decimal)Math.Sin(t);
                    }
                }
                Lines.Add(new Coordonnee((decimal)x, y));
            }

        }

        /// <summary>
        /// Periode de la fonction serie de Fourier
        /// </summary>
        public void SetCoefficientPaire(double periode, decimal[] a)
        {
            Periode = periode;
            int ordre = a.Length;
            for (double x = -2 * Math.PI; x < 2 * Math.PI; x += Math.PI / 48)
            {
                decimal y = a[0];
                for (int k = 1; k < ordre; k++)
                {
                    if (a.Length > k)
                    {
                        y += a[k] * (decimal)Math.Cos(2 * Math.PI * k * x / Periode);
                    }
                }
                Lines.Add(new Coordonnee((decimal)x, y));
            }
        }

        /// <summary>
        /// Periode de la fonction serie de Fourier
        /// </summary>
        public void SetCoefficientImpaire(double periode, decimal[] b)
        {
            Periode = periode;
            int ordre = b.Length;
            for (double x = -2 * Math.PI; x < 2 * Math.PI; x += Math.PI / 48)
            {
                decimal y = 0;
                for (int k = 1; k < ordre; k++)
                {
                    if (b.Length > k)
                    {
                        y += b[k] * (decimal)Math.Sin(2 * Math.PI * k * x / Periode);
                    }
                }
                Lines.Add(new Coordonnee((decimal)x, y));
            }
        }


        /// <summary>
        /// Lignes de points
        /// </summary>
        public List<Coordonnee> Lines { get; private set; }

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

        public SerieFourier()
        {
            Color = Color.AntiqueWhite;
            Lines = new List<Coordonnee>();
        }

        public SerieFourier(Color color)
        {
            Color = color;
            Lines = new List<Coordonnee>();
        }


    }
}