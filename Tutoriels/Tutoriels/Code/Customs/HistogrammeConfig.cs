using Android.Graphics;
using System;
using System.Collections.Generic;

namespace Tutoriels.Code.Customs
{
    public class Histogramme
    {
        /// <summary>
        /// Valeur minimale des absicisses
        /// </summary>
        public decimal? XMin { get; set; }

        /// <summary>
        /// Valeur maximale des absicisses
        /// </summary>
        public decimal? XMax { get; set; }

        /// <summary>
        /// Valeur maximale des ordonnées
        /// </summary>
        public decimal? YMax { get; set; }

        /// <summary>
        /// Valeur minimale des ordonnées
        /// </summary>
        public decimal? YMin { get; set; }

        /// <summary>
        /// Type de courbes
        /// </summary>
        public enum TypeCourbes { Sinus, ProductSinus }

        /// <summary>
        /// Ajout dune courbe sin(x) - suite de points 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="delta"></param>
        /// <param name="color"></param>
        private void AddSinus(decimal from, decimal to, decimal delta, Color color)
        {
            List<Coordonnee> points = new List<Coordonnee>();
            for (decimal x = from; x < to; x += delta)
            {
                points.Add(new Coordonnee(x, (decimal)Math.Sin((double)x)));
            }
            FonctionContinues.Add(new FonctionContinue(color, points));
        }

        /// <summary>
        /// Ajout dune courbe produit sin(x) - suite de points 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="delta"></param>
        /// <param name="color"></param>
        private void AddProductSinus(decimal from, decimal to, decimal delta, Color color, int n)
        {
            List<Coordonnee> points = new List<Coordonnee>();
            for (decimal x = from; x < to; x += delta)
            {
                decimal y = x;
                decimal kpi = 0;
                for (int k = 1; k <= n; k++)
                {
                    kpi += (decimal)(Math.PI);
                    y *= (1 - x / kpi) * (1 + x / kpi);
                }
                points.Add(new Coordonnee(x, y));
            }
            FonctionContinues.Add(new FonctionContinue(color, points));
        }

        /// <summary>
        /// Ajout dúne courbe a l'histogramme
        /// </summary>
        /// <param name="type"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="delta"></param>
        /// <param name="color"></param>
        public void Add(TypeCourbes type, decimal from, decimal to, decimal delta, Color color, int n = 0)
        {
            switch (type)
            {
                case TypeCourbes.Sinus:
                    AddSinus(from, to, delta, color);
                    break;
                case TypeCourbes.ProductSinus:
                    AddProductSinus(from, to, delta, color, n);
                    break;
            }
        }

        /// <summary>
        /// Titre de la courbe graphique 
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Commentaire de la courbe graphique
        /// </summary>
        public string Commentaire { get; set; }

        /// <summary>
        /// Ensemble des courbes du graphiques: fonction non continue, tracé définie par un ensemble de deux points
        /// </summary>
        public List<FonctionNonContinue> FonctionNonContinues { get; set; }

        /// <summary>
        /// Ensemble des courbes du graphiques: fonction continue, tracé définie par des points successifs
        /// </summary>
        public List<FonctionContinue> FonctionContinues { get; set; }

        /// <summary>
        /// Ensemble des courbes du graphiques: fonction continue, tracé définie par des points successifs
        /// </summary>
        public List<SerieFourier> Fouriers { get; set; }

        /// <summary>
        /// Type de reperer orthorme
        /// </summary>
        public bool Orthonormme { get; set; } = false;

        public Histogramme()
        {
            FonctionNonContinues = new List<FonctionNonContinue>();
            FonctionContinues = new List<FonctionContinue>();
            Fouriers = new List<SerieFourier>();
        }

        public Histogramme(string titre, bool orthonorme = true) : base()
        {
            Titre = titre;
            Orthonormme = orthonorme;
            FonctionNonContinues = new List<FonctionNonContinue>();
            FonctionContinues = new List<FonctionContinue>();
            Fouriers = new List<SerieFourier>();
        }
    }
}