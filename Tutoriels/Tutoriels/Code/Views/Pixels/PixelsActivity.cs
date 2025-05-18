using Android.Graphics;
using Java.Lang;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Canvas
{
    [Activity(Label = "Tutorial")]
    public class PixelsActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.PixelsActivity;

        #endregion

        #region life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            EditText edt = FindViewById<EditText>(Resource.Id.edtWidth);
            edt.Text = "512";
            edt.SetFilters(new Android.Text.IInputFilter[] { new IntegerDigitInputFilter(1, 8192) });
            edt.AfterTextChanged += (s, e) => { Load(); };

            edt = FindViewById<EditText>(Resource.Id.edtHeight);
            edt.Text = "1024";
            edt.SetFilters(new Android.Text.IInputFilter[] { new IntegerDigitInputFilter(1, 8192) });
            edt.AfterTextChanged += (s, e) => { Load(); };

            edt = FindViewById<EditText>(Resource.Id.edtR1);
            edt.Text = "0";
            edt.SetFilters(new Android.Text.IInputFilter[] { new IntegerDigitInputFilter(0, 255) });
            edt.AfterTextChanged += (s, e) => { Load(); };

            edt = FindViewById<EditText>(Resource.Id.edtG1);
            edt.Text = "0";
            edt.SetFilters(new Android.Text.IInputFilter[] { new IntegerDigitInputFilter(0, 255) });
            edt.AfterTextChanged += (s, e) => { Load(); };

            edt = FindViewById<EditText>(Resource.Id.edtB1);
            edt.Text = "0";
            edt.SetFilters(new Android.Text.IInputFilter[] { new IntegerDigitInputFilter(0, 255) });
            edt.AfterTextChanged += (s, e) => { Load(); };

            edt = FindViewById<EditText>(Resource.Id.edtR2);
            edt.Text = "255";
            edt.SetFilters(new Android.Text.IInputFilter[] { new IntegerDigitInputFilter(0, 255) });
            edt.AfterTextChanged += (s, e) => { Load(); };

            edt = FindViewById<EditText>(Resource.Id.edtG2);
            edt.Text = "255";
            edt.SetFilters(new Android.Text.IInputFilter[] { new IntegerDigitInputFilter(0, 255) });
            edt.AfterTextChanged += (s, e) => { Load(); };

            edt = FindViewById<EditText>(Resource.Id.edtB2);
            edt.Text = "255";
            edt.SetFilters(new Android.Text.IInputFilter[] { new IntegerDigitInputFilter(0, 255) });
            edt.AfterTextChanged += (s, e) => { Load(); };
        }

        protected override void OnResume()
        {
            base.OnResume();
            Load();
        }

        #endregion

        private void Load()
        {
            try
            {
                FindViewById<EditText>(Resource.Id.edtDensity).Text = Resources.DisplayMetrics.Density.ToString();
                FindViewById<EditText>(Resource.Id.edtDensityDpi).Text = Resources.DisplayMetrics.DensityDpi.ToString();
                FindViewById<EditText>(Resource.Id.edtWidthPixels).Text = Resources.DisplayMetrics.WidthPixels.ToString();
                FindViewById<EditText>(Resource.Id.edtHeightPixels).Text = Resources.DisplayMetrics.HeightPixels.ToString();
                FindViewById<EditText>(Resource.Id.edtScaledDensity).Text = Resources.DisplayMetrics.ScaledDensity.ToString();
                FindViewById<EditText>(Resource.Id.edtXdpi).Text = Resources.DisplayMetrics.Xdpi.ToString("N0");
                FindViewById<EditText>(Resource.Id.edtYdpi).Text = Resources.DisplayMetrics.Ydpi.ToString("N0");

                int width = int.Parse(FindViewById<EditText>(Resource.Id.edtWidth).Text);
                int height = int.Parse(FindViewById<EditText>(Resource.Id.edtHeight).Text);

                int R1 = int.Parse(FindViewById<EditText>(Resource.Id.edtR1).Text);
                int G1 = int.Parse(FindViewById<EditText>(Resource.Id.edtG1).Text);
                int B1 = int.Parse(FindViewById<EditText>(Resource.Id.edtB1).Text);

                int R2 = int.Parse(FindViewById<EditText>(Resource.Id.edtR2).Text);
                int G2 = int.Parse(FindViewById<EditText>(Resource.Id.edtG2).Text);
                int B2 = int.Parse(FindViewById<EditText>(Resource.Id.edtB2).Text);

                Color color1 = new Color(R1, G1, B1);
                Color color2 = new Color(R2, G2, B2);
                ImageBox(width, height, color1, color2, 2, Resource.Id.imgBox2);
                ImageBox(width, height, color1, color2, 4, Resource.Id.imgBox4);
                ImageBox(width, height, color1, color2, 8, Resource.Id.imgBox8);
                ImageBox(width, height, color1, color2, 10, Resource.Id.imgBox10);
                ImageColor(width, height, FormatCouleurs.RG, Resource.Id.imgRG);
                ImageColor(width, height, FormatCouleurs.RB, Resource.Id.imgRB);
                ImageColor(width, height, FormatCouleurs.GB, Resource.Id.imgGB);
                ImageColor(width, height, FormatCouleurs.RGprogressif, Resource.Id.imgRGprogressif);
                ImageColor(width, height, FormatCouleurs.RBprogressif, Resource.Id.imgRBprogressif);
                ImageColor(width, height, FormatCouleurs.GBprogressif, Resource.Id.imgGBprogressif);
            }
            catch (IllegalStateException ex)
            {
                Message(ex.Message);
            }
            catch (IllegalArgumentException ex)
            {
                Message(ex.Message);
            }
            catch (ArrayIndexOutOfBoundsException ex)
            {
                Message(ex.Message);
            }
            catch (System.Exception ex)
            {
                Message(ex.Message);
            }
        }

        private enum Couleurs { Couleur1, Couleur2 };

        private void ImageBox(int width, int height, Color color1, Color color2, int box, int resourceId)
        {
            int[] pixels = new int[width * height * 4];
            Couleurs couleur = Couleurs.Couleur1;
            int square = width / box;
            int index = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (y % square == 0)
                    {
                        couleur = couleur == Couleurs.Couleur1 ? Couleurs.Couleur2 : Couleurs.Couleur1;
                    }
                    switch (couleur)
                    {
                        case Couleurs.Couleur1:
                            pixels[index++] = color1;
                            break;
                        case Couleurs.Couleur2:
                            pixels[index++] = color2;
                            break;
                    }
                }
                if (x % square == 0)
                {
                    couleur = couleur == Couleurs.Couleur1 ? Couleurs.Couleur2 : Couleurs.Couleur1;
                }
            }
            Bitmap bm = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            bm.SetPixels(pixels, 0, 4 * width, 0, 0, width, height);
            FindViewById<ImageView>(resourceId).SetImageBitmap(bm);

        }

        private enum FormatCouleurs { RG, RB, GB, RGprogressif, RBprogressif, GBprogressif };

        private void ImageColor(int width, int height, FormatCouleurs format, int resourceId)
        {
            int[] pixels = new int[width * height * 4];
            int index = 0;
            double R = 0;
            double G = 0;
            double B = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    switch (format)
                    {
                        case FormatCouleurs.RG:
                            R = 255 * (double)x / (double)width;
                            G = 255 * (double)y / (double)height;
                            B = 0;
                            break;
                        case FormatCouleurs.RB:
                            R = 255 * (double)x / (double)width;
                            G = 0;
                            B = 255 * (double)y / (double)height;
                            break;
                        case FormatCouleurs.GB:
                            R = 0;
                            G = 255 * (double)y / (double)height;
                            B = 255 * (double)y / (double)height;
                            break;
                        case FormatCouleurs.RGprogressif:
                            R = 255 * (double)x / (double)width;
                            G = 255 * (double)y / (double)height;
                            B = 0.5 * ((((double)x / (double)width) + ((double)y / (double)height)) * (double)255);
                            break;
                        case FormatCouleurs.RBprogressif:
                            R = 255 * (double)x / (double)width;
                            G = 0.5 * ((((double)x / (double)width) + ((double)y / (double)height)) * (double)255);
                            B = 255 * (double)y / (double)height;
                            break;
                        case FormatCouleurs.GBprogressif:
                            R = 0.5 * ((((double)x / (double)width) + ((double)y / (double)height)) * (double)255);
                            G = 255 * (double)x / (double)width;
                            B = 255 * (double)y / (double)height;
                            break;
                    }
                    pixels[index++] = new Color((int)R, (int)G, (int)B);
                }
            }
            Bitmap bm = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            bm.SetPixels(pixels, 0, 4 * width, 0, 0, width, height);
            FindViewById<ImageView>(resourceId).SetImageBitmap(bm);

        }
    }
}