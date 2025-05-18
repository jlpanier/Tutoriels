using AndroidX.ViewPager.Widget;

namespace Tutoriels.Code.Activities.Pager
{
    [Activity(Label = "Tutorial")]
    public class ViewPagerActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.ViewPagerActivity;

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

            var adapter = new ViewPagerAdapter(this);
            List<PagerItem> items = new List<PagerItem>()
            {
                new PagerItem(Resource.Drawable.albanie_projection),
                new PagerItem(Resource.Drawable.algerie_projection),
                new PagerItem(Resource.Drawable.allemagne_projection),
                new PagerItem(Resource.Drawable.andorre_projection),
            };
            adapter.Reset(items);
            FindViewById<ViewPager>(Resource.Id.viewpagerid).Adapter = adapter;
        }

        #endregion

        #region User Interface

        #endregion
    }
}
