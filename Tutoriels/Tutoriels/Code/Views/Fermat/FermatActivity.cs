using System.ComponentModel;
using System.Diagnostics;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Fermat
{
    [Activity(Label = "Tutorial")]
    public class FermatActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.FermatActivity;

        #endregion

        #region Internal Variable

        private ListViewFermatAdapter _adapter;

        #endregion

        #region life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViewById<ListView>(Resource.Id.lvFermat).Adapter = _adapter = new ListViewFermatAdapter(this);
        }


        /// <summary>
        /// Le système appelle OnResume lorsque l’activité est prête à commencer à interagir avec l’utilisateur. 
        /// Activités doivent substituer cette méthode pour effectuer des tâches telles que :
        /// - En identifiant des fréquences d’images(une tâche courante dans la construction de jeu)
        /// - Démarrage des animations
        /// - À l’écoute des mises à jour GPS
        /// - Afficher les alertes pertinentes ou les boîtes de dialogue
        /// - Des gestionnaires d’événements externes
        /// https://developer.xamarin.com/guides/android/application_fundamentals/activity_lifecycle/
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            Next();
        }


        #endregion

        #region User Interface


        private void Next()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += OnDoWork;
            worker.ProgressChanged += _worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerCompleted += _worker_RunWorkerCompleted;

            worker.RunWorkerAsync();

        }

        private const int maxvalue = 10000;

        private List<FermatItem> Items = new List<FermatItem>();

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            int n = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (sender is BackgroundWorker worker)
            {
                for (long a = 1; a < maxvalue; a++)
                {
                    for (long b = a + 1; b < maxvalue; b++)
                    {
                        long carre = a * a + b * b;
                        long c = (long)Math.Round(Math.Sqrt(carre), 0);
                        if (carre == c * c)
                        {
                            Items.Add(new FermatItem(a, b, c, sw.Elapsed));
                            if (n > 20)
                            {
                                worker.ReportProgress(n);
                                n = 0;
                            }
                            else
                            {
                                n++;
                            }
                        }
                    }
                }
            }
        }


        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _adapter.Reset(Items);
            _adapter.NotifyDataSetChanged();
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _adapter.Reset(Items);
            _adapter.NotifyDataSetChanged();
        }

        #endregion

    }
}