using Android.Animation;
using Android.Graphics.Drawables;
using Android.Views.Animations;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities
{
    [Activity(Label = "Tutorial")]
    public class AnimationActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.AnimationActivity;

        #endregion

        #region life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var myAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.animation);
            var myImage = FindViewById<ImageView>(Resource.Id.imgnapoleon);
            myImage.StartAnimation(myAnimation);

            var animator = ObjectAnimator.OfFloat(myImage, "SomeIntegerValue", 0, 100);
            animator.SetDuration(1000);
            animator.Start();

            var asteroidDrawable = Resources.GetDrawable(Resource.Drawable.android_animation) as AnimationDrawable;

            var asteroidImage = FindViewById<ImageView>(Resource.Id.imgandroid);
            asteroidImage.SetImageDrawable(asteroidDrawable);

            FindViewById<Button>(Resource.Id.button).Click += (sender, e) =>
            {
                asteroidDrawable.Start();
            };

        }

        #endregion
    }
}