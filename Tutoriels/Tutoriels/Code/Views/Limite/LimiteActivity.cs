using System.Reflection;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Limite
{
    [Activity(Label = "Tutorial")]
    public class LimiteActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.LimiteActivity;

        #endregion

        #region Variable

        /// <summary>
        /// Type de séries
        /// </summary>
        private enum TypeSeries { PISUR4, PI2SUR6, PI2SUR8, PI2SUR12,PIRAC2 }

        /// <summary>
        /// Type de séries
        /// </summary>
        private TypeSeries _typeSerie = TypeSeries.PISUR4;

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

            FindViewById<ImageView>(Resource.Id.imgPrevious).Click += (s, e) =>
            {
                switch (_typeSerie)
                {
                    case TypeSeries.PISUR4:
                        _typeSerie = TypeSeries.PI2SUR6;
                        break;
                    case TypeSeries.PI2SUR6:
                        _typeSerie = TypeSeries.PI2SUR8;
                        break;
                    case TypeSeries.PI2SUR8:
                        _typeSerie = TypeSeries.PI2SUR12;
                        break;
                    case TypeSeries.PI2SUR12:
                        _typeSerie = TypeSeries.PIRAC2;
                        break;
                    case TypeSeries.PIRAC2:
                        _typeSerie = TypeSeries.PISUR4;
                        break;
                }
                _timer.Change(250, Timeout.Infinite);
            };
            FindViewById<ImageView>(Resource.Id.imgNext).Click += (s, e) =>
            {
                switch (_typeSerie)
                {
                    case TypeSeries.PISUR4:
                        _typeSerie = TypeSeries.PIRAC2;
                        break;
                    case TypeSeries.PI2SUR6:
                        _typeSerie = TypeSeries.PISUR4;
                        break;
                    case TypeSeries.PI2SUR8:
                        _typeSerie = TypeSeries.PI2SUR6;
                        break;
                    case TypeSeries.PI2SUR12:
                        _typeSerie = TypeSeries.PI2SUR8;
                        break;
                    case TypeSeries.PIRAC2:
                        _typeSerie = TypeSeries.PI2SUR12;
                        break;
                }
                _timer.Change(250, Timeout.Infinite);
            };

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

            _adapter = new ListViewAdapter(this);
            FindViewById<ListView>(Resource.Id.lvValues).Adapter = _adapter;

            _timer = new Timer(new TimerCallback(OnTimerRefresh), null, Timeout.Infinite, Timeout.Infinite);
            _timer.Change(250, Timeout.Infinite);
        }

        /// <summary>
        /// Timer pour déclencher le rafrachissement de l'heure affichée
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// Timer échu - affichage
        /// </summary>
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
            if (!int.TryParse(FindViewById<EditText>(Resource.Id.edtOrder).Text, out int N))
            {
                N = 10;
                FindViewById<EditText>(Resource.Id.edtOrder).Text = N.ToString();
            }

            List<ListViewItem> items = new List<ListViewItem>();
            decimal somme;
            switch (_typeSerie)
            {
                case TypeSeries.PISUR4:
                    FindViewById<ImageView>(Resource.Id.imgFormula).SetImageResource(Resource.Drawable.PISUR4);

                    somme = (decimal)4.0;
                    for (int index = 1; index <= N; index++)
                    {
                        int n = 2 * index + 1;
                        somme += index % 2 == 0 ? (decimal)4.0 / (decimal)n : (decimal)-4.0 / (decimal)n;
                        items.Add(new ListViewItem(index, somme));
                    }
                    break;
                case TypeSeries.PI2SUR6:
                    FindViewById<ImageView>(Resource.Id.imgFormula).SetImageResource(Resource.Drawable.PI2SUR6);

                    somme = (decimal)1.0;
                    for (int n = 2; n <= N; n++)
                    {
                        somme += (decimal)1.0 / (decimal)(n * n);
                        items.Add(new ListViewItem(n, Math.Sqrt((double)(6 * somme))));
                    }
                    break;
                case TypeSeries.PI2SUR8:
                    FindViewById<ImageView>(Resource.Id.imgFormula).SetImageResource(Resource.Drawable.PI2SUR8);

                    somme = (decimal)1.0;
                    for (int k = 1; k <= N; k++)
                    {
                        int n = 2 * k + 1;
                        somme += (decimal)1.0 / (decimal)(n * n);
                        items.Add(new ListViewItem(k, Math.Sqrt((double)(8 * somme))));
                    }
                    break;
                case TypeSeries.PI2SUR12:
                    FindViewById<ImageView>(Resource.Id.imgFormula).SetImageResource(Resource.Drawable.PI2SUR12);

                    somme = (decimal)1.0;
                    for (int k = 2; k <= N; k++)
                    {
                        somme += k % 2 == 0 ? -(decimal)1.0 / (decimal)(k * k) : (decimal)1.0 / (decimal)(k * k);
                        items.Add(new ListViewItem(k, Math.Sqrt((double)(12 * somme))));
                    }
                    break;
                case TypeSeries.PIRAC2:
                    FindViewById<ImageView>(Resource.Id.imgFormula).SetImageResource(Resource.Drawable.PIRAC2);

                    double unpun, un = 0, produit = 1.0;
                    for (int k = 1; k <= N; k++)
                    {
                        unpun = Math.Sqrt((double)0.5 +((double)(0.5)*un));
                        produit *= unpun;
                        items.Add(new ListViewItem(k, 2/produit));
                        un = unpun;
                    }
                    break;
            }
            _adapter.Reset(items);
            _adapter.NotifyDataSetChanged();
        }
    }

    #endregion
}