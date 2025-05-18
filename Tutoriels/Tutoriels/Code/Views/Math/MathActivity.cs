using Android.Graphics;
using Tutoriels.Code.Customs;
using Tutoriels.Droid.Customs;

namespace Tutoriels.Code.Activities.Fourier
{
    [Activity(Label = "Tutorial")]
    public class MathActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.MathActivity;

        #endregion

        #region Variable

        /// <summary>
        /// Type de courbe
        /// </summary>
        private enum TypeCourbe { ProduitSinus }

        /// <summary>
        /// Type de courbe en cours
        /// </summary>
        private TypeCourbe _typeCourbe = TypeCourbe.ProduitSinus;

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

            FindViewById<ImageView>(Resource.Id.btnReward).Click += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtOrder).Text, out int ordre) && ordre > 10)
                {
                    ordre -= 10;
                    FindViewById<EditText>(Resource.Id.edtOrder).Text = ordre.ToString();
                }
                else
                {
                    FindViewById<EditText>(Resource.Id.edtOrder).Text = "1";
                }
                _timer.Change(250, Timeout.Infinite);
            };
            FindViewById<ImageView>(Resource.Id.btnMinus).Click += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtOrder).Text, out int ordre) && ordre > 1)
                {
                    ordre--;
                    FindViewById<EditText>(Resource.Id.edtOrder).Text = ordre.ToString();
                }
                else
                {
                    FindViewById<EditText>(Resource.Id.edtOrder).Text = "1";
                }
                _timer.Change(250, Timeout.Infinite);
            };
            FindViewById<ImageView>(Resource.Id.btnAdd).Click += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtOrder).Text, out int ordre))
                {
                    ordre++;
                    FindViewById<EditText>(Resource.Id.edtOrder).Text = ordre.ToString();
                }
                else
                {
                    FindViewById<EditText>(Resource.Id.edtOrder).Text = "1";
                }
                _timer.Change(250, Timeout.Infinite);
            };
            FindViewById<ImageView>(Resource.Id.btnForward).Click += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtOrder).Text, out int ordre))
                {
                    ordre += 10;
                    FindViewById<EditText>(Resource.Id.edtOrder).Text = ordre.ToString();
                }
                else
                {
                    FindViewById<EditText>(Resource.Id.edtOrder).Text = "10";
                }
                _timer.Change(250, Timeout.Infinite);
            };
            FindViewById<EditText>(Resource.Id.edtOrder).AfterTextChanged += (s, e) =>
            {
                _timer.Change(250, Timeout.Infinite);
            };

            _timer = new System.Threading.Timer(new TimerCallback(OnTimerRefresh), null, Timeout.Infinite, Timeout.Infinite);
            _timer.Change(250, Timeout.Infinite);
        }
        /// <summary>
        /// Timer pour déclencher le rafrachissement de l'heure affichée
        /// </summary>
        private System.Threading.Timer _timer;

        private void OnTimerRefresh(object state)
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            RunOnUiThread(() => Draw());
        }

        #endregion

        #region User Interface

        /// <summary>
        /// Trace les differentes courbes en fonction des choix
        /// </summary>
        private void Draw()
        {
            Histogramme histo = new Histogramme("Produit Sin(x)");

            switch (_typeCourbe)
            {
                case TypeCourbe.ProduitSinus:
                    decimal from = (decimal)(-6 * Math.PI);
                    decimal to = (decimal)(6 * Math.PI);
                    decimal delta = (decimal)(Math.PI / 12);
                    histo.Add(Histogramme.TypeCourbes.Sinus, from, to, delta, Color.Blue);
                    if (int.TryParse(FindViewById<EditText>(Resource.Id.edtOrder).Text, out int n) && n > 0)
                    {
                        histo.Add(Histogramme.TypeCourbes.ProductSinus, from, to, delta, Color.Red, n);
                    }
                    FindViewById<HistogrammeView>(Resource.Id.idHisto).Set(histo);
                    break;
            }
        }
    }

    #endregion
}