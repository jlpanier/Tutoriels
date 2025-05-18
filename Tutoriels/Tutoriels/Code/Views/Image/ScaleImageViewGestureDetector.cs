using Android.Views;

namespace Tutoriels.Code.Activities.Image
{
    public class ScaleImageViewGestureDetector : GestureDetector.SimpleOnGestureListener
    {
        private readonly ScaleImageView m_ScaleImageView;

        public ScaleImageViewGestureDetector(ScaleImageView image) : base()
        {
            m_ScaleImageView = image;
        }

        /// Notified when a tap occurs with the down MotionEvent that triggered it.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool OnDown(MotionEvent e)
        {
            return true;
        }

        /// <summary>
        /// Notified when a double-tap occurs.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool OnDoubleTap(MotionEvent e)
        {
            //m_ScaleImageView.MaxZoomTo((int)e.GetX(), (int)e.GetY());
            //m_ScaleImageView.Cutting();
            return true;
        }
    }
}