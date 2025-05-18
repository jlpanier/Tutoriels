using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Reflection;
using Tutoriels.Code.Activities;

namespace Tutoriels.Code.Activities.Image
{
    public class ScaleImageView : ImageView, View.IOnTouchListener
    {
        #region General

        /// <summary>
        /// Marqueur des messages logs
        /// </summary>
        protected string LogTag => MethodBase.GetCurrentMethod().DeclaringType?.FullName;

        #endregion

        #region private variable

        /// <summary>
        /// Scale : representation minimal d'un pixel image sur l'ecran, correspond a la taille original de l'image coincidant avec l'ecran
        /// </summary>
        private float m_MinScale;

        /// <summary>
        /// Scale maximum
        /// </summary>
        private readonly float m_MaxScale = 5.0f;


        /// <summary>
        /// Largeur de l'image en pixel: initialisation dans SetFrame
        /// </summary>
        private int m_Width;

        /// <summary>
        /// Hauteur de l'image en pixel: initialisation dans SetFrame
        /// </summary>
        private int m_Height;

        /// <summary>
        /// intrinsic width of the underlying drawable
        /// </summary>
        private int m_IntrinsicWidth;

        /// <summary>
        /// intrinsic height of the underlying drawable
        /// </summary>
        private int m_IntrinsicHeight;

        /// <summary>
        /// Distance calculée entre les doigts sur l'écran lors du 1er appui pour un changement d'échelle
        /// </summary>
        private double m_PreviousDistance;

        private int m_PreviousMoveX;

        private int m_PreviousMoveY;

        public float TranslateX
        {
            get { return this.GetValue(m_Matrix, Matrix.MtransX); }
        }

        public float TranslateY
        {
            get { return this.GetValue(m_Matrix, Matrix.MtransY); }
        }

        private readonly float[] m_MatrixValues = new float[9];

        /// <summary>
        /// VRAI, si en cours de changement d'échelle
        /// </summary>
        private bool m_IsScaling;

        /// <summary>
        /// Scale de la matrix en X
        /// </summary>
        public float Scale => this.GetValue(m_Matrix, Matrix.MscaleX);

        private Matrix m_Matrix;

        /// <summary>
        /// Context courant 
        /// </summary>
        private readonly Context m_Context;

        /// <summary>
        /// Ratio / Scale : representation d'un pixel image sur l'ecran
        /// </summary>
        private float m_Scale;

        /// <summary>
        /// A convenience class to extend when you only want to listen for a subset of all the gestures.
        /// This implements all methods in the GestureDetector+IOnGestureListener and GestureDetector+IOnDoubleTapListener
        /// but does nothing and return false for all applicable methods.
        /// </summary>
        private GestureDetector scaleGestureDetector;

        #endregion

        #region constructeur

        public ScaleImageView(Context context) : base(context)
        {
            m_Context = context;
            Initialize();
        }

        public ScaleImageView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            m_Context = context;
            Initialize(context, attrs);
        }

        public ScaleImageView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            m_Context = context;
            Initialize(context, attrs);
        }

        public ScaleImageView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            m_Context = context;
            Initialize(context, attrs);
        }

        #endregion

        #region Initialisation

        private void Initialize()
        {
            // Options for scaling the bounds of an image to the bounds of this view. 
            // - CENTER : Center the image in the view, but perform no scaling.
            // - CENTER_CROP : Scale the image uniformly(maintain the image's aspect ratio) so that both dimensions (width and height) of the image will be equal to or larger than the corresponding dimension of the view (minus padding). 
            // - CENTER_INSIDE : Scale the image uniformly(maintain the image's aspect ratio) so that both dimensions (width and height) of the image will be equal to or less than the corresponding dimension of the view (minus padding).  
            // - FIT_CENTER : Scale the image using CENTER. 
            // - FIT_END : Scale the image using END.
            // - FIT_START : Scale the image using START.
            // - FIT_XY : Scale the image using FILL.
            // - MATRIX : Scale using the image matrix when drawing.
            this.SetScaleType(ScaleType.Matrix);

            m_Matrix = new Matrix();
            if (Drawable != null)
            {
                // exemple:
                // Dimension image: 1702 x 866 (pixels)
                // Resources.DisplayMetrics.Density = 3
                // Drawable.IntrinsicWidth = 5106 = 3 x 1702
                // Drawable.IntrinsicHeight = 2598 = 3 x 866 
                m_IntrinsicWidth = Drawable.IntrinsicWidth;
                m_IntrinsicHeight = Drawable.IntrinsicHeight;

                this.SetOnTouchListener(this);
            }
            scaleGestureDetector = new GestureDetector(m_Context, new ScaleImageViewGestureDetector(this));
        }

        private void Initialize(Context context, IAttributeSet attrs = null)
        {
            try
            {
                Initialize();

                int layoutParamsWidth = ViewGroup.LayoutParams.MatchParent;
                int layoutParamsHeight = ViewGroup.LayoutParams.WrapContent;
                int layoutParamsWeight = 1;
                GravityFlags gravity = GravityFlags.NoGravity;
                if (attrs != null)
                {
                    int index = 0;
                    while (index < attrs.AttributeCount)
                    {
                        switch (attrs.GetAttributeName(index))
                        {
                            case "layout_width":
                                layoutParamsWidth = attrs.GetAttributeIntValue(index, 0);
                                break;
                            case "layout_height":
                                layoutParamsHeight = attrs.GetAttributeIntValue(index, 0);
                                break;
                            case "layout_weight":
                                layoutParamsWeight = attrs.GetAttributeIntValue(index, 0);
                                break;
                            case "layout_gravity":
                            case "gravity":
                                gravity = (GravityFlags)attrs.GetAttributeIntValue(index, 0);
                                break;
                            case "background":
                                this.SetBackgroundResource(attrs.GetAttributeIntValue(index, 0));
                                break;
                            case "src":
                                break;
                        }
                        index++;
                    }
                }
                this.LayoutParameters = new LinearLayout.LayoutParams(layoutParamsWidth, layoutParamsHeight, layoutParamsWeight);
            }
            catch (Exception ex)
            {
                if (m_Context is BaseActivity activity) activity.Message(ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// Assign a size and position to this view. This is called from layout.
        /// </summary>
        /// <param name="l">Left position, relative to parent</param>
        /// <param name="t">Top position, relative to parent</param>
        /// <param name="r">Right position, relative to parent</param>
        /// <param name="b">Bottom position, relative to parent</param>
        /// <returns>true if the new size and position are different than the previous ones</returns>
        protected override bool SetFrame(int l, int t, int r, int b)
        {
            // Taille de l'écran 1080 x 1920 pixels
            // Dimension image: 5106 x 2598 pixels = 1702 x 866 dp

            m_Width = r - l;
            m_Height = b - t;

            m_Matrix.Reset();

            // Largeur 5106 pixels representent 1080 pixels
            // Ratio / Scale => 1 px = 1080 / 5106
            int width = r - l;
            m_Scale = (float)width / (float)m_IntrinsicWidth;

            var paddingHeight = 0;
            var paddingWidth = 0;

            // verification hauteur
            if (m_Scale * m_IntrinsicHeight > m_Height)
            {
                m_Scale = (float)m_Height / (float)m_IntrinsicHeight;
                // Postconcats the matrix with the specified scale.
                m_Matrix.PostScale(m_Scale, m_Scale);
                paddingWidth = (r - m_Width) / 2;
            }
            else
            {
                // La hauteur de l'image ratio peut etre contenu dans le layout
                // Postconcats the matrix with the specified scale.
                m_Matrix.PostScale(m_Scale, m_Scale);
                paddingHeight = (b - m_Height) / 2;
            }

            // Postconcats the matrix with the specified translation: M' = T(dx, dy) * M 
            m_Matrix.PostTranslate(paddingWidth, paddingHeight);

            ImageMatrix = m_Matrix;

            m_MinScale = m_Scale;
            ZoomTo(m_Scale, m_Width / 2, m_Height / 2);
            Cutting();

            return base.SetFrame(l, t, r, b);
        }

        private float GetValue(Matrix matrix, int whichValue)
        {
            matrix.GetValues(m_MatrixValues);
            return m_MatrixValues[whichValue];
        }

        #region Touch 

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (scaleGestureDetector.OnTouchEvent(e))
            {
                m_PreviousMoveX = (int)e.GetX();
                m_PreviousMoveY = (int)e.GetY();
                return true;
            }

            var touchCount = e.PointerCount;
            switch (e.Action)
            {
                case MotionEventActions.Down:
                case MotionEventActions.Pointer1Down:
                case MotionEventActions.Pointer2Down:
                    {
                        if (touchCount >= 2) // deux doigts touchent l'écran => changement d'échelle
                        {
                            m_PreviousDistance = Distance(e.GetX(0), e.GetX(1), e.GetY(0), e.GetY(1));
                            m_IsScaling = true;
                        }
                    }
                    break;

                case MotionEventActions.Move:
                    {
                        if (touchCount >= 2 && m_IsScaling) // deux doigts touchent l'écran => changement d'échelle
                        {
                            var distance = this.Distance(e.GetX(0), e.GetX(1), e.GetY(0), e.GetY(1));
                            var scale = (distance - m_PreviousDistance) / this.DispDistance();
                            m_PreviousDistance = distance;
                            scale += 1;
                            scale = scale * scale;
                            this.ZoomTo((float)scale, m_Width / 2, m_Height / 2);
                            this.Cutting();
                        }
                        else if (!m_IsScaling)
                        {
                            var distanceX = m_PreviousMoveX - (int)e.GetX();
                            var distanceY = m_PreviousMoveY - (int)e.GetY();
                            m_PreviousMoveX = (int)e.GetX();
                            m_PreviousMoveY = (int)e.GetY();

                            m_Matrix.PostTranslate(-distanceX, -distanceY);
                            this.Cutting();
                        }
                    }
                    break;
                case MotionEventActions.Up:
                case MotionEventActions.Pointer1Up:
                case MotionEventActions.Pointer2Up:
                    if (touchCount <= 1)
                    {
                        m_IsScaling = false;
                    }
                    break;
            }
            return true;
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            return OnTouchEvent(e);
        }

        #endregion


        /// <summary>
        /// Distance entre deux points de l'écran
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="x1"></param>
        /// <param name="y0"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        private double Distance(float x0, float x1, float y0, float y1)
        {
            var x = x0 - x1;
            var y = y0 - y1;
            return Math.Sqrt(x * x + y * y);
        }

        private double DispDistance()
        {
            return Math.Sqrt(m_Width * m_Width + m_Height * m_Height);
        }

        /// <summary>
        /// Double tap sur l'image provoque un recentrage de l'image et un zoom in
        /// </summary>
        /// <param name="x_centerTo"></param>
        /// <param name="y_centerTo"></param>
        public void MaxZoomTo(int x_centerTo, int y_centerTo)
        {
            if (this.m_MinScale != this.Scale && (Scale - m_MinScale) > 0.1f)
            {
                //var scale = m_MinScale / Scale
                // Impossible de zoomer plus, on recentre la carte sur le point du double clique
                var scale = m_MinScale * 4;
                ZoomTo(scale, x_centerTo, y_centerTo);
            }
            else
            {
                //var scale = m_MaxScale / Scale
                ZoomTo(2, x_centerTo, y_centerTo);
            }
        }

        public void ZoomTo(float scale, int x_centerTo, int y_centerTo)
        {
            if (Scale * scale < m_MinScale)
            {
                scale = m_MinScale / Scale;
            }
            else
            {
                if (scale >= 1 && Scale * scale > m_MaxScale)
                {
                    scale = m_MaxScale / Scale;
                }
            }

            // zoom in : scale > 1.0
            // zoom out : scale < 1.0
            m_Matrix.PostScale(scale, scale);

            //move to center
            m_Matrix.PostTranslate(-(m_Width * scale - m_Width) / 2, -(m_Height * scale - m_Height) / 2);

            //move x and y distance
            m_Matrix.PostTranslate(-(x_centerTo - (m_Width / 2)) * scale, 0);
            m_Matrix.PostTranslate(0, -(y_centerTo - (m_Height / 2)) * scale);
            ImageMatrix = m_Matrix;
        }

        public void Cutting()
        {
            var width = (int)(m_IntrinsicWidth * Scale);
            var height = (int)(m_IntrinsicHeight * Scale);
            if (TranslateX < -(width - m_Width))
            {
                m_Matrix.PostTranslate(-(TranslateX + width - m_Width), 0);
            }

            if (TranslateX > 0)
            {
                m_Matrix.PostTranslate(-TranslateX, 0);
            }

            if (TranslateY < -(height - m_Height))
            {
                m_Matrix.PostTranslate(0, -(TranslateY + height - m_Height));
            }

            if (TranslateY > 0)
            {
                m_Matrix.PostTranslate(0, -TranslateY);
            }

            if (width < m_Width)
            {
                m_Matrix.PostTranslate((m_Width - width) / 2, 0);
            }

            if (height < m_Height)
            {
                m_Matrix.PostTranslate(0, (m_Height - height) / 2);
            }

            ImageMatrix = m_Matrix;
        }
    }
}