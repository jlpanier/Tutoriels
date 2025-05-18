using Common;
using System.Diagnostics;
using System.Net;
using System.Net.Security;

namespace Tutoriels.Code.Activities.MareeInfo
{
    [Activity(Label = "Tutorial")]
    public class MareeInfoActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.MareeInfoActivity;

        #endregion

        #region Internal Variable

        private ListViewMaréeAdaptator _adapter;

        #endregion

        #region life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViewById<ListView>(Resource.Id.lvMarees).Adapter = _adapter = new ListViewMaréeAdaptator(this);

            List<string> data = new List<string>() { "https://maree.info/112", "https://maree.info/86" };

            Spinner spUrl = FindViewById<Spinner>(Resource.Id.spUrl);
            var adapter = new ArrayAdapter<string>(this, Resource.Layout.spinner_item_url, data);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spUrl.Adapter = adapter;
            spUrl.ItemSelected += (s, e) =>
            {
                CallwebsiteInfoMarée(adapter.GetItem(e.Position));
            };

        }

        #endregion

        #region User Interface

        private void CallwebsiteInfoMarée(string url)
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
                                policysecure = (((HttpWebRequest)sender).RequestUri.Authority.Equals("maree.info"));
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

                            List<DataInfoMarée> infomaree = new List<DataInfoMarée>();

                            DateTime dt = DateTime.Now.Date;
                            List<DataMarée> dataset = Parse(answer.Between("<tr class=\"MJ MJ0\" id=\"MareeJours_0\" title=\"UTC+1\" onclick=\"return GoMareeJour(0)\">", "</tr>", StringComparison.CurrentCultureIgnoreCase).Remove("<th>", "</th>", StringComparison.CurrentCultureIgnoreCase));
                            foreach (DataMarée data in dataset)
                            {
                                infomaree.Add(new DataInfoMarée(new DateTime(dt.Year, dt.Month, dt.Day, data.Horaire.Hours, data.Horaire.Minutes, 0), data.Hauteur, data.Coefficient));
                            }
                            dt = dt.AddDays(1);
                            dataset = Parse(answer.Between("<tr class=\"MJ MJ1\" id=\"MareeJours_1\" title=\"UTC+1\" onclick=\"return GoMareeJour(1)\">", "</tr>", StringComparison.CurrentCultureIgnoreCase).Remove("<th>", "</th>", StringComparison.CurrentCultureIgnoreCase));
                            foreach (DataMarée data in dataset)
                            {
                                infomaree.Add(new DataInfoMarée(new DateTime(dt.Year, dt.Month, dt.Day, data.Horaire.Hours, data.Horaire.Minutes, 0), data.Hauteur, data.Coefficient));
                            }
                            dt = dt.AddDays(1);
                            dataset = Parse(answer.Between("<tr class=\"MJ MJ0\" id=\"MareeJours_2\" title=\"UTC+1\" onclick=\"return GoMareeJour(2)\">", "</tr>", StringComparison.CurrentCultureIgnoreCase).Remove("<th>", "</th>", StringComparison.CurrentCultureIgnoreCase));
                            foreach (DataMarée data in dataset)
                            {
                                infomaree.Add(new DataInfoMarée(new DateTime(dt.Year, dt.Month, dt.Day, data.Horaire.Hours, data.Horaire.Minutes, 0), data.Hauteur, data.Coefficient));
                            }
                            dt = dt.AddDays(1);
                            dataset = Parse(answer.Between("<tr class=\"MJ MJ1\" id=\"MareeJours_3\" title=\"UTC+1\" onclick=\"return GoMareeJour(3)\">", "</tr>", StringComparison.CurrentCultureIgnoreCase).Remove("<th>", "</th>", StringComparison.CurrentCultureIgnoreCase));
                            foreach (DataMarée data in dataset)
                            {
                                infomaree.Add(new DataInfoMarée(new DateTime(dt.Year, dt.Month, dt.Day, data.Horaire.Hours, data.Horaire.Minutes, 0), data.Hauteur, data.Coefficient));
                            }
                            dt = dt.AddDays(1);
                            dataset = Parse(answer.Between("<tr class=\"MJ MJ0\" id=\"MareeJours_4\" title=\"UTC+1\" onclick=\"return GoMareeJour(4)\">", "</tr>", StringComparison.CurrentCultureIgnoreCase).Remove("<th>", "</th>", StringComparison.CurrentCultureIgnoreCase));
                            foreach (DataMarée data in dataset)
                            {
                                infomaree.Add(new DataInfoMarée(new DateTime(dt.Year, dt.Month, dt.Day, data.Horaire.Hours, data.Horaire.Minutes, 0), data.Hauteur, data.Coefficient));
                            }
                            dt = dt.AddDays(1);
                            dataset = Parse(answer.Between("<tr class=\"MJ MJ1\" id=\"MareeJours_5\" title=\"UTC+1\" onclick=\"return GoMareeJour(5)\">", "</tr>", StringComparison.CurrentCultureIgnoreCase).Remove("<th>", "</th>", StringComparison.CurrentCultureIgnoreCase));
                            foreach (DataMarée data in dataset)
                            {
                                infomaree.Add(new DataInfoMarée(new DateTime(dt.Year, dt.Month, dt.Day, data.Horaire.Hours, data.Horaire.Minutes, 0), data.Hauteur, data.Coefficient));
                            }
                            dt = dt.AddDays(1);
                            dataset = Parse(answer.Between("<tr class=\"MJ MJ0\" id=\"MareeJours_6\" title=\"UTC+1\" onclick=\"return GoMareeJour(6)\">", "</tr>", StringComparison.CurrentCultureIgnoreCase).Remove("<th>", "</th>", StringComparison.CurrentCultureIgnoreCase));
                            foreach (DataMarée data in dataset)
                            {
                                infomaree.Add(new DataInfoMarée(new DateTime(dt.Year, dt.Month, dt.Day, data.Horaire.Hours, data.Horaire.Minutes, 0), data.Hauteur, data.Coefficient));
                            }

                            _adapter.Reset(infomaree);

                            dataStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (WebException ex)
                {
                    SetProcess(false);

                    Reset();

                    FindViewById<TextView>(Resource.Id.tvResponse).Text = ex.ToString();
                }
                catch (Exception ex)
                {
                    SetProcess(false);
                    Reset();
                }
            }
        }

        private List<DataMarée> Parse(string data)
        {
            List<DataMarée> result = new List<DataMarée>();
            var aHoraire = data.Between("<td>", "</td>", StringComparison.CurrentCultureIgnoreCase).Replace("<td>", "").Replace("</td>", "").Replace("<b>", "").Replace("</b>", "").Replace("<br>", ";").Split(";");
            string current = data.Remove("<td>", "</td>", StringComparison.CurrentCultureIgnoreCase);
            var aHauteur = current.Between("<td>", "</td>", StringComparison.CurrentCultureIgnoreCase).Replace("<td>", "").Replace("</td>", "").Replace("<b>", "").Replace("</b>", "").Replace("<br>", ";").Split(";");
            string coeffs = current.Remove("<td>", "</td>", StringComparison.CurrentCultureIgnoreCase).Between("<td>", "</td>", StringComparison.CurrentCultureIgnoreCase);
            var aCoeffs = coeffs.Replace("<td>", "").Replace("</td>", "").Replace("<b>", "").Replace("</b>", "").Replace("<br>", ";").Split(";");

            int previouscoefficient = 70;
            int len = aHoraire.Length;
            for (int i = 0; i < len; i++)
            {
                // <td><b>01h07</b><br>07h16<br><b>13h29</b><br>19h51</td>
                // <td><b>5,10m</b><br>2,11m<br><b>5,41m</b><br>1,69m</td>
                // <td><b>54</b><br>&nbsp;<br><b>62</b><br>&nbsp;</td>

                string horaire = aHoraire[i];
                int heure = int.Parse(horaire.Substring(0, 2));
                int minute = int.Parse(horaire.Substring(3, 2));

                string hauteur = aHauteur[i];

                double h = 0;
                if (double.TryParse(hauteur.Replace("m", ""), out double h1))
                {
                    h = h1;
                }
                else
                {
                    h = 0;
                }


                if (int.TryParse(aCoeffs[i], out int coeff))
                {
                    result.Add(new DataMarée(heure, minute, h, coeff));
                    previouscoefficient = coeff;
                }
                else
                {
                    result.Add(new DataMarée(heure, minute, h, previouscoefficient));
                }
            }
            return result;

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

        #region HTML

        private static string ParseHtml(string html)
        {
            string source = html.Remove("<!--", "-->", StringComparison.CurrentCultureIgnoreCase);
            string result = source.Remove("<!--", "-->", StringComparison.CurrentCultureIgnoreCase);
            while (result != source)
            {
                source = result;
                result = source.Remove("<!--", "-->", StringComparison.CurrentCultureIgnoreCase);
            }
            result = source.Remove("<script", "</script>", StringComparison.CurrentCultureIgnoreCase);
            while (result != source)
            {
                source = result;
                result = source.Remove("<script", "</script>", StringComparison.CurrentCultureIgnoreCase);
            }
            result = source.Remove("<head>", "</head>", StringComparison.CurrentCultureIgnoreCase);
            while (result != source)
            {
                source = result;
                result = source.Remove("<head>", "</head>", StringComparison.CurrentCultureIgnoreCase);
            }
            result = source.Between("<body id=\"Body\" class=\"Rounded\" ontouchstart=\"\">", "</body>", StringComparison.CurrentCultureIgnoreCase);
            return result;
        }

        #endregion


    }
}