using System.ComponentModel;
using System.Diagnostics;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities
{
    [Activity(Label = "Tutorial")]
    public class NombrePremierActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.NombrePremierActivity;

        #endregion

        #region Internal Variable

        private ListViewNombrePremierAdaptator _adapter;

        private EnsembleNombrePremier _ensemble;

        #endregion

        #region life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViewById<ListView>(Resource.Id.lvNombrePremier).Adapter = _adapter = new ListViewNombrePremierAdaptator(this);
        }


        /// <summary>
        /// OnStart est toujours appelée par le système une fois l' OnCreate opération terminée. 
        /// Les activités peuvent remplacer cette méthode si elles doivent effectuer des tâches spécifiques juste avant qu’une activité devienne visible, 
        /// par exemple l’actualisation des valeurs actuelles des vues au sein de l’activité. Android appellera OnResume immédiatement après cette méthode.
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
            _ensemble = new EnsembleNombrePremier();
            _ensemble.Load();
            _adapter.Reset(_ensemble.List());
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

        /// <summary>
        /// OnStop est appelé lorsque l’activité n’est plus visible par l’utilisateur. 
        /// Cela se produit lorsque l’un des événements suivants se produit :
        /// •Une nouvelle activité est en cours de démarrage et couvre cette activité.
        /// •Une activité existante est placée au premier plan.
        /// •L’activité est en cours de destruction.
        /// OnStop ne peut pas toujours être appelé dans des situations de mémoire insuffisante, 
        /// par exemple quand Android est privé de ressources et ne peut pas être correctement en arrière-plan de l’activité.
        /// Pour cette raison, il est préférable de ne pas s’appuyer sur l’appel de la OnStop méthode lors de la préparation d’une activité pour la destruction.
        /// Les méthodes de cycle de vie suivantes peuvent être appelées après celle-ci OnDestroy si l’activité est en cours, ou OnRestart si l’activité est à nouveau en interaction avec l’utilisateur.
        /// </summary>
        protected override void OnStop()
        {
            base.OnStop();
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

            worker.RunWorkerAsync(_ensemble.Last());

        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _adapter.Reset(_ensemble.List());
            _adapter.NotifyDataSetChanged();
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _adapter.Reset(_ensemble.List());
            _adapter.NotifyDataSetChanged();
        }

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is long nombre)
            {
                int n = 0;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                long element = nombre + 2;
                while (_ensemble.CanAdd)
                {
                    if (_ensemble.EstNombrePremier(element))
                    {
                        sw.Stop();
                        _ensemble.Add(element, sw.Elapsed);
                        if (sender is BackgroundWorker worker)
                        {
                            worker.ReportProgress(n++);
                        }
                        sw.Restart();
                    }
                    element += 2;
                }
                sw.Stop();
            }
        }

        #endregion

    }
}