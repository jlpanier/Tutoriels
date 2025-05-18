using System.Reflection;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.CRRBluetooth
{
    [Activity(Label = "Tutorial")]
    public class ScreenSizeActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.layout_screensize;

        #endregion

        #region life cycle

        /// <summary>
        /// OnCreate est la première méthode à appeler lorsqu’une activité est créée. 
        /// OnCreate est toujours remplacée pour effectuer toutes les initialisations de démarrage qui peuvent être requis par une activité telles que :
        /// - Création de vues
        /// - Initialiser des variables
        /// - Liaison de données statiques aux listes
        /// Aide Windows: https://docs.microsoft.com/fr-fr/xamarin/android/
        /// https://developer.xamarin.com/guides/android/application_fundamentals/activity_lifecycle/
        /// Icon : http://modernuiicons.com/ 
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            TextView view = FindViewById<TextView>(Resource.Id.layoutsizeid);
            if (view != null)
            {
                FindViewById<TextView>(Resource.Id.layoutsizeid).Text = $"Density {Resources.DisplayMetrics.Density} dpi {Resources.DisplayMetrics.DensityDpi} Size={Resources.DisplayMetrics.WidthPixels}x{Resources.DisplayMetrics.HeightPixels}";
            }
        }

        #endregion

    }
}