using Android.Locations;
using System;

namespace Tutoriels.Code.Activities.GeoLocalisation
{
    public class LocalisationItem
    {
        public string Evenement { get; private set; }
        public string Provider { get; private set; }
        public DateTime DateOn { get; private set; }

        private readonly Location Localisation;

        public string Position => Localisation == null ? string.Empty : $"{Localisation.Latitude} / {Localisation.Longitude}";
        public LocalisationItem(string provider, Location localisation, string evenement)
        {
            DateOn = DateTime.Now;
            Evenement = evenement;
            Localisation = localisation;
            Provider = provider;
        }

        public LocalisationItem(string provider, string evenement)
        {
            DateOn = DateTime.Now;
            Evenement = evenement;
            Localisation = null;
            Provider = provider;
        }
    }
}