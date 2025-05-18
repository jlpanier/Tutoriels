using Tutoriels.Code.Activities;
using Xamarin.Essentials;

namespace Tutoriels.Code.Activities.Text2Speech
{
    [Activity(Label = "Tutorial")]
    public class Text2SpeechActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.Text2SpeechActivity;

        #endregion

        private CancellationTokenSource _token;

        private SpeechOptions _speechOptions;

        private SpinnerAdapter _adapter;


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

            string[] displayedVolume = new string[] { "0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" };
            NumberPicker npVolume = FindViewById<NumberPicker>(Resource.Id.npVolume);
            npVolume.MinValue = 0;
            npVolume.MaxValue = 10;
            npVolume.SetDisplayedValues(displayedVolume);
            npVolume.Value = 5;

            string[] displayedPitch = new string[] { "0", "0.1", "0.2", "0.3", "0.4", "0.5", "0.6", "0.7", "0.8", "0.9", "1.0", "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8", "1.9", "2.0" };
            NumberPicker npPitch = FindViewById<NumberPicker>(Resource.Id.npPitch);
            npPitch.MinValue = 0;
            npPitch.MaxValue = 20;
            npPitch.SetDisplayedValues(displayedPitch);
            npPitch.Value = 10;

            FindViewById<Button>(Resource.Id.btnGo).Click += async (s, e) =>
            {
                string text = FindViewById<EditText>(Resource.Id.edittext).Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    float pitch = (float)npPitch.Value / 10.0f;
                    float volume = (float)npVolume.Value / 10.0f;

                    int position = FindViewById<Spinner>(Resource.Id.spLanguage).SelectedItemPosition;
                    SpeechOptions options = new SpeechOptions()
                    {
                        Pitch = pitch,
                        Volume = volume,
                    };
                    if (position >= 0)
                    {
                        options.Locale = _adapter[position];
                    }
                    await TextToSpeech.SpeakAsync(text, options, _token.Token);
                }
            };
            FindViewById<Button>(Resource.Id.btnCancel).Click += (s, e) =>
            {
                if (_token?.IsCancellationRequested ?? true) return;
                _token.Cancel();
            };

            Load();

            _token = new CancellationTokenSource();

        }

        private void Load()
        {
            IEnumerable<Locale> locales = null;
            var thread = new Thread(async () =>
            {
                try
                {
                    locales = await TextToSpeech.GetLocalesAsync();
                }
                finally
                {
                    RunOnUiThread(() =>
                    {
                        _adapter = new SpinnerAdapter(this, locales.OrderBy(_ => _.Name).ToList());
                        _adapter.SetDropDownViewResource(Resource.Layout.SpinnerText2SpeechLanguageItem);
                        FindViewById<Spinner>(Resource.Id.spLanguage).Adapter = _adapter;
                    });
                }
            });
            thread.Start();
        }
    }
}