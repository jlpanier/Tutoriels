using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Util;
using Android.Views;
using System.Reflection;
using Tutoriels.Code.Customs;
using static Android.Widget.ImageView;
using AndroidX.Core.Content;

namespace Tutoriels.Droid.Customs
{

    /// <summary>
    /// Propose une edittext pour édition avec proposition de choix d'items
    /// </summary>
    public class HistogrammeView : LinearLayout
    {
        #region General

        /// <summary>
        /// Marqueur des messages logs
        /// </summary>
        protected static string TAG => MethodBase.GetCurrentMethod().DeclaringType?.FullName;

        #endregion

        #region Variable

        private TextView tvHeader;

        private TextView tvCommentaire;

        private ImageView imageview;

        #endregion

        #region constructeur

        public HistogrammeView(Context context) : base(context)
        {
            Initialize(context);
        }

        public HistogrammeView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context, attrs);
        }

        public HistogrammeView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context, attrs);
        }

        public HistogrammeView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Initialize(context, attrs);
        }

        #endregion

        #region Initialisation

        private ImageView imageView;

        /// <summary>
        /// Espace entre chaque sélection
        /// </summary>
        private int _padding = 5;

        /// <summary>
        /// Largeur de l'epaisseur du trait carré
        /// </summary>
        private int _strokeWidth = 1;

        /// <summary>
        /// text size
        /// </summary>
        private float _textSize = 10;

        /// <summary>
        /// Resource couleur du rectangle
        /// </summary>
        private Android.Graphics.Color _strokeColor = Color.White;

        /// <summary>
        /// Resource couleur du rectangle
        /// </summary>
        private Android.Graphics.Color _backgroundColor = Color.White;

        /// <summary>
        /// Resource couleur du rectangle
        /// </summary>
        private Android.Graphics.Color _fillColor;

        /// <summary>
        /// Resource couleur du text
        /// </summary>
        private Android.Graphics.Color _textColor;

        /// <summary>
        /// Resource couleur du text
        /// </summary>
        private Android.Graphics.Color _textColorHighlight;

        /// <summary>
        /// Minimum largeur de la chque sélection
        /// </summary>
        private int _minWidth;

        /// <summary>
        /// Minimum largeur de la chque sélection
        /// </summary>
        private int _minHeight;

        /// <summary>
        /// VRAI si la croix doit s'afficher pour supprimer l'image
        /// </summary>
        public bool CanDelete { get; private set; }

        /// <summary>
        /// Get color from attribute
        /// </summary>
        /// <param name="attrs"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private Color GetColor(IAttributeSet attrs, int index)
        {
            System.Diagnostics.Debug.Assert(attrs != null);
            System.Diagnostics.Debug.Assert(Context != null);

            Color result;

            int resourceId = attrs.GetAttributeResourceValue(index, 0);

            if (resourceId > 0)
            {
                result = new Android.Graphics.Color(ContextCompat.GetColor(this.Context, resourceId));
            }
            else
            {
                string? colorString = attrs.GetAttributeValue(index);

                if (string.IsNullOrEmpty(colorString))
                {
                    result = new Android.Graphics.Color(ContextCompat.GetColor(this.Context, Resource.Color.colorBlack));
                }
                else
                {
                    result = Android.Graphics.Color.ParseColor(colorString);
                }
            }

            return result;
        }



        /// <summary>
        /// Retourne une valeur float selon les attributs
        /// </summary>
        /// <param name="attrs"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private float GetFloat(IAttributeSet attrs, int index)
        {
            int resourceId = attrs.GetAttributeResourceValue(index, 0);

            return resourceId > 0 ? Resources.GetDimension(resourceId) : attrs.GetAttributeFloatValue(index, 10);
        }

        /// <summary>
        /// Retourne une valeur int selon les attributs
        /// </summary>
        /// <param name="attrs"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetInt(IAttributeSet attrs, int index, int defaultvalue)
        {
            int resourceId = attrs.GetAttributeResourceValue(index, 0);

            if (resourceId > 0) return (int)Resources.GetDimension(resourceId);

            int result = attrs.GetAttributeIntValue(index, -99999);

            if (result != -99999) return result;

            string val = attrs.GetAttributeValue(index);

            if (int.TryParse(val.Replace("dip", "").Replace(".0", ""), out int res))
            {
                return res;
            }
            return defaultvalue;
        }

        /// <summary>
        /// Retourne une valeur bool selon les attributs
        /// </summary>
        /// <param name="attrs"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static bool GetBool(IAttributeSet attrs, int index, bool defaultvalue)
        {
            string val = attrs.GetAttributeValue(index);

            if (bool.TryParse(val, out bool res))
            {
                return res;
            }

            return defaultvalue;
        }

        private void Initialize(Context context, IAttributeSet attrs = null)
        {
            GravityFlags gravity = GravityFlags.NoGravity;

            int layoutParamsWidth = ViewGroup.LayoutParams.MatchParent;
            int layoutParamsHeight = ViewGroup.LayoutParams.WrapContent;
            int layoutParamsWeight = 1;

            if (attrs != null)
            {
                int index = 0;

                while (index < attrs.AttributeCount)
                {
                    switch (attrs.GetAttributeName(index))
                    {
                        case "layout_width":
                            layoutParamsWidth = attrs.GetAttributeIntValue(index, ViewGroup.LayoutParams.MatchParent);
                            break;
                        case "layout_height":
                            layoutParamsHeight = GetInt(attrs, index, ViewGroup.LayoutParams.MatchParent);
                            break;
                        case "layout_weight":
                            layoutParamsWeight = attrs.GetAttributeIntValue(index, 1);
                            break;
                        case "layout_gravity":
                            gravity = (GravityFlags)attrs.GetAttributeIntValue(index, (int)GravityFlags.Center);
                            break;
                        case "textColor":
                            _textColor = GetColor(attrs, index);
                            break;
                        case "textColorHighlight":
                            _textColorHighlight = GetColor(attrs, index);
                            break;
                        case "strokeColor":
                            _strokeColor = GetColor(attrs, index);
                            break;
                        case "background":
                            _backgroundColor = GetColor(attrs, index);
                            break;
                        case "fillColor":
                            _fillColor = GetColor(attrs, index);
                            break;
                        case "textSize":
                            _textSize = GetFloat(attrs, index);
                            break;
                        case "inputType":
                            break;
                        case "duration":
                            break;
                        case "shape":
                            break;
                        case "strokeWidth":
                            _strokeWidth = GetInt(attrs, index, 1);
                            break;
                        case "font":
                            break;
                        case "padding":
                            _padding = GetInt(attrs, index, 10);
                            break;
                        case "layout_margin":
                            break;
                        case "hint":
                            break;
                        case "minWidth":
                            _minWidth = GetInt(attrs, index, 0);
                            break;
                        case "maxLength":
                            break;
                        case "minHeight":
                            _minHeight = GetInt(attrs, index, 10);
                            break;
                        case "editable":
                            CanDelete = GetBool(attrs, index, true);
                            break;
                    }
                    index++;
                }
            }

            // https://stackoverflow.com/questions/19691530/valid-values-for-androidfontfamily-and-what-they-map-to


            var shape = new ShapeDrawable();
            shape.Shape = new RectShape();
            shape.Paint.Color = _strokeColor;
            shape.Paint.Color = _backgroundColor;
            shape.Paint.SetStyle(Paint.Style.Fill);

            LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, 1);
            Orientation = Orientation.Vertical;
            SetPadding(0, 6, 0, 12);
            SetForegroundGravity(GravityFlags.Center);
            SetBackgroundColor(_backgroundColor);

            tvHeader = new TextView(context);
            tvHeader.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, 1);
            tvHeader.SetPadding(0, 6, 0, 12);
            tvHeader.SetTextSize(ComplexUnitType.Px, _textSize);
            tvHeader.SetTextColor(_textColor);
            tvHeader.Gravity = GravityFlags.Center;
            tvHeader.SetForegroundGravity(GravityFlags.Center);
            Typeface typeface = Typeface.Create("cursive", TypefaceStyle.Normal);
            tvHeader.Typeface = typeface;
            AddView(tvHeader);

            imageView = new ImageView(context);
            imageView.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, 1);
            imageView.SetPadding(0, 6, 0, 12);
            imageView.SetScaleType(ScaleType.CenterInside);
            imageView.SetForegroundGravity(GravityFlags.Center);
            imageView.SetBackgroundColor(_backgroundColor);
            AddView(imageView);

            tvCommentaire = new TextView(context);
            tvCommentaire.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, 1);
            tvCommentaire.SetPadding(0, 6, 0, 12);
            tvCommentaire.SetTextSize(ComplexUnitType.Px, _textSize);
            tvCommentaire.SetTextColor(_textColor);
            tvCommentaire.Gravity = GravityFlags.Center;
            tvCommentaire.SetForegroundGravity(GravityFlags.Center);
            tvCommentaire.Text = "Trailer";
            tvCommentaire.Typeface = typeface;
            AddView(tvCommentaire);
        }

        #endregion

        private decimal Xmax, Xmin, Ymax, Ymin;

        /// <summary>
        /// Hauteur en pixels de límage ecran
        /// </summary>
        private int H;

        /// <summary>
        /// Largeur en pixels de límage ecran
        /// </summary>
        private int W = 800;

        /// <summary>
        /// position de l'axe X sur l'axe vertical
        /// </summary>
        float PositionAxeVertical;

        /// <summary>
        /// position de l'axe Y sur l'axe horizontal
        /// </summary>
        float PositionAxeHorizontal;

        /// <summary>
        /// Defini l'unite choisi pour l'axe des X: 0.01, 0.1, 1, 10 etc...
        /// </summary>
        decimal UnitX;

        /// <summary>
        /// Defini l'unite choisi pour l'axe des Y: 0.01, 0.1, 1, 10 etc...
        /// </summary>
        decimal UnitY;

        /// <summary>
        /// Dessiner les courbes
        /// </summary>
        /// <param name="parameters"></param>
        public void Set(Histogramme parameters)
        {
            tvHeader.Text = parameters.Titre;
            tvCommentaire.Text = parameters.Commentaire;
            H = 3 * W / 4;

            decimal marge = (decimal)1.2;
            decimal ymin = decimal.MaxValue;
            decimal ymax = decimal.MinValue;
            decimal xmin = decimal.MaxValue;
            decimal xmax = decimal.MinValue;
            if (parameters.FonctionNonContinues.Any())
            {
                ymin = parameters.FonctionNonContinues.Min(_ => _.MinValueY);
                ymax = parameters.FonctionNonContinues.Max(_ => _.MaxValueY);
                xmin = parameters.FonctionNonContinues.Min(_ => _.MinValueX);
                xmax = parameters.FonctionNonContinues.Max(_ => _.MaxValueX);
            }
            if (parameters.FonctionContinues.Any())
            {
                ymin = Math.Min(ymin, parameters.FonctionContinues.Min(_ => _.MinValueY));
                ymax = Math.Max(ymax, parameters.FonctionContinues.Max(_ => _.MaxValueY));
                xmin = Math.Min(xmin, parameters.FonctionContinues.Min(_ => _.MinValueX));
                xmax = Math.Max(xmax, parameters.FonctionContinues.Max(_ => _.MaxValueX));
            }
            if (parameters.Fouriers.Any())
            {
                ymin = Math.Min(ymin, parameters.Fouriers.Min(_ => _.MinValueY));
                ymax = Math.Max(ymax, parameters.Fouriers.Max(_ => _.MaxValueY));
                xmin = Math.Min(xmin, parameters.Fouriers.Min(_ => _.MinValueX));
                xmax = Math.Max(xmax, parameters.Fouriers.Max(_ => _.MaxValueX));
            }
            if (ymax == ymin)
            {
                if (ymax > 0)
                {
                    ymin = -ymax / 10;
                }
                else
                {
                    ymax = -ymin / 10;
                }
            }
            if (ymin == decimal.MaxValue) ymin = -6;
            if (ymax == decimal.MinValue) ymax = 6;
            if (xmin == decimal.MaxValue) xmin = -6;
            if (xmax == decimal.MinValue) xmax = 6;

            Ymax = parameters.YMax.HasValue ? parameters.YMax.Value : ymax + marge * (ymax - ymin);
            Ymin = parameters.YMin.HasValue ? parameters.YMin.Value : ymin - marge * (ymax - ymin);
            Xmax = parameters.XMax.HasValue ? parameters.XMax.Value : xmax;
            Xmin = parameters.XMin.HasValue ? parameters.XMin.Value : xmin;

            if (parameters.Orthonormme)
            {
                double delta = Math.Max((double)(Xmax - Xmin) / 4, (double)(Ymax - Ymin) / 4);
                double logprecision = Math.Log10(10 * delta);
                int precision = (int)Math.Round(logprecision, 0);
                UnitX = (decimal)Math.Pow(10, precision - 1);
                UnitY = UnitX;
            }
            else
            {
                double delta = (double)(Xmax - Xmin) / 4;
                double logprecision = Math.Log10(10 * delta);
                int precision = (int)Math.Round(logprecision, 0);
                UnitX = (decimal)Math.Pow(10, precision - 1);

                delta = (double)(Ymax - Ymin) / 4;
                logprecision = Math.Log10(10 * delta);
                precision = (int)Math.Round(logprecision, 0);
                UnitY = (decimal)Math.Pow(10, precision - 1);
            }


            // position de l'axe X dans sur l'axe vertical
            PositionAxeVertical = (float)(H * Ymax / (Ymax - Ymin));

            // position de l'axe Y dans sur l'axe horizontal
            PositionAxeHorizontal = (float)(W * Xmax / (Xmax - Xmin));


            using (Bitmap bm = Bitmap.CreateBitmap(W, H, Bitmap.Config.Argb8888))
            {
                using (Canvas c = new Canvas(bm))
                {
                    using (Paint pos = new Paint())
                    {
                        pos.Color = _backgroundColor;
                        pos.AntiAlias = false;
                        pos.StrokeWidth = 1;
                        c.DrawRect(new Rect(0, 0, bm.Width, bm.Height), pos);
                    }

                    foreach (FonctionNonContinue courbe in parameters.FonctionNonContinues)
                    {
                        int index = 0;
                        var lines = new float[4 * courbe.Lines.Count];
                        foreach (var line in courbe.Lines)
                        {
                            lines[index++] = TranslateX(line.PointA.X);
                            lines[index++] = TranslateY(line.PointA.Y);
                            lines[index++] = TranslateX(line.PointB.X);
                            lines[index++] = TranslateY(line.PointB.Y);

                        }
                        using (Paint pos = new Paint())
                        {
                            pos.Color = courbe.Color;
                            pos.AntiAlias = false;
                            pos.StrokeWidth = 3;
                            c.DrawLines(lines, pos);
                        }
                    }

                    foreach (FonctionContinue courbe in parameters.FonctionContinues)
                    {
                        if (courbe.Lines.Count > 1)
                        {
                            int index = 0;
                            float prevX = (float)courbe.Lines[0].X;
                            float prevY = (float)courbe.Lines[0].Y;
                            var lines = new float[4 * courbe.Lines.Count];
                            foreach (Coordonnee line in courbe.Lines)
                            {
                                lines[index++] = prevX;
                                lines[index++] = prevY;
                                lines[index] = TranslateX(line.X);
                                prevX = lines[index];
                                index++;
                                lines[index] = TranslateY(line.Y);
                                prevY = lines[index];
                                index++;
                            }
                            using (Paint pos = new Paint())
                            {
                                pos.Color = courbe.Color;
                                pos.AntiAlias = false;
                                pos.StrokeWidth = 3;
                                c.DrawLines(lines, pos);
                            }
                        }
                    }

                    foreach (SerieFourier courbe in parameters.Fouriers)
                    {
                        if (courbe.Lines.Count > 1)
                        {
                            int index = 0;
                            float prevX = (float)courbe.Lines[0].X;
                            float prevY = (float)courbe.Lines[0].Y;
                            var lines = new float[4 * courbe.Lines.Count];
                            foreach (Coordonnee line in courbe.Lines)
                            {
                                lines[index++] = prevX;
                                lines[index++] = prevY;
                                lines[index] = TranslateX(line.X);
                                prevX = lines[index];
                                index++;
                                lines[index] = TranslateY(line.Y);
                                prevY = lines[index];
                                index++;
                            }
                            using (Paint pos = new Paint())
                            {
                                pos.Color = courbe.Color;
                                pos.AntiAlias = false;
                                pos.StrokeWidth = 3;
                                c.DrawLines(lines, pos);
                            }
                        }
                    }

                    const int flechesize = 20;
                    float[] coordonnatelines = new float[8] { 0, PositionAxeVertical, W, PositionAxeVertical, PositionAxeHorizontal, 0, PositionAxeHorizontal, H };
                    using (Paint pos = new Paint())
                    {
                        pos.Color = _textColor;
                        pos.AntiAlias = false;
                        pos.StrokeWidth = 1;
                        c.DrawLines(coordonnatelines, pos);

                        // Fleches extremitees des axes
                        c.DrawArc(new RectF(W - flechesize, PositionAxeVertical - flechesize, W + flechesize, PositionAxeVertical + flechesize), 160, 40, true, pos);
                        c.DrawArc(new RectF(PositionAxeHorizontal - flechesize, -flechesize, PositionAxeHorizontal + flechesize, flechesize), 70, 40, true, pos);


                        decimal x = UnitX;
                        int unit = 1;
                        while (x <= Xmax)
                        {
                            float posX = TranslateX(x);
                            c.DrawLine(posX, unit % 5 == 0 ? PositionAxeVertical - 10 : PositionAxeVertical - 5, posX, unit % 5 == 0 ? PositionAxeVertical + 10 : PositionAxeVertical + 5, pos);
                            if (unit % 5 == 0 || unit == 1)
                            {
                                string text = x.ToString();
                                c.DrawText(text, posX - pos.MeasureText(text) / 2, PositionAxeVertical + 25, pos);
                            }
                            unit++;
                            x += UnitX;
                        }

                        x = -UnitX;
                        unit = 1;
                        while (x >= Xmin)
                        {
                            float posX = TranslateX(x);
                            c.DrawLine(posX, unit % 5 == 0 ? PositionAxeVertical - 10 : PositionAxeVertical - 5, posX, unit % 5 == 0 ? PositionAxeVertical + 10 : PositionAxeVertical + 5, pos);
                            if (unit % 5 == 0 || unit == 1)
                            {
                                string text = x.ToString();
                                c.DrawText(text, posX - pos.MeasureText(text) / 2, PositionAxeVertical + 25, pos);
                            }
                            unit++;
                            x -= UnitX;
                        }

                        decimal y = UnitY;
                        unit = 1;
                        while (y <= Ymax)
                        {
                            float posY = TranslateY(y);
                            c.DrawLine(unit % 5 == 0 ? PositionAxeHorizontal - 10 : PositionAxeHorizontal - 5, posY, unit % 5 == 0 ? PositionAxeHorizontal + 10 : PositionAxeHorizontal + 5, posY, pos);
                            if (unit % 5 == 0 || unit == 1)
                            {
                                string text = y.ToString();
                                c.DrawText(text, PositionAxeHorizontal - 20 - pos.MeasureText(text) / 2, posY, pos);
                            }
                            unit++;
                            y += UnitY;
                        }
                        y = -UnitY;
                        unit = 1;
                        while (y > Ymin)
                        {
                            float posY = TranslateY(y);
                            c.DrawLine(unit % 5 == 0 ? PositionAxeHorizontal - 10 : PositionAxeHorizontal - 5, posY, unit % 5 == 0 ? PositionAxeHorizontal + 10 : PositionAxeHorizontal + 5, posY, pos);
                            if (unit % 5 == 0 || unit == 1)
                            {
                                string text = y.ToString();
                                c.DrawText(text, PositionAxeHorizontal - 20 - pos.MeasureText(text) / 2, posY, pos);
                            }
                            unit++;
                            y -= UnitY;
                        }
                    }
                    imageView.SetImageBitmap(bm);
                }
            }
        }


        private float TranslateX(decimal x)
        {
            float result = (float)(W * (x - Xmin) / (Xmax - Xmin));
            return result;
        }

        private float TranslateY(decimal y)
        {
            float result = (float)(H * (Ymax - y) / (Ymax - Ymin));
            return result;
        }

    }
}