using Android.Graphics;
using Tutoriels.Code.Activities;
using Tutoriel;
using static Android.Graphics.Bitmap;

namespace Tutoriels.Code.Activities.TutorialBitmap
{
    [Activity(Label = "Tutorial")]
    public class BitmapActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.BitmapActivity;

        #endregion

        #region Life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetImages();
        }

        #endregion

        #region Initialisation

        private void SetImages()
        {
            try
            {
                Bitmap bm1 = BitmapFactory.DecodeResource(Application.Resources, Resource.Drawable.france_projection);
                FindViewById<ImageView>(Resource.Id.ImageSource1).SetImageBitmap(bm1);
                Bitmap bm2 = BitmapFactory.DecodeResource(Application.Resources, Resource.Drawable.france);
                FindViewById<ImageView>(Resource.Id.ImageSource2).SetImageBitmap(bm2);

                Android.Graphics.Bitmap bm3 = Bitmap.CreateBitmap(400, 400, Config.Argb8888);
                using (Android.Graphics.Canvas c = new Android.Graphics.Canvas(bm3))
                {
                    using (Paint pos = new Paint())
                    {
                        pos.Color = Color.Yellow;
                        pos.AntiAlias = false;
                        pos.StrokeWidth = 3;

                        c.DrawRect(new Rect(0, 0, bm3.Width, bm3.Height), pos);
                    }
                    c.DrawBitmap(bm1, 1, 1, null);
                    c.DrawBitmap(bm2, bm1.Width, 0, null);
                }
                ImageView img = FindViewById<ImageView>(Resource.Id.ImageSource3);
                img.SetImageBitmap(bm3);
                FindViewById<TextView>(Resource.Id.txtImage3).Text = $"Concaténation des 2 sources : {img.Width}x{img.Height} / {bm3.Width}x{bm3.Height}";


                float ratio = (float)bm1.Width / (float)bm1.Height;
                int width = 1200;
                int height = (int)(width / ratio);
                Bitmap bm4 = Bitmap.CreateBitmap(width, height, Config.Argb8888);
                using (Android.Graphics.Canvas c = new Android.Graphics.Canvas(bm4))
                {
                    c.DrawBitmap(Bitmap.CreateScaledBitmap(bm1, width / 2, height / 2, false), 0, 0, null);
                    c.DrawBitmap(Bitmap.CreateScaledBitmap(bm2, width / 2, height / 2, false), (width / 2), 0, null);
                }
                FindViewById<ImageView>(Resource.Id.ImageSource4).SetImageBitmap(bm4);
            }
            catch (Exception ex)
            {
                Message(ex.Message, ToastLength.Long);
            }
        }

        #endregion
    }
}
