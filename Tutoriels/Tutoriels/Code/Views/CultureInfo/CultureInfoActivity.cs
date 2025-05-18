using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Culture
{
    [Activity(Label = "Tutorial")]
    public class CultureInfoActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.CultureInfoActivity;

        #endregion

        #region Internal Variable

        private ListViewAdapter _adapter;

        #endregion

        #region life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViewById<ListView>(Resource.Id.ListViewId).Adapter = _adapter = new ListViewAdapter(this);
        }



        #endregion

    }
}