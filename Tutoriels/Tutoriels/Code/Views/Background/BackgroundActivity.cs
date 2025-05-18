using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Background
{
    [Activity(Label = "Tutorial")]
    public class BackgroundActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.BackgroundActivity;

        #endregion

        #region Life cycle

        private GradientDrawable.Orientation? _orientation = GradientDrawable.Orientation.TrBl;
        private int _red1 = 255;
        private int _green1 = 255;
        private int _blue1 = 255;
        private int _red2 = 240;
        private int _green2 = 180;
        private int _blue2 = 255;
        private int _red3 = 220;
        private int _green3 = 0;
        private int _blue3 = 255;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FindViewById<RadioButton>(Resource.Id.radioBlTr).CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    _orientation = GradientDrawable.Orientation.TrBl;
                    Set();
                }
            };
            FindViewById<RadioButton>(Resource.Id.radioBottomTop).CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    _orientation = GradientDrawable.Orientation.BottomTop;
                    Set();
                }
            };
            FindViewById<RadioButton>(Resource.Id.radioBrTl).CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    _orientation = GradientDrawable.Orientation.BrTl;
                    Set();
                }
            };
            FindViewById<RadioButton>(Resource.Id.radioLeftRight).CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    _orientation = GradientDrawable.Orientation.LeftRight;
                    Set();
                }
            };
            FindViewById<RadioButton>(Resource.Id.radioRightLeft).CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    _orientation = GradientDrawable.Orientation.RightLeft;
                    Set();
                }
            };
            FindViewById<RadioButton>(Resource.Id.radioTlBr).CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    _orientation = GradientDrawable.Orientation.TlBr;
                    Set();
                }
            };
            FindViewById<RadioButton>(Resource.Id.radioTopBottom).CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    _orientation = GradientDrawable.Orientation.TopBottom;
                    Set();
                }
            };
            FindViewById<RadioButton>(Resource.Id.radioTrBl).CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    _orientation = GradientDrawable.Orientation.TrBl;
                    Set();
                }
            };
            FindViewById<EditText>(Resource.Id.tvRed1).AfterTextChanged += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.tvRed1).Text, out int couleur) && couleur < 256)
                {
                    _red1 = couleur;
                    Set();
                }
            };
            FindViewById<EditText>(Resource.Id.tvRed2).AfterTextChanged += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.tvRed2).Text, out int couleur) && couleur < 256)
                {
                    _red2 = couleur;
                    Set();
                }
            };
            FindViewById<EditText>(Resource.Id.tvRed3).AfterTextChanged += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.tvRed3).Text, out int couleur) && couleur < 256)
                {
                    _red3 = couleur;
                    Set();
                }
            };
            FindViewById<EditText>(Resource.Id.tvBlue1).AfterTextChanged += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.tvBlue1).Text, out int couleur) && couleur < 256)
                {
                    _blue1 = couleur;
                    Set();
                }
            };
            FindViewById<EditText>(Resource.Id.tvBlue2).AfterTextChanged += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.tvBlue2).Text, out int couleur) && couleur < 256)
                {
                    _blue2 = couleur;
                    Set();
                }
            };
            FindViewById<EditText>(Resource.Id.tvBlue3).AfterTextChanged += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.tvBlue3).Text, out int couleur) && couleur < 256)
                {
                    _blue3 = couleur;
                    Set();
                }
            };
            FindViewById<EditText>(Resource.Id.tvGreen1).AfterTextChanged += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.tvGreen1).Text, out int couleur) && couleur < 256)
                {
                    _green1 = couleur;
                    Set();
                }
            };
            FindViewById<EditText>(Resource.Id.tvGreen2).AfterTextChanged += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.tvGreen2).Text, out int couleur) && couleur < 256)
                {
                    _green2 = couleur;
                    Set();
                }
            };
            FindViewById<EditText>(Resource.Id.tvGreen3).AfterTextChanged += (s, e) =>
            {
                if (int.TryParse(FindViewById<EditText>(Resource.Id.tvGreen3).Text, out int couleur) && couleur < 256)
                {
                    _green3 = couleur;
                    Set();
                }
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            FindViewById<EditText>(Resource.Id.tvRed1).Text = _red1.ToString();
            FindViewById<EditText>(Resource.Id.tvRed2).Text = _red2.ToString();
            FindViewById<EditText>(Resource.Id.tvRed3).Text = _red3.ToString();
            FindViewById<EditText>(Resource.Id.tvBlue1).Text = _blue1.ToString();
            FindViewById<EditText>(Resource.Id.tvBlue2).Text = _blue2.ToString();
            FindViewById<EditText>(Resource.Id.tvBlue3).Text = _blue3.ToString();
            FindViewById<EditText>(Resource.Id.tvGreen1).Text = _green1.ToString();
            FindViewById<EditText>(Resource.Id.tvGreen2).Text = _green2.ToString();
            FindViewById<EditText>(Resource.Id.tvGreen3).Text = _green3.ToString();
        }


        protected override void OnResume()
        {
            base.OnResume();
            Set();
        }

        #endregion

        private void Set()
        {
            var llItem = FindViewById<LinearLayout>(Resource.Id.llItem);

            GradientDrawable gd = new GradientDrawable(_orientation, new int[] { new Color(_red1, _green1, _blue1), new Color(_red2, _green2, _blue2), new Color(_red3, _green3, _blue3) });
            gd.SetCornerRadius(20);
            int[][] attributestates = new int[][] {
                     new int[] { Android.Resource.Attribute.Start},
                     new int[] { Android.Resource.Attribute.StartColor},
                     new int[] { Android.Resource.Attribute.End},
                     new int[] { Android.Resource.Attribute.EndColor},
                     new int[] { Android.Resource.Attribute.StateEnabled }, // enabled
                     new int[] { Android.Resource.Attribute.StateEnabled }, // disabled
                     new int[] { Android.Resource.Attribute.StateChecked}, // unchecked
                     new int[] { Android.Resource.Attribute.StatePressed},  // pressed
                };
            int[] colors = new int[] {
                    Color.Yellow,
                    Color.Green,
                    Color.ForestGreen,
                    Color.Gainsboro,
                    Color.Black,
                    Color.Red,
                    Color.Green,
                    Color.Blue
                };

            gd.SetStroke(5, new ColorStateList(attributestates, colors), 5, 10);

            llItem.Background = gd;
        }
    }
}
