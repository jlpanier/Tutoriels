using Android.Views;
using Android.Webkit;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Webview
{
    [Activity(Label = "Tutorial")]
    public class WebViewActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.WebViewActivity;

        #endregion


        private WebView web_view;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            web_view = FindViewById<WebView>(Resource.Id.webview);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetWebViewClient(new CustomViewClient());
            web_view.LoadUrl("http://www.google.com");
        }

        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Keycode.Back && web_view.CanGoBack())
            {
                web_view.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}