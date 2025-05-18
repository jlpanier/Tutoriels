using Android.Graphics;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.ProgresssBar
{
    [Activity(Label = "Tutorial")]
    public class ProgresssBarActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.ProgressBarActivity;

        #endregion

        #region Life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            List<string> data = new List<string>();
            data.Add(PorterDuff.Mode.Multiply.ToString());
            data.Add(PorterDuff.Mode.SrcIn.ToString());
            data.Add(PorterDuff.Mode.SrcAtop.ToString());
            data.Add(PorterDuff.Mode.Src.ToString());
            data.Add(PorterDuff.Mode.Screen.ToString());
            data.Add(PorterDuff.Mode.Overlay.ToString());
            data.Add(PorterDuff.Mode.Xor.ToString());
            data.Add(PorterDuff.Mode.Lighten.ToString());
            data.Add(PorterDuff.Mode.SrcOut.ToString());
            data.Add(PorterDuff.Mode.DstOver.ToString());
            data.Add(PorterDuff.Mode.DstIn.ToString());
            data.Add(PorterDuff.Mode.DstAtop.ToString());
            data.Add(PorterDuff.Mode.Dst.ToString());
            data.Add(PorterDuff.Mode.Darken.ToString());
            data.Add(PorterDuff.Mode.Clear.ToString());
            data.Add(PorterDuff.Mode.Add.ToString());
            data.Add(PorterDuff.Mode.DstOut.ToString());
            data.Add(PorterDuff.Mode.SrcOver.ToString());



            Spinner sp = FindViewById<Spinner>(Resource.Id.spBackground);
            var adapter = new ArrayAdapter<string>(this, Resource.Layout.spinner_item_url, data);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp.Adapter = adapter;
            sp.ItemSelected += (s, e) =>
            {
                SetBackground(Convert(adapter.GetItem(e.Position)));
            };
            //int position = 0;
            //while (position < data.Count)
            //{
            //    if (adapter.GetItem(position) == FindViewById<ProgressBar>(Resource.Id.progressBarStyle).BackgroundTintMode.ToString())
            //    {
            //        sp.SetSelection(position);
            //    }
            //    position++;
            //}


            sp = FindViewById<Spinner>(Resource.Id.spIndeterminate);
            sp.Adapter = adapter;
            sp.ItemSelected += (s, e) =>
            {
                SetIndeterminateTintMode(Convert(adapter.GetItem(e.Position)));
            };
            //position = 0;
            //while (position < data.Count)
            //{
            //    if (adapter.GetItem(position) == FindViewById<ProgressBar>(Resource.Id.progressBarStyle).IndeterminateTintMode.ToString())
            //    {
            //        sp.SetSelection(position);
            //    }
            //    position++;
            //}

            sp = FindViewById<Spinner>(Resource.Id.spProgress);
            sp.Adapter = adapter;
            sp.ItemSelected += (s, e) =>
            {
                SetProgressTintMode(Convert(adapter.GetItem(e.Position)));
            };
            //position = 0;
            //while (position < data.Count)
            //{
            //    if (adapter.GetItem(position) == FindViewById<ProgressBar>(Resource.Id.progressBarStyle).ProgressTintMode.ToString())
            //    {
            //        sp.SetSelection(position);
            //    }
            //    position++;
            //}



            FindViewById<EditText>(Resource.Id.edtMin).AfterTextChanged += (s, e) => { Reset(); };
            FindViewById<EditText>(Resource.Id.edtMax).AfterTextChanged += (s, e) => { Reset(); };
            FindViewById<EditText>(Resource.Id.edtProgress).AfterTextChanged += (s, e) => { Reset(); };
            FindViewById<CheckBox>(Resource.Id.cbIndeterminate).CheckedChange += (s, e) => { Reset(); };
            FindViewById<CheckBox>(Resource.Id.cbAnimate).CheckedChange += (s, e) => { Reset(); };

            Reset();
        }

        private void SetBackground(PorterDuff.Mode mode)
        {
            FindViewById<ProgressBar>(Resource.Id.progressBarStyle).ProgressBackgroundTintMode = mode;
            FindViewById<ProgressBar>(Resource.Id.progressBarStyleHorizontal).ProgressBackgroundTintMode = mode;
            FindViewById<ProgressBar>(Resource.Id.progressBarStyleLarge).ProgressBackgroundTintMode = mode;
            FindViewById<ProgressBar>(Resource.Id.progressBarStyleSmall).ProgressBackgroundTintMode = mode;
        }

        private void SetIndeterminateTintMode(PorterDuff.Mode mode)
        {
            FindViewById<ProgressBar>(Resource.Id.progressBarStyle).IndeterminateTintMode = mode;
            FindViewById<ProgressBar>(Resource.Id.progressBarStyleHorizontal).IndeterminateTintMode = mode;
            FindViewById<ProgressBar>(Resource.Id.progressBarStyleLarge).IndeterminateTintMode = mode;
            FindViewById<ProgressBar>(Resource.Id.progressBarStyleSmall).IndeterminateTintMode = mode;
        }

        private void SetProgressTintMode(PorterDuff.Mode mode)
        {
            FindViewById<ProgressBar>(Resource.Id.progressBarStyle).ProgressTintMode = mode;
            FindViewById<ProgressBar>(Resource.Id.progressBarStyleHorizontal).ProgressTintMode = mode;
            FindViewById<ProgressBar>(Resource.Id.progressBarStyleLarge).ProgressTintMode = mode;
            FindViewById<ProgressBar>(Resource.Id.progressBarStyleSmall).ProgressTintMode = mode;
        }

        private void Reset()
        {
            try
            {
                int minvalue = int.Parse(FindViewById<EditText>(Resource.Id.edtMin).Text);
                int maxvalue = int.Parse(FindViewById<EditText>(Resource.Id.edtMax).Text);
                int progress = int.Parse(FindViewById<EditText>(Resource.Id.edtProgress).Text);

                ProgressBar pg = FindViewById<ProgressBar>(Resource.Id.progressBarStyle);
                pg.Min = minvalue;
                pg.Max = maxvalue;
                pg.Indeterminate = FindViewById<CheckBox>(Resource.Id.cbIndeterminate).Checked;
                pg.SetProgress(progress, FindViewById<CheckBox>(Resource.Id.cbAnimate).Checked);

                pg = FindViewById<ProgressBar>(Resource.Id.progressBarStyleHorizontal);
                pg.Min = minvalue;
                pg.Max = maxvalue;
                pg.Indeterminate = FindViewById<CheckBox>(Resource.Id.cbIndeterminate).Checked;
                pg.SetProgress(progress, FindViewById<CheckBox>(Resource.Id.cbAnimate).Checked);

                pg = FindViewById<ProgressBar>(Resource.Id.progressBarStyleLarge);
                pg.Min = minvalue;
                pg.Max = maxvalue;
                pg.Indeterminate = FindViewById<CheckBox>(Resource.Id.cbIndeterminate).Checked;
                pg.SetProgress(progress, FindViewById<CheckBox>(Resource.Id.cbAnimate).Checked);

                pg = FindViewById<ProgressBar>(Resource.Id.progressBarStyleSmall);
                pg.Min = minvalue;
                pg.Max = maxvalue;
                pg.Indeterminate = FindViewById<CheckBox>(Resource.Id.cbIndeterminate).Checked;
                pg.SetProgress(progress, FindViewById<CheckBox>(Resource.Id.cbAnimate).Checked);
            }
            catch
            {
                // Never mind
            }
        }

        private PorterDuff.Mode Convert(string data)
        {
            PorterDuff.Mode mode = PorterDuff.Mode.SrcOut;
            if (data == PorterDuff.Mode.Multiply.ToString())
            {
                mode = PorterDuff.Mode.Multiply;
            }
            else if (data == PorterDuff.Mode.SrcIn.ToString())
            {
                mode = PorterDuff.Mode.SrcIn;
            }
            else if (data == PorterDuff.Mode.SrcAtop.ToString())
            {
                mode = PorterDuff.Mode.SrcAtop;
            }
            else if (data == PorterDuff.Mode.Src.ToString())
            {
                mode = PorterDuff.Mode.Src;
            }
            else if (data == PorterDuff.Mode.Screen.ToString())
            {
                mode = PorterDuff.Mode.Screen;
            }
            else if (data == PorterDuff.Mode.Overlay.ToString())
            {
                mode = PorterDuff.Mode.Overlay;
            }
            else if (data == PorterDuff.Mode.Xor.ToString())
            {
                mode = PorterDuff.Mode.Xor;
            }
            else if (data == PorterDuff.Mode.Lighten.ToString())
            {
                mode = PorterDuff.Mode.Lighten;
            }
            else if (data == PorterDuff.Mode.SrcOut.ToString())
            {
                mode = PorterDuff.Mode.SrcOut;
            }
            else if (data == PorterDuff.Mode.DstOver.ToString())
            {
                mode = PorterDuff.Mode.DstOver;
            }
            else if (data == PorterDuff.Mode.DstIn.ToString())
            {
                mode = PorterDuff.Mode.DstIn;
            }
            else if (data == PorterDuff.Mode.DstAtop.ToString())
            {
                mode = PorterDuff.Mode.DstAtop;
            }
            else if (data == PorterDuff.Mode.Dst.ToString())
            {
                mode = PorterDuff.Mode.Dst;
            }
            else if (data == PorterDuff.Mode.Darken.ToString())
            {
                mode = PorterDuff.Mode.Darken;
            }
            else if (data == PorterDuff.Mode.Clear.ToString())
            {
                mode = PorterDuff.Mode.Clear;
            }
            else if (data == PorterDuff.Mode.Add.ToString())
            {
                mode = PorterDuff.Mode.Add;
            }
            else if (data == PorterDuff.Mode.DstOut.ToString())
            {
                mode = PorterDuff.Mode.DstOut;
            }
            else if (data == PorterDuff.Mode.SrcOver.ToString())
            {
                mode = PorterDuff.Mode.SrcOver;
            }
            return mode;
        }

        #endregion
    }
}