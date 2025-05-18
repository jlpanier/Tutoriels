using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using Android.Speech.Tts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tutoriels.Code.Activities.SpeechRecognizer
{
    public class CustomRecognizer : Java.Lang.Object, IRecognitionListener, TextToSpeech.IOnInitListener
    {
        private readonly Android.Speech.SpeechRecognizer _speech;
        private readonly Intent _speechIntent;
        private readonly Context _context;
        internal event EventHandler<SpeechRecognizerEventArgs> SpeechRecognizerEvent;


        public CustomRecognizer(Context _context)
        {
            this._context = _context;
            _speech = Android.Speech.SpeechRecognizer.CreateSpeechRecognizer(_context);
            _speech.SetRecognitionListener(this);
            _speechIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            _speechIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            _speechIntent.PutExtra(RecognizerIntent.ActionRecognizeSpeech, RecognizerIntent.ExtraPreferOffline);
            _speechIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1000);
            _speechIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1000);
            _speechIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 1500);
        }

        public void StartListening()
        {
            currentCompletion = new TaskCompletionSource<IList<string>>();
            _speech.StartListening(_speechIntent);
        }

        public void StopListening()
        {
            _speech.StopListening();
        }

        public void OnBeginningOfSpeech()
        {

        }

        public void OnBufferReceived(byte[] buffer)
        {
        }

        public void OnEndOfSpeech()
        {

        }

        public void OnError([GeneratedEnum] SpeechRecognizerError error)
        {
            switch (error)
            {
                case SpeechRecognizerError.Audio:
                    break;
                case SpeechRecognizerError.Client:
                    break;
                case SpeechRecognizerError.InsufficientPermissions:
                    break;
                case SpeechRecognizerError.Network:
                    break;
                case SpeechRecognizerError.NetworkTimeout:
                    break;
                case SpeechRecognizerError.NoMatch:
                    SpeechRecognizerEvent?.Invoke(this, new SpeechRecognizerEventArgs(SpeechRecognizerError.NoMatch));
                    break;
                case SpeechRecognizerError.RecognizerBusy:
                    break;
                case SpeechRecognizerError.Server:
                    break;
                case SpeechRecognizerError.SpeechTimeout:
                    break;
            }
        }

        public void OnEvent(int eventType, Bundle @params)
        {
        }

        public void OnPartialResults(Bundle partialResults)
        {
        }

        public void OnReadyForSpeech(Bundle @params)
        {
        }

        public void OnResults(Bundle results)
        {
            var matches = results.GetStringArrayList(Android.Speech.SpeechRecognizer.ResultsRecognition);
            if (matches != null && matches.Count > 0)
            {
                SpeechRecognizerEvent?.Invoke(this, new SpeechRecognizerEventArgs(matches[0]));
            }
        }


        public void OnRmsChanged(float rmsdB)
        {

        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            //   if (status == OperationResult.Error)
            //      txtspeech.SetLanguage(Java.Util.Locale.Default);
        }



        private void RecognizerResults(object sender, ResultsEventArgs e)
        {
            currentCompletion.SetResult(e.Results.GetStringArrayList(Android.Speech.SpeechRecognizer.ResultsRecognition));
            _speech.Results -= RecognizerResults;
        }

        private TaskCompletionSource<IList<string>> currentCompletion;
    }
}