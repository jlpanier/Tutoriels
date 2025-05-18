using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Tutoriels.Code.Activities;
using Tutoriel;
using static Android.Widget.ImageView;

namespace Tutoriels.Code.Activities.Image
{
    [Activity(Label = "Tutorial")]
    public class ImageActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.ImageActivity;

        #endregion

        #region Internal variable

        private ImageView imageview;
        private ImageView imagematrix;
        private ScaleImageView scaleimage;

        #endregion

        #region Life cycle

        private TextView tvScale;
        private TextView tvTranslateX;
        private TextView tvTranslateY;

        private Matrix m_Matrix;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            imageview = FindViewById<ImageView>(Resource.Id.image);
            imagematrix = FindViewById<ImageView>(Resource.Id.imagematrix);
            scaleimage = FindViewById<ScaleImageView>(Resource.Id.scaleimage);

            tvScale = FindViewById<TextView>(Resource.Id.tvScale);
            tvTranslateX = FindViewById<TextView>(Resource.Id.tvTranslateX);
            tvTranslateY = FindViewById<TextView>(Resource.Id.tvTranslateY);

            EditText edtScale = FindViewById<EditText>(Resource.Id.edtScale);
            FindViewById<Button>(Resource.Id.btnScale).Click += (s, e) =>
            {
                if (float.TryParse(edtScale.Text.Replace(".", ","), out float scale))
                {
                    m_Matrix.PostScale(scale, scale);
                    Refresh();
                }
            };

            EditText edtTranslationX = FindViewById<EditText>(Resource.Id.edtTranslationX);
            FindViewById<Button>(Resource.Id.btnTranslationX).Click += (s, e) =>
            {
                if (float.TryParse(edtTranslationX.Text.Replace(".", ","), out float dx))
                {
                    m_Matrix.PostTranslate(dx, 0);
                    Refresh();
                }
            };

            EditText edtTranslationY = FindViewById<EditText>(Resource.Id.edtTranslationY);
            FindViewById<Button>(Resource.Id.btnTranslationY).Click += (s, e) =>
            {
                if (float.TryParse(edtTranslationY.Text.Replace(".", ","), out float dy))
                {
                    m_Matrix.PostTranslate(0, dy);
                    Refresh();
                }
            };

            FindViewById<Button>(Resource.Id.btnReset).Click += (s, e) =>
            {
                MatrixImageReset();
                Refresh();
            };

            MatrixImageReset();

            #region Canvas DrawBitmap

            FindViewById<EditText>(Resource.Id.edtSrc1).AfterTextChanged += (s, e) => { OnCanvasDrawBitmap(); };
            FindViewById<EditText>(Resource.Id.edtSrc2).AfterTextChanged += (s, e) => { OnCanvasDrawBitmap(); };
            FindViewById<EditText>(Resource.Id.edtSrc3).AfterTextChanged += (s, e) => { OnCanvasDrawBitmap(); };
            FindViewById<EditText>(Resource.Id.edtSrc4).AfterTextChanged += (s, e) => { OnCanvasDrawBitmap(); };

            FindViewById<EditText>(Resource.Id.edtDst1).AfterTextChanged += (s, e) => { OnCanvasDrawBitmap(); };
            FindViewById<EditText>(Resource.Id.edtDst2).AfterTextChanged += (s, e) => { OnCanvasDrawBitmap(); };
            FindViewById<EditText>(Resource.Id.edtDst3).AfterTextChanged += (s, e) => { OnCanvasDrawBitmap(); };
            FindViewById<EditText>(Resource.Id.edtDst4).AfterTextChanged += (s, e) => { OnCanvasDrawBitmap(); };

            FindViewById<EditText>(Resource.Id.edtSrc1).Text = "0";
            FindViewById<EditText>(Resource.Id.edtSrc2).Text = "0";
            FindViewById<EditText>(Resource.Id.edtSrc3).Text = "100";
            FindViewById<EditText>(Resource.Id.edtSrc4).Text = "100";

            FindViewById<EditText>(Resource.Id.edtDst1).Text = "0";
            FindViewById<EditText>(Resource.Id.edtDst2).Text = "0";
            FindViewById<EditText>(Resource.Id.edtDst3).Text = "100";
            FindViewById<EditText>(Resource.Id.edtDst4).Text = "100";

            OnCanvasDrawBitmap();

            #endregion
        }

        protected override void OnResume()
        {
            try
            {
                base.OnResume();

                // Image top
                SetBackground();
                SetAjustViewBounds();
                SetAlpha();
                SetScaleType();

                // Initialisation de l'image Matrix
                Refresh();
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        #endregion

        #region Matrix Image

        private void MatrixImageReset()
        {
            m_Matrix = new Matrix();
            m_Matrix.Reset();
        }

        private void Refresh()
        {
            // Image matrix
            Bitmap bmp = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Napoleon2);
            FindViewById<TextView>(Resource.Id.tvImageSize).Text = $"Taille image : {bmp.Width} x {bmp.Height}";
            FindViewById<TextView>(Resource.Id.tvLayoutSize).Text = $"Taille layout : {imagematrix.Width} x {imagematrix.Height}";

            imagematrix.ImageMatrix = m_Matrix;

            tvScale.Text = $"Scale : {Scale}";
            tvTranslateX.Text = $"X : {TranslateX}";
            tvTranslateY.Text = $"Y : {TranslateY}";
        }

        public float TranslateX => GetValue(m_Matrix, Matrix.MtransX);

        public float TranslateY => GetValue(m_Matrix, Matrix.MtransY);

        public float Perspective0 => GetValue(m_Matrix, Matrix.Mpersp0);

        public float Perspective1 => GetValue(m_Matrix, Matrix.Mpersp1);

        public float Perspective2 => GetValue(m_Matrix, Matrix.Mpersp2);

        public float Scale => GetValue(m_Matrix, Matrix.MscaleX);

        public float ScaleY => GetValue(m_Matrix, Matrix.MscaleY);

        public float MskewX => GetValue(m_Matrix, Matrix.MskewX);

        public float MskewY => GetValue(m_Matrix, Matrix.MskewY);

        private float GetValue(Matrix matrix, int whichValue)
        {
            matrix.GetValues(m_MatrixValues);
            return m_MatrixValues[whichValue];
        }
        private readonly float[] m_MatrixValues = new float[9];

        #endregion

        #region style de l'image d'origine

        protected void SetBackground()
        {
            try
            {
                // keep this for later

                GradientDrawable gd = new GradientDrawable();
#if JLP
                #region Shape

                NumberPicker npShape = FindViewById<NumberPicker>(Resource.Id.npShape);
                var shapes = new string[]
                {
                    ShapeType.Line.ToString(),
                    ShapeType.Oval.ToString(),
                    ShapeType.Rectangle.ToString(),
                    ShapeType.Ring.ToString(),
                };

                npShape.SetDisplayedValues(shapes);
                npShape.MinValue = 0;
                npShape.MaxValue = shapes.Length - 1;
                npShape.ValueChanged += (s, e) =>
                {
                    switch (npShape.Value)
                    {
                        case 0:
                            gd.SetShape(ShapeType.Line);
                            break;
                        case 1:
                            gd.SetShape(ShapeType.Oval);
                            break;
                        case 2:
                            gd.SetShape(ShapeType.Rectangle);
                            break;
                        case 3:
                            gd.SetShape(ShapeType.Ring);
                            break;
                    }
                };

                #endregion
#endif
                //gd.SetCornerRadii(new float[] { 10, 20, 40, 80 });

                int[][] attributestates = new int[][] {
                    new int[] { Android.Resource.Attribute.StateEnabled }, // enabled
                    new int[] { Android.Resource.Attribute.StateEnabled }, // disabled
                    new int[] { Android.Resource.Attribute.StateChecked}, // unchecked
                    new int[] { Android.Resource.Attribute.StatePressed}  // pressed
                };
                int[] colors = new int[] {
                    Color.Black,
                    Color.Red,
                    Color.Green,
                    Color.Blue
                };

                gd.SetStroke(5, new ColorStateList(attributestates, colors), 5, 10);

                imageview.SetImageResource(Resource.Drawable.Napoleon2);

                StateListDrawable states = new StateListDrawable();
                states.AddState(new int[] { Android.Resource.Attribute.StatePressed }, gd);
                states.AddState(new int[] { Android.Resource.Attribute.StateFocused }, gd);
                states.AddState(new int[] { Android.Resource.Attribute.StateActive }, gd);

                imageview.SetImageState(new int[] { Android.Resource.Attribute.StatePressed, Android.Resource.Attribute.StateFocused, Android.Resource.Attribute.StateActive }, false);
                //imageview.SetImageDrawable(gd);

            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        protected void SetAjustViewBounds()
        {
            try
            {
                FindViewById<CheckBox>(Resource.Id.cbAjustViewBounds).CheckedChange += (s, e) =>
                {
                    imageview.SetAdjustViewBounds(e.IsChecked);
                };
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        protected void SetScaleType()
        {
            try
            {
                NumberPicker npScaleType = FindViewById<NumberPicker>(Resource.Id.npScaleType);
                var scaletype = new string[]
                {
                    ScaleType.Center.ToString(),
                    ScaleType.CenterCrop.ToString(),
                    ScaleType.CenterInside.ToString(),
                    ScaleType.FitCenter.ToString(),
                    ScaleType.FitEnd.ToString(),
                    ScaleType.FitStart.ToString(),
                    ScaleType.FitXy.ToString(),
                    ScaleType.Matrix.ToString(),
                };
                npScaleType.SetDisplayedValues(scaletype);
                npScaleType.MinValue = 0;
                npScaleType.MaxValue = scaletype.Length - 1;
                npScaleType.ValueChanged += (s, e) =>
                {
                    switch (npScaleType.Value)
                    {
                        case 0:
                            imageview.SetScaleType(ScaleType.Center);
                            break;
                        case 1:
                            imageview.SetScaleType(ScaleType.CenterCrop);
                            break;
                        case 2:
                            imageview.SetScaleType(ScaleType.CenterInside);
                            break;
                        case 3:
                            imageview.SetScaleType(ScaleType.FitCenter);
                            break;
                        case 4:
                            imageview.SetScaleType(ScaleType.FitEnd);
                            break;
                        case 5:
                            imageview.SetScaleType(ScaleType.FitStart);
                            break;
                        case 6:
                            imageview.SetScaleType(ScaleType.FitXy);
                            break;
                        case 7:
                            imageview.SetScaleType(ScaleType.Matrix);
                            break;
                    }
                };
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        protected void SetAlpha()
        {
            try
            {
                ImageView img = FindViewById<ImageView>(Resource.Id.image);

                NumberPicker npAlpha = FindViewById<NumberPicker>(Resource.Id.npAlpha);
                var alphas = new string[]
                {
                        "0.0",
                        "0.1",
                        "0.2",
                        "0.3",
                        "0.4",
                        "0.5",
                        "0.6",
                        "0.7",
                        "0.8",
                        "0.9",
                        "1.0",
                };
                npAlpha.SetDisplayedValues(alphas);
                npAlpha.MaxValue = 10;
                npAlpha.MinValue = 0;
                npAlpha.Value = 10;
                npAlpha.ValueChanged += (s, e) =>
                {
                    img.Alpha = ((float)e.NewVal) / 10;
                };
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        #endregion

        #region Canvas DrawBitmap

        private void OnCanvasDrawBitmap()
        {
            int srcX, srcY, srcW, srcH;
            int dstX, dstY, dstW, dstH;

            int.TryParse(FindViewById<EditText>(Resource.Id.edtSrc1).Text, out srcX);
            int.TryParse(FindViewById<EditText>(Resource.Id.edtSrc2).Text, out srcY);
            int.TryParse(FindViewById<EditText>(Resource.Id.edtSrc3).Text, out srcW);
            int.TryParse(FindViewById<EditText>(Resource.Id.edtSrc4).Text, out srcH);
            int.TryParse(FindViewById<EditText>(Resource.Id.edtDst1).Text, out dstX);
            int.TryParse(FindViewById<EditText>(Resource.Id.edtDst2).Text, out dstY);
            int.TryParse(FindViewById<EditText>(Resource.Id.edtDst3).Text, out dstW);
            int.TryParse(FindViewById<EditText>(Resource.Id.edtDst4).Text, out dstH);

            using (Bitmap bmSrc = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Napoleon2))
            {
                using (Bitmap bmDst = Bitmap.CreateBitmap(bmSrc.Width, bmSrc.Height, bmSrc.GetConfig()))
                {
                    using (Android.Graphics.Canvas c = new Android.Graphics.Canvas(bmDst))
                    {
                        c.DrawBitmap(bmSrc, new Rect(srcX, srcY, srcW, srcH), new Rect(dstX, dstY, dstW, dstH), null);
                    }
                    FindViewById<ImageView>(Resource.Id.imgcanvasdrawbitmapdst).SetImageBitmap(bmDst);
                    FindViewById<TextView>(Resource.Id.tvimagesrc).Text = $"Size {bmSrc.Width} x {bmSrc.Height}";
                    FindViewById<TextView>(Resource.Id.tvimagedst).Text = $"Size {bmDst.Width} x {bmDst.Height}";
                }
            }
        }

        #endregion
    }
}