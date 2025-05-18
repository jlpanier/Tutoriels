using Tutoriel;

namespace Tutoriels.Code.Activities
{
    public abstract class BaseActivity : Activity
    {
        #region General

        /// <summary>
        /// Notre layout pour cette activité
        /// </summary>
        protected abstract int LayoutResourceId { get; }

        #endregion

        #region Life Cycle

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
            SetContentView(LayoutResourceId);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            try
            {
                SetActionBar(toolbar);

                // Most Android apps rely on the Back button for app navigation; pressing the Back button takes the user to the previous screen.
                // For apps with multiple activities, it often makes sense to instead provide an Up button so that the user can move up to a higher level in the app hierarchy
                // (that is, the app pops the user back multiple activities in the back stack rather than popping back to the previously - visited Activity).
                // To enable the Up button in a second activity that uses a Toolbar as its action bar, call the SetDisplayHomeAsUpEnabled and SetHomeButtonEnabled methods in the second activity's OnCreate method: 
                ActionBar.SetDisplayHomeAsUpEnabled(true);
                ActionBar.SetHomeButtonEnabled(true);
                ActionBar.Title = "Toolbar";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            var editToolbar = FindViewById<Toolbar>(Resource.Id.toolbarBottom);
            if (editToolbar != null)
            {

                editToolbar.Title = "System action";
                editToolbar.InflateMenu(Resource.Menu.toolbarBottomMenu);
            }
        }


        /// <summary>
        /// OnStart est toujours appelée par le système une fois l' OnCreate opération terminée. 
        /// Les activités peuvent remplacer cette méthode si elles doivent effectuer des tâches spécifiques juste avant qu’une activité devienne visible, 
        /// par exemple l’actualisation des valeurs actuelles des vues au sein de l’activité. Android appellera OnResume immédiatement après cette méthode.
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
        }

        /// <summary>
        /// OnPause est appelée lorsque le système est sur le point de mettre l’activité en arrière-plan ou lorsque l’activité est partiellement masquée. 
        /// Activités doivent substituer cette méthode si nécessaire :
        /// - Valider les modifications non enregistrées sur des données persistantes
        /// - Détruire ou nettoyez les autres objets consomment des ressources
        /// - Rampe des fréquences d’images et les animations de suspension
        /// - Annulez l’enregistrement de gestionnaires d’événements externes ou les gestionnaires de notification 
        ///  (c'est-à-dire celles qui sont liés à un service). Ceci doit être fait pour éviter les fuites de mémoire d’activité.
        /// - De même, si l’activité a affiché toutes les boîtes de dialogue ou les alertes, ils doivent être nettoyés avec la .Dismiss() (méthode).
        /// https://developer.xamarin.com/guides/android/application_fundamentals/activity_lifecycle/
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
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


        /// <summary>
        /// OnDestroy est la dernière méthode appelée sur une instance d’activité avant qu’elle ne soit détruite et complètement supprimée de la mémoire. 
        /// Dans les situations extrêmes, Android peut arrêter le processus d’application qui héberge l’activité, ce qui entraînera l' OnDestroy invocation de. 
        /// La plupart des activités n’implémentent pas cette méthode, car la plupart des opérations de nettoyage et d’arrêt ont été effectuées dans les OnPause OnStop méthodes 
        /// OnDestroy méthode est généralement remplacée pour nettoyer les tâches de longue durée qui peuvent provoquer des fuites de ressources. 
        /// Il peut s’agir, par exemple, de threads d’arrière-plan démarrés dans OnCreate .
        /// Aucune méthode de cycle de vie n’est appelée une fois que l’activité a été détruite
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        /// <summary>
        /// De nombreux appareils Android possèdent deux boutons distincts : un bouton « précédent » et un bouton « démarrage 
        /// </summary>
        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        #endregion

        #region Message

        public void Message(string text, ToastLength length = ToastLength.Short) => Toast.MakeText(this, text, length).Show();

        #endregion
    }
}