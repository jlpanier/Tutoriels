using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Unicodes
{
    [Activity(Label = "Tutorial", MainLauncher = false, Icon = "@drawable/icon")]
    public class UnicodeActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.UnicodeActivity;

        #endregion


        #region life cycle

        protected override void OnResume()
        {
            base.OnResume();

            FindViewById<ListView>(Resource.Id.ListViewId).Adapter = new ListViewUnicodesAdaptator(this);
        }

        #endregion
    }
}