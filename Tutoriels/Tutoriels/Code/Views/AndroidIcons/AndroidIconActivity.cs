using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.AndroidIcons
{
    [Activity(Label = "Tutorial")]
    public class AndroidIconActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.AndroidIconActivity;

        #endregion


        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FindViewById<ListView>(Resource.Id.ListViewId).Adapter = new ListViewAndroidIconAdaptator(this);
        }
    }
}