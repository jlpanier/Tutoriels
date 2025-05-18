using Tutoriels.Code.Activities;
using Tutoriel;


namespace Tutoriels.Code.Activities.Departements
{
    [Activity(Label = "Tutorial")]
    public class DepartementActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.DepartementActivity;

        #endregion


        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FindViewById<ListView>(Resource.Id.ListViewDepartements).Adapter = new ListViewDepartementAdapter(this);
        }
    }
}