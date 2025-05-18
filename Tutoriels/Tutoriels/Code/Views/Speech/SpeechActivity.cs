using Android.Content;
using Android.Speech;
using Xamarin.Essentials;
using Common;
using static Tutoriels.Code.BaseActivity;

namespace Tutoriels.Code.Activities.Speech
{
    [Activity(Label = "Tutorial")]
    public class SpeechActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.SpeechActivity;

        #endregion

        private ListViewAdapter _adapter;

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

            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            FindViewById<TextView>(Resource.Id.tvSpeaker).Text = rec;

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

            FindViewById<ListView>(Resource.Id.lvSpeech).Adapter = _adapter = new ListViewAdapter(this);

            FindViewById<Button>(Resource.Id.btnGo).Click += (s, e) => { Listen(); };

            Start();

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            switch (requestCode)
            {
                case RequestCode.Voice:
                    if (resultCode == Result.Ok)
                    {
                        var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                        if (matches.Count != 0)
                        {
                            Add(matches[0], true);
                            if (!string.IsNullOrEmpty(matches[0]))
                            {
                                NextMove(matches[0].ToUpper());
                            }
                        }
                    }
                    break;
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }

        #endregion

        private void Start()
        {
            Listen();
        }

        private void Listen()
        {
            var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Dictate Speech");
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
            voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
            StartActivityForResult(voiceIntent, RequestCode.Voice);
        }

        /// <summary>
        /// Etat du service
        /// </summary>
        private enum Conversations
        {
            [StringValue("Bonjour, ça va?")]
            [CodeValue("BONJOUR")]
            Bonjour,
            [StringValue("Heureux d'entendre cela...")]
            [CodeValue("ÇA VA")]
            CaVa,
            [StringValue("OK")]
            [CodeValue("OK")]
            Ok,
            [StringValue("Ah bon!!!")]
            [CodeValue("AH BON")]
            AhBon,
            [StringValue("Très bien...")]
            [CodeValue("OUI ÇA VA")]
            OuiCaVa,
            [StringValue("Non")]
            [CodeValue("OUI")]
            Oui,
            [StringValue("Certes...")]
            [CodeValue("NON")]
            Non,
            [StringValue("Eh si!!!")]
            [CodeValue("C'EST PAS VRAI")]
            C_Est_Pas_Vrai,
            [StringValue("Restez polie")]
            [CodeValue("MERDE")]
            Merde,
            [StringValue("Effectivement")]
            [CodeValue("COOL")]
            Cool,
        }

        private void NextMove(string message)
        {
            foreach (Conversations item in Enum.GetValues(typeof(Conversations)))
            {
                if (item.GetCodeValue() == message)
                {
                    Task.Run(async () =>
                    {
                        Add(item.GetStringValue(), false);
                        await Speak(item.GetStringValue());
                        Listen();
                    });
                }
            }
        }

        private async Task Speak(string message)
        {
            float pitch = (float)(FindViewById<NumberPicker>(Resource.Id.npPitch).Value) / 10.0f;
            float volume = (float)(FindViewById<NumberPicker>(Resource.Id.npVolume).Value) / 10.0f;
            SpeechOptions options = new SpeechOptions()
            {
                Pitch = pitch,
                Volume = volume,
            };
            await Xamarin.Essentials.TextToSpeech.SpeakAsync(message, options);
        }

        private void Add(string message, bool inout)
        {
            _adapter.Add(new ListViewAdapterItem()
            {
                InOut = inout,
                Message = message,
                DateOn = DateTime.Now
            });
            _adapter.NotifyDataSetChanged();
        }
    }
}