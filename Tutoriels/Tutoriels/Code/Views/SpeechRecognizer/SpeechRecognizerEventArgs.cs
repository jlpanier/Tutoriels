using Android.Speech;
using System;

namespace Tutoriels.Code.Activities.SpeechRecognizer
{
    internal class SpeechRecognizerEventArgs : EventArgs
    {
        public SpeechRecognizerError Statut { get; private set; }

        public string Message { get; private set; }

        public SpeechRecognizerEventArgs(string message)
        {
            Statut = SpeechRecognizerError.Client;
            Message = message;
        }
        public SpeechRecognizerEventArgs(SpeechRecognizerError statut)
        {
            Statut = statut;
            Message = string.Empty;
        }
    }
}