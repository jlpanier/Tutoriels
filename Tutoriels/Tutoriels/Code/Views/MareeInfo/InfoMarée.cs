using System;

namespace Tutoriels.Code.Activities.MareeInfo
{
    public class DataInfoMarée
    {
        public DateTime Horaire { get; private set; }

        public double Hauteur { get; private set; }

        public int Coefficient { get; private set; }

        public DataInfoMarée(DateTime horaire, double hauteur, int coef)
        {
            Horaire = horaire;
            Hauteur = hauteur;
            Coefficient = coef;
        }
    }
}