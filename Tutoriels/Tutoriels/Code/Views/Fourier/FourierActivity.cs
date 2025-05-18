using Android.Graphics;
using Tutoriels.Code.Customs;
using Tutoriels.Droid.Customs;

namespace Tutoriels.Code.Activities.Fourier
{
    [Activity(Label = "Tutorial")]
    public class FourierActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.FourierActivity;

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

            FindViewById<RadioButton>(Resource.Id.radio_dirac_unitaire).Checked = true;
            FindViewById<RadioButton>(Resource.Id.radio_dirac_unitaire).Click += (s, e) =>
            {
                Draw();
            };
            FindViewById<RadioButton>(Resource.Id.radio_dirac).Click += (s, e) =>
            {
                Draw();
            };
            FindViewById<RadioButton>(Resource.Id.radio_chapeau).Click += (s, e) =>
            {
                Draw();
            };
            FindViewById<RadioButton>(Resource.Id.radio_creneau).Click += (s, e) =>
            {
                Draw();
            };
            FindViewById<RadioButton>(Resource.Id.radio_dent_scie).Click += (s, e) =>
            {
                Draw();
            };
            FindViewById<RadioButton>(Resource.Id.radio_parabole).Click += (s, e) =>
            {
                Draw();
            };
            FindViewById<EditText>(Resource.Id.edtSerieFourier).AfterTextChanged += (s, e) =>
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
        /// Trace les differentes courbes en fonction des choixs
        /// </summary>
        private void Draw()
        {
            int ordre;
            Histogramme courbes = new Histogramme();

            HistogrammeView histo = FindViewById<HistogrammeView>(Resource.Id.idHisto);

            // Dirax unitaire
            if (FindViewById<RadioButton>(Resource.Id.radio_dirac_unitaire).Checked)
            {
                const double h = Math.PI / 24;
                courbes.Titre = "Fonction Dirac unitaire de période 2pi";
                courbes.Orthonormme = true;

                courbes.FonctionContinues.Add(new FonctionContinue()
                {
                    Color = Color.Blue,
                    Lines = new List<Coordonnee>()
                    {
                        new Coordonnee((decimal)(-2*Math.PI),1),
                        new Coordonnee((decimal)(-2*Math.PI+h),1),
                        new Coordonnee((decimal)(-2*Math.PI+h),0),
                        new Coordonnee((decimal)-h,0),
                        new Coordonnee((decimal)-h,1),
                        new Coordonnee((decimal)h,1),
                        new Coordonnee((decimal)h,0),
                        new Coordonnee((decimal)(2*Math.PI-h),0),
                        new Coordonnee((decimal)(2*Math.PI-h),1),
                        new Coordonnee((decimal)(2*Math.PI),1),
                    }
                });
                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtSerieFourier).Text, out ordre) && ordre > 0)
                {
                    courbes.Titre = $"Série de fourier fonction dirac unitaire a l'ordre {ordre}";
                    SerieFourier seriefourier = new SerieFourier(Color.Red);
                    decimal[] coefficients = new decimal[ordre];
                    for (int k = 1; k < ordre; k++)
                    {
                        coefficients[k] = (decimal)(2d * Math.Sin(k * h) / (k * Math.PI));
                    }
                    coefficients[0] = (decimal)(h / (2 * Math.PI));
                    seriefourier.SetCoefficientPaire(2 * Math.PI, coefficients);
                    courbes.Fouriers.Add(seriefourier);
                }
            }

            // Dirac surface = 1
            if (FindViewById<RadioButton>(Resource.Id.radio_dirac).Checked)
            {
                const double h = Math.PI / 24;
                courbes.Titre = "Fonction Dirac de période 2pi";
                courbes.Orthonormme = true;

                courbes.FonctionContinues.Add(new FonctionContinue()
                {
                    Color = Color.Blue,
                    Lines = new List<Coordonnee>()
                    {
                        new Coordonnee((decimal)(-2*Math.PI),(decimal)(1/h)),
                        new Coordonnee((decimal)(-2*Math.PI+h),(decimal)(1/h)),
                        new Coordonnee((decimal)(-2*Math.PI+h),0),
                        new Coordonnee((decimal)-h,0),
                        new Coordonnee((decimal)-h,(decimal)(1/h)),
                        new Coordonnee((decimal)h,(decimal)(1/h)),
                        new Coordonnee((decimal)h,0),
                        new Coordonnee((decimal)(2*Math.PI-h),0),
                        new Coordonnee((decimal)(2*Math.PI-h),(decimal)(1/h)),
                        new Coordonnee((decimal)(2*Math.PI),(decimal)(1/h)),
                    }
                });
                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtSerieFourier).Text, out ordre) && ordre > 0)
                {
                    courbes.Titre = $"Série de fourier fonction dirac a l'ordre {ordre}";
                    SerieFourier seriefourier = new SerieFourier(Color.Red);
                    decimal[] coefficients = new decimal[ordre];
                    for (int k = 1; k < ordre; k++)
                    {
                        coefficients[k] = (decimal)(4d * Math.Sin(k * h) / (h * k * Math.PI));
                    }
                    coefficients[0] = (decimal)(1 / (2 * Math.PI));
                    seriefourier.SetCoefficientPaire(2 * Math.PI, coefficients);
                    courbes.Fouriers.Add(seriefourier);
                }
            }

            // Chapeau
            if (FindViewById<RadioButton>(Resource.Id.radio_chapeau).Checked)
            {
                courbes.Titre = "Fonction Chapeau de période 2pi";
                courbes.Orthonormme = true;

                courbes.FonctionContinues.Add(new FonctionContinue()
                {
                    Color = Color.Blue,
                    Lines = new List<Coordonnee>()
                    {
                        new Coordonnee((decimal)(-2*Math.PI),0),
                        new Coordonnee((decimal)(-Math.PI),(decimal)(Math.PI)),
                        new Coordonnee(0,0),
                        new Coordonnee((decimal)(Math.PI),(decimal)(Math.PI)),
                        new Coordonnee((decimal)(2*Math.PI),0),
                    }
                });
                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtSerieFourier).Text, out ordre) && ordre > 0)
                {
                    courbes.Titre = $"Série de fourier fonction chapeau a l'ordre {ordre}";
                    courbes.Orthonormme = false;
                    SerieFourier seriefourier = new SerieFourier(Color.Red);
                    decimal[] coefficients = new decimal[ordre];
                    for (int k = 0; k < ordre; k++)
                    {
                        if (k % 2 == 0)
                        {
                            coefficients[k] = 0;
                        }
                        else
                        {
                            coefficients[k] = (decimal)(-4d / (k * k * Math.PI));
                        }
                    }
                    coefficients[0] = (decimal)Math.PI / 2;
                    seriefourier.SetCoefficientPaire(2 * Math.PI, coefficients);
                    courbes.Fouriers.Add(seriefourier);

                }
            }

            // Créneau

            if (FindViewById<RadioButton>(Resource.Id.radio_creneau).Checked)
            {
                courbes.Titre = "Fonction créneau de période 2pi";
                courbes.Orthonormme = true;

                courbes.FonctionContinues.Add(new FonctionContinue()
                {
                    Color = Color.Blue,
                    Lines = new List<Coordonnee>()
                    {
                        new Coordonnee((decimal)(-2*Math.PI),1),
                        new Coordonnee((decimal)(-Math.PI),1),
                        new Coordonnee((decimal)(-Math.PI),-1),
                        new Coordonnee((decimal)(0),-1),
                        new Coordonnee((decimal)(0),1),
                        new Coordonnee((decimal)(Math.PI),1),
                        new Coordonnee((decimal)(Math.PI),-1),
                        new Coordonnee((decimal)(2*Math.PI),-1),
                    }
                });
                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtSerieFourier).Text, out ordre) && ordre > 0)
                {
                    courbes.Titre = $"Série de fourier fonction créneau a l'ordre {ordre}";
                    courbes.Orthonormme = false;
                    SerieFourier seriefourier = new SerieFourier(Color.Red);
                    decimal[] coefficients = new decimal[ordre];
                    for (int k = 0; k < ordre; k++)
                    {
                        if (k % 2 == 0)
                        {
                            coefficients[k] = 0;
                        }
                        else
                        {
                            coefficients[k] = (decimal)(4d / (k * Math.PI));
                        }
                    }
                    coefficients[0] = 0;
                    seriefourier.SetCoefficientImpaire(2 * Math.PI, coefficients);
                    courbes.Fouriers.Add(seriefourier);
                }
            }

            // Dent de scie
            if (FindViewById<RadioButton>(Resource.Id.radio_dent_scie).Checked)
            {
                courbes.Titre = "Fonction dents de scie de période 2pi";
                courbes.Orthonormme = true;

                courbes.FonctionContinues.Add(new FonctionContinue()
                {
                    Color = Color.Blue,
                    Lines = new List<Coordonnee>()
                    {
                        new Coordonnee((decimal)(-2*Math.PI),0),
                        new Coordonnee((decimal)(-Math.PI),1),
                        new Coordonnee((decimal)(-Math.PI),-1),
                        new Coordonnee((decimal)(Math.PI),1),
                        new Coordonnee((decimal)(Math.PI),-1),
                        new Coordonnee((decimal)(2*Math.PI),0),
                    }
                });
                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtSerieFourier).Text, out ordre) && ordre > 0)
                {
                    courbes.Titre = $"Série de fourier fonction dent de scie a l'ordre {ordre}";
                    courbes.Orthonormme = false;
                    SerieFourier seriefourier = new SerieFourier(Color.Red);
                    decimal[] coefficients = new decimal[ordre];
                    for (int k = 1; k < ordre; k++)
                    {
                        if (k % 2 == 0)
                        {
                            coefficients[k] = -(decimal)(2d / (k * Math.PI));
                        }
                        else
                        {
                            coefficients[k] = (decimal)(2d / (k * Math.PI));
                        }
                    }
                    coefficients[0] = 0;
                    seriefourier.SetCoefficientImpaire(2 * Math.PI, coefficients);
                    courbes.Fouriers.Add(seriefourier);
                }
            }

            // Parabole
            if (FindViewById<RadioButton>(Resource.Id.radio_parabole).Checked)
            {
                courbes.Titre = "Fonction parabole de période 2pi";
                courbes.Orthonormme = true;

                var lines = new List<Coordonnee>();
                for (decimal x = -2 * (decimal)Math.PI; x < -(decimal)Math.PI; x += (decimal)Math.PI / 12)
                {
                    decimal a = x + (decimal)(2 * Math.PI);
                    lines.Add(new Coordonnee(x, a * a));
                }
                for (decimal x = -(decimal)Math.PI; x < (decimal)Math.PI; x += (decimal)Math.PI / 12)
                {
                    lines.Add(new Coordonnee(x, x * x));
                }
                for (decimal x = (decimal)Math.PI; x < 2 * (decimal)Math.PI; x += (decimal)Math.PI / 12)
                {
                    decimal a = x - (decimal)(2 * Math.PI);
                    lines.Add(new Coordonnee(x, a * a));
                }

                courbes.FonctionContinues.Add(new FonctionContinue()
                {
                    Color = Color.Blue,
                    Lines = lines
                });

                if (int.TryParse(FindViewById<EditText>(Resource.Id.edtSerieFourier).Text, out ordre) && ordre > 0)
                {
                    courbes.Titre = $"Série de fourier fonction parabole a l'ordre {ordre}";
                    courbes.Orthonormme = false;
                    SerieFourier seriefourier = new SerieFourier(Color.Red);
                    decimal[] coefficients = new decimal[ordre + 1];
                    for (int k = 1; k <= ordre; k++)
                    {
                        if (k % 2 == 0)
                        {
                            coefficients[k] = (decimal)(4d / (k * k));
                        }
                        else
                        {
                            coefficients[k] = -(decimal)(4d / (k * k));
                        }
                    }
                    coefficients[0] = (decimal)(Math.PI * Math.PI / 3);
                    seriefourier.SetCoefficientPaire(2 * Math.PI, coefficients);
                    courbes.Fouriers.Add(seriefourier);
                }
            }



            histo.Set(courbes);
        }
    }

    #endregion
}