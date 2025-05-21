using Android.Content;
using Android.Util;
using Android.Views;

namespace Tutoriels.Code.Views.Touch
{
    [Activity(Label = "Tutorial")]
    internal class TouchActivity : BaseActivity, GestureDetector.IOnGestureListener, ScaleGestureDetector.IOnScaleGestureListener
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.TouchActivity;

        #endregion


        private GestureDetector? _gestureDetector;
        private ScaleGestureDetector? _scaleDetector;
        private ImageView? imageView;
        private float scaleFactor = 1f;

        private ListViewAdapter? _adapter;

        #region life cycle


        /// <summary>
        /// OnCreate est la première méthode à appeler lorsqu’une activité est créée. 
        /// OnCreate est toujours remplacée pour effectuer toutes les initialisations de démarrage qui peuvent être requis par une activité telles que :
        /// - Création de vues
        /// - Initialiser des variables
        /// - Liaison de données statiques aux listes
        /// Aide Windows: https://docs.microsoft.com/fr-fr/xamarin/android/
        /// https://developer.xamarin.com/guides/android/application_fundamentals/activity_lifecycle/
        /// Icon : http://modernuiicons.com/ 
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _adapter = new ListViewAdapter(this);
            FindViewById<ListView>(Resource.Id.ListViewId).Adapter = _adapter;

            _gestureDetector = new GestureDetector(this);
            _scaleDetector = new ScaleGestureDetector(this, this);

            imageView = FindViewById<ImageView>(Resource.Id.imgNapoleon);
            System.Diagnostics.Debug.Assert(imageView != null);
            imageView.Touch += (s,e) =>
            {
                System.Diagnostics.Debug.Assert(e.Event != null);
                _gestureDetector.OnTouchEvent(e.Event);
                _scaleDetector.OnTouchEvent(e.Event);
                // Marque l’événement comme traité
                e.Handled = true;
            };
            FindViewById<Button>(Resource.Id.btnClean).Click += (s,e) =>
            {
                _adapter.Reset();
            };
        }
        public bool OnScale(ScaleGestureDetector detector)
        {
            System.Diagnostics.Debug.Assert(imageView != null);

            scaleFactor *= detector.ScaleFactor;
            scaleFactor = Math.Max(0.5f, Math.Min(scaleFactor, 3.0f));
            imageView.ScaleX = scaleFactor;
            imageView.ScaleY = scaleFactor;
            return true;
        }

        public bool OnScaleBegin(ScaleGestureDetector detector) => true;
        public void OnScaleEnd(ScaleGestureDetector detector) => Log.Info("Gesture", "Pinch ended");


        public bool OnDown(MotionEvent e)
        {
            string message = $"OnDown: action={e.Action} doigts={e.PointerCount} x={e.GetX()} y={e.GetY()}";
            _adapter.Add(new ListViewItem(message));
            return true;
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            string message = $"OnSingleTapUp: action={e.Action} doigts={e.PointerCount} x={e.GetX()} y={e.GetY()}";
            _adapter.Add(new ListViewItem(message));
            return true;
        }

        public void OnLongPress(MotionEvent e)
        {
            string message = $"LongPress: action={e.Action} doigts={e.PointerCount} x={e.GetX()} y={e.GetY()}";
            _adapter.Add(new ListViewItem(message));
        }

        public bool OnScroll(MotionEvent? e1, MotionEvent e2, float distanceX, float distanceY)
        {
            string message = $"Scroll: dx={distanceX}, dy={distanceY}";
            _adapter.Add(new ListViewItem(message));
            return true;
        }

        public void OnShowPress(MotionEvent e)
        {
            Console.WriteLine("ShowPress");
        }

        public bool OnFling(MotionEvent? e1, MotionEvent e2, float velocityX, float velocityY)
        {
            string message = $"OnFling: vx={velocityX}, vy={velocityY}";
            _adapter.Add(new ListViewItem(message));
            return true;
        }



        private void OnTouch(object? sender, View.TouchEventArgs touchEventArgs)
        {
            //inspecter e.Event.PointerCount, e.Event.GetX(index) et e.Event.GetPointerId(index).
            //string message;
            //switch (touchEventArgs.Event.Action & MotionEventActions.Mask)
            //{
            //    case MotionEventActions.Down:
            //    case MotionEventActions.Move:
            //        message = "Touch Begins";
            //        touchEventArgs.Event.ActionIndex
            //        break;

            //    case MotionEventActions.Up:
            //        message = "Touch Ends";
            //        break;

            //    default:
            //        message = string.Empty;
            //        break;
            //}

            //_touchInfoTextView.Text = message;
        }
        #endregion

    }
}
