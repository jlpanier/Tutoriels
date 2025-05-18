namespace Tutoriels.Code.Activities.AndroidColors
{
    [Activity(Label = "Tutorial")]
    public class AndroidColorsActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.AndroidColorsActivity;

        #endregion

        #region Life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FindViewById<ListView>(Resource.Id.ListViewColor).Adapter = new ListViewAndroidColorsAdaptator(this);
        }

        #endregion
    }
}