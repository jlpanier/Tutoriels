using System;

namespace Tutoriels.Code.Activities.MareeInfo
{
    public class DataMarée
    {
        public TimeSpan Horaire { get; private set; }

        public double Hauteur { get; private set; }

        public int Coefficient { get; private set; }

        public DataMarée(int heure, int minute, double hauteur, int coef)
        {
            Horaire = new TimeSpan(heure, minute, 0);
            Hauteur = hauteur;
            Coefficient = coef;
        }
    }
}