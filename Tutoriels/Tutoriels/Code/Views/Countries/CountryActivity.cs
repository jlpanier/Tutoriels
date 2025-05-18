using System.Xml.Serialization;
using Tutoriel.Database.Dbo;

namespace Tutoriels.Code.Activities.Countries
{
    [Activity(Label = "CountryActivity")]
    public class CountryActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.CountryActivity;

        #endregion

        #region Variable

        private ListViewAdapter _adapter;

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

            FindViewById<ListView>(Resource.Id.lvCountries).Adapter = _adapter = new ListViewAdapter(this);

            var items = DboCountries.GetAll();
            if (!items.Any())
            {
                Insert();
                items = DboCountries.GetAll();
            }
            _adapter.Reset(items.OrderBy(_ => _.SHORTNAME));

        }

        #endregion

        private void Insert()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AssetCountries));
            using (Stream fs = Assets.Open("Countries.xml"))
            {
                AssetCountries items = (AssetCountries)serializer.Deserialize(fs);
                foreach (var item in items.Countries)
                {
                    string filename = item.shortname.Replace(' ', '_').Replace('ô', 'o').Replace('-', '_').Replace('é', 'e').Replace('ê', 'e').Replace('è', 'e').Replace('ï', 'i').Replace('\'', '_').Replace('É', 'e').Replace('Î', 'i').Replace('ã', 'a').ToLower();
                    DboCountries.Save(new Repository.Entities.Country()
                    {
                        ID = Guid.NewGuid(),
                        SHORTNAME = item.shortname,
                        FLAG = filename,
                        LONGNAME = item.longname,
                        PROJECTION = $"{filename}_projection",
                        WIKI = item.wiki,
                    });
                }
            }
        }
    }
}