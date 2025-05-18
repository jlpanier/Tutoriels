using Tutoriel;
using Android.Content;
using Android.Provider;
using System.Reflection;
using Tutoriels.Code.Activities;

namespace Tutoriels.Code.Activities.IntentAction
{
    [Activity(Label = "Tutorial")]
    public class IntentActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.IntentActivity;

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

            var items = new String[]
            {
                string.Empty,

                Intent.ActionCall,
                Intent.ActionDefault,
                Intent.ActionEdit,
                Intent.ActionMain,
                Intent.ActionPick,
                Intent.ActionPickActivity,
                MediaStore.ActionImageCapture,
                MediaStore.ExtraShowActionIcons,
                MediaStore.IntentActionVideoCamera,
            };
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, items);

            FindViewById<CheckBox>(Resource.Id.cbAlternative).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppBrowser).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppCalculator).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppCalendar).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppContacts).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppEmail).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppGallery).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppMaps).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppMarket).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppMessaging).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbAppMusic).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbBrowsable).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbCarDock).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbCarMode).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbDefault).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbDeskDock).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbDevelopmentPreference).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbEmbed).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbFrameworkInstrumentationTest).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbHeDeskDock).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbHome).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbInfo).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbLauncher).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbLeanbackLauncher).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbLeDeskDock).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbMonkey).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbOpenable).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbPreference).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbSampleCode).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbSelectedAlternative).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbTab).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbTest).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbTypedOpenable).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbUnitTest).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbVoice).CheckedChange += (s, e) => Launch();
            FindViewById<CheckBox>(Resource.Id.cbVrHome).CheckedChange += (s, e) => Launch();
        }
        #endregion

        private void Launch()
        {
            Launch(FindViewById<Spinner>(Resource.Id.spinner).SelectedItem.ToString());
        }

        private bool Launch(string intentaction)
        {
            try
            {
                Intent i = string.IsNullOrEmpty(intentaction) ? new Intent() : new Intent(intentaction);
                if (FindViewById<CheckBox>(Resource.Id.cbAlternative).Checked) i.AddCategory(Intent.CategoryAlternative);
                if (FindViewById<CheckBox>(Resource.Id.cbAppBrowser).Checked) i.AddCategory(Intent.CategoryAppBrowser);
                if (FindViewById<CheckBox>(Resource.Id.cbAppCalculator).Checked) i.AddCategory(Intent.CategoryAppCalculator);
                if (FindViewById<CheckBox>(Resource.Id.cbAppCalendar).Checked) i.AddCategory(Intent.CategoryAppCalendar);
                if (FindViewById<CheckBox>(Resource.Id.cbAppContacts).Checked) i.AddCategory(Intent.CategoryAppContacts);
                if (FindViewById<CheckBox>(Resource.Id.cbAppEmail).Checked) i.AddCategory(Intent.CategoryAppEmail);
                if (FindViewById<CheckBox>(Resource.Id.cbAppGallery).Checked) i.AddCategory(Intent.CategoryAppGallery);
                if (FindViewById<CheckBox>(Resource.Id.cbAppMaps).Checked) i.AddCategory(Intent.CategoryAppMaps);
                if (FindViewById<CheckBox>(Resource.Id.cbAppMarket).Checked) i.AddCategory(Intent.CategoryAppMarket);
                if (FindViewById<CheckBox>(Resource.Id.cbAppMessaging).Checked) i.AddCategory(Intent.CategoryAppMessaging);
                if (FindViewById<CheckBox>(Resource.Id.cbAppMusic).Checked) i.AddCategory(Intent.CategoryAppMusic);
                if (FindViewById<CheckBox>(Resource.Id.cbBrowsable).Checked) i.AddCategory(Intent.CategoryBrowsable);
                if (FindViewById<CheckBox>(Resource.Id.cbCarDock).Checked) i.AddCategory(Intent.CategoryCarDock);
                if (FindViewById<CheckBox>(Resource.Id.cbCarMode).Checked) i.AddCategory(Intent.CategoryCarMode);
                if (FindViewById<CheckBox>(Resource.Id.cbDefault).Checked) i.AddCategory(Intent.CategoryDefault);
                if (FindViewById<CheckBox>(Resource.Id.cbDeskDock).Checked) i.AddCategory(Intent.CategoryDeskDock);
                if (FindViewById<CheckBox>(Resource.Id.cbDevelopmentPreference).Checked) i.AddCategory(Intent.CategoryDevelopmentPreference);
                if (FindViewById<CheckBox>(Resource.Id.cbEmbed).Checked) i.AddCategory(Intent.CategoryEmbed);
                if (FindViewById<CheckBox>(Resource.Id.cbFrameworkInstrumentationTest).Checked) i.AddCategory(Intent.CategoryFrameworkInstrumentationTest);
                if (FindViewById<CheckBox>(Resource.Id.cbHeDeskDock).Checked) i.AddCategory(Intent.CategoryHeDeskDock);
                if (FindViewById<CheckBox>(Resource.Id.cbHome).Checked) i.AddCategory(Intent.CategoryHome);
                if (FindViewById<CheckBox>(Resource.Id.cbInfo).Checked) i.AddCategory(Intent.CategoryInfo);
                if (FindViewById<CheckBox>(Resource.Id.cbLauncher).Checked) i.AddCategory(Intent.CategoryLauncher);
                if (FindViewById<CheckBox>(Resource.Id.cbLeanbackLauncher).Checked) i.AddCategory(Intent.CategoryLeanbackLauncher);
                if (FindViewById<CheckBox>(Resource.Id.cbLeDeskDock).Checked) i.AddCategory(Intent.CategoryLeDeskDock);
                if (FindViewById<CheckBox>(Resource.Id.cbMonkey).Checked) i.AddCategory(Intent.CategoryMonkey);
                if (FindViewById<CheckBox>(Resource.Id.cbOpenable).Checked) i.AddCategory(Intent.CategoryOpenable);
                if (FindViewById<CheckBox>(Resource.Id.cbPreference).Checked) i.AddCategory(Intent.CategoryPreference);
                if (FindViewById<CheckBox>(Resource.Id.cbSampleCode).Checked) i.AddCategory(Intent.CategorySampleCode);
                if (FindViewById<CheckBox>(Resource.Id.cbSelectedAlternative).Checked) i.AddCategory(Intent.CategorySelectedAlternative);
                if (FindViewById<CheckBox>(Resource.Id.cbTab).Checked) i.AddCategory(Intent.CategoryTab);
                if (FindViewById<CheckBox>(Resource.Id.cbTest).Checked) i.AddCategory(Intent.CategoryTest);
                //if (FindViewById<CheckBox>(Resource.Id.cbTypedOpenable).Checked) i.AddCategory(Intent.CategoryTypedOpenable);
                if (FindViewById<CheckBox>(Resource.Id.cbUnitTest).Checked) i.AddCategory(Intent.CategoryUnitTest);
                if (FindViewById<CheckBox>(Resource.Id.cbVoice).Checked) i.AddCategory(Intent.CategoryVoice);
                //if (FindViewById<CheckBox>(Resource.Id.cbVrHome).Checked) i.AddCategory(Intent.CategoryVrHome);

                StartActivity(i);
                return true;
            }
            catch (Exception ex)
            {
                // Message(ex.Message);
                return false;
            }
        }
    }
}