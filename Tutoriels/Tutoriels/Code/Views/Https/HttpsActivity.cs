using System.Diagnostics;
using System.Net;
using System.Net.Security;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Http
{
    [Activity(Label = "Tutorial")]
    public class HttpsActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.Https;

        #endregion

        #region life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            List<string> data = new List<string>() { "https://www.prevision-meteo.ch/services/json/list-cities", "http://www.contoso.com/default.html", "https://maree.info/112" };

            Spinner spUrl = FindViewById<Spinner>(Resource.Id.spUrl);
            var adapter = new ArrayAdapter<string>(this, Resource.Layout.spinner_item_url, data);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spUrl.Adapter = adapter;
            spUrl.ItemSelected += (s, e) =>
            {
                Parse(adapter.GetItem(e.Position));
            };

        }

        #endregion

        #region User Interface

        private void Parse(string url)
        {
            if (!_processing)
            {
                SetProcess(true);

                try
                {
                    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicy) =>
                    {
                        bool policysecure = false;
                        switch (sslPolicy)
                        {
                            case SslPolicyErrors.None:
                                policysecure = true;
                                break;
                            case SslPolicyErrors.RemoteCertificateNotAvailable:
                                break;
                            case SslPolicyErrors.RemoteCertificateNameMismatch:
                                break;
                            case SslPolicyErrors.RemoteCertificateChainErrors:
                                policysecure = true; // (((HttpWebRequest)sender).RequestUri.Authority.Equals("maree.info"));
                                break;
                        }
                        return policysecure;
                    };

                    var request = HttpWebRequest.CreateHttp(new Uri(url));
                    request.Method = "GET";
                    request.Credentials = CredentialCache.DefaultCredentials;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        var dataStream = response.GetResponseStream();
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string answer = reader.ReadToEnd();
                            sw.Stop();
                            SetProcess(false);

                            FindViewById<TextView>(Resource.Id.tvTime).Text = (sw.ElapsedMilliseconds / 1000).ToString("N1");
                            FindViewById<TextView>(Resource.Id.tvStatus).Text = response.StatusCode.ToString();
                            FindViewById<TextView>(Resource.Id.tvStatusDescription).Text = response.StatusDescription;
                            FindViewById<TextView>(Resource.Id.tvServer).Text = response.Server;
                            FindViewById<TextView>(Resource.Id.tvProtocol).Text = response.ProtocolVersion.ToString();
                            FindViewById<TextView>(Resource.Id.tvMethod).Text = response.Method;
                            FindViewById<TextView>(Resource.Id.tvLastModified).Text = response.LastModified.ToString();
                            FindViewById<TextView>(Resource.Id.tvContentLength).Text = response.ContentLength.ToString();
                            FindViewById<TextView>(Resource.Id.tvContentType).Text = response.ContentType;
                            FindViewById<TextView>(Resource.Id.tvResponse).Text = answer;

                            dataStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (WebException ex)
                {
                    FindViewById<TextView>(Resource.Id.tvTime).Text = (sw.ElapsedMilliseconds / 1000).ToString("N1");
                    FindViewById<TextView>(Resource.Id.tvStatus).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvStatusDescription).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvServer).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvProtocol).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvMethod).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvLastModified).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvContentLength).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvContentType).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvResponse).Text = ex.ToString();

                    SetProcess(false);

                }
                catch (Exception ex)
                {
                    FindViewById<TextView>(Resource.Id.tvTime).Text = (sw.ElapsedMilliseconds / 1000).ToString("N1");
                    FindViewById<TextView>(Resource.Id.tvStatus).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvStatusDescription).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvServer).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvProtocol).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvMethod).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvLastModified).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvContentLength).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvContentType).Text = string.Empty;
                    FindViewById<TextView>(Resource.Id.tvResponse).Text = ex.ToString();

                    SetProcess(false);
                }
            }
        }

        private void Reset()
        {
            FindViewById<TextView>(Resource.Id.tvTime).Text = (sw.ElapsedMilliseconds / 1000).ToString("N1");
            FindViewById<TextView>(Resource.Id.tvStatus).Text = string.Empty;
            FindViewById<TextView>(Resource.Id.tvStatusDescription).Text = string.Empty;
            FindViewById<TextView>(Resource.Id.tvServer).Text = string.Empty;
            FindViewById<TextView>(Resource.Id.tvProtocol).Text = string.Empty;
            FindViewById<TextView>(Resource.Id.tvMethod).Text = string.Empty;
            FindViewById<TextView>(Resource.Id.tvLastModified).Text = string.Empty;
            FindViewById<TextView>(Resource.Id.tvContentLength).Text = string.Empty;
            FindViewById<TextView>(Resource.Id.tvContentType).Text = string.Empty;
            FindViewById<TextView>(Resource.Id.tvResponse).Text = string.Empty;
        }

        private void SetProcess(bool processing)
        {
            _processing = processing;

            if (_processing)
                sw.Reset();
            else sw.Stop();

            FindViewById<LinearLayout>(Resource.Id.layoutresult).Visibility = _processing ? Android.Views.ViewStates.Gone : Android.Views.ViewStates.Visible;
            FindViewById<ProgressBar>(Resource.Id.progressbar).Visibility = _processing ? Android.Views.ViewStates.Visible : Android.Views.ViewStates.Gone;
        }
        private bool _processing = false;
        private readonly Stopwatch sw = new Stopwatch();


        #endregion
    }
}