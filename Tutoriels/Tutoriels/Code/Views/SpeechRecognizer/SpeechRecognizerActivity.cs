using Android.Content;
using Android.Graphics.Drawables;
using Android.Speech;
using Common;
using Xamarin.Essentials;
using static Tutoriels.Code.BaseActivity;

namespace Tutoriels.Code.Activities.SpeechRecognizer
{
    [Activity(Label = "Tutorial")]
    public class SpeechRecognizerActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.SpeechActivity;

        #endregion

        private ListViewAdapter _adapter;

        private CustomRecognizer _recognizer;

        private AnimationDrawable _animationlisten;

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

            _recognizer = new CustomRecognizer(this);
            _recognizer.SpeechRecognizerEvent += (s, e) =>
            {
                switch (e.Statut)
                {
                    case SpeechRecognizerError.Audio:
                        break;
                    case SpeechRecognizerError.Client:
                        NextMove(e.Message);
                        break;
                    case SpeechRecognizerError.InsufficientPermissions:
                        break;
                    case SpeechRecognizerError.Network:
                        break;
                    case SpeechRecognizerError.NetworkTimeout:
                        break;
                    case SpeechRecognizerError.NoMatch:
                        StartListening();
                        break;
                    case SpeechRecognizerError.RecognizerBusy:
                        break;
                    case SpeechRecognizerError.Server:
                        break;
                    case SpeechRecognizerError.SpeechTimeout:
                        break;
                }
            };
            FindViewById<Button>(Resource.Id.btnGo).Click += (s, e) =>
            {
                StartListening();
            };

            _animationlisten = (AnimationDrawable)Resources.GetDrawable(Resource.Drawable.ecoute_animation);
            FindViewById<ImageView>(Resource.Id.imgListen).SetImageDrawable(_animationlisten);

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

        private void StartListening()
        {
            _animationlisten.Start();
            _recognizer.StartListening();
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
            _recognizer.StopListening();
            _animationlisten.Stop();

            string compareMessage = message.ToUpper().Trim();

            bool recognition = false;
            foreach (Conversations item in Enum.GetValues(typeof(Conversations)))
            {
                if (item.GetCodeValue() == compareMessage)
                {
                    recognition = true;
                    Task.Run(async () =>
                    {
                        await Speak(item.GetStringValue());
                        RunOnUiThread(() =>
                        {
                            Add(item.GetStringValue(), false);
                            StartListening();
                        });
                    });
                }
            }
            if (!recognition)
            {
                StartListening();
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