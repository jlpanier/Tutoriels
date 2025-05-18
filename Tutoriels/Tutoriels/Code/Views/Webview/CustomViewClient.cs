using Android.Webkit;

namespace Tutoriels.Code.Activities.Webview
{
    public class CustomViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return false;
        }
    }
}