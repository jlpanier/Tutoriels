using Android.Views;
using System.Reflection;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.NumberPickerNamespace
{
    [Activity(Label = "Tutorial")]
    public class NumberPickerActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.NumberPickerActivity;

        #endregion

        #region Life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            List<string> data = new List<string>();
            foreach (ViewLayoutMode layoutmode in Enum.GetValues(typeof(ViewLayoutMode)))
            {
                data.Add(layoutmode.ToString());
            }
            Spinner spViewLayoutMode = FindViewById<Spinner>(Resource.Id.spViewLayoutMode);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, data);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spViewLayoutMode.Adapter = adapter;
            spViewLayoutMode.ItemSelected += (s, e) =>
            {
                foreach (ViewLayoutMode item in Enum.GetValues(typeof(ViewLayoutMode)))
                {
                    if (item.ToString() == spViewLayoutMode.GetItemAtPosition(e.Position).ToString())
                    {
                        FindViewById<NumberPicker>(Resource.Id.np).LayoutMode = item;
                    }
                }
            };

            CheckBox cbWrapSelectorWheel = FindViewById<CheckBox>(Resource.Id.cbWrapSelectorWheel);
            cbWrapSelectorWheel.CheckedChange += (s, e) =>
            {
                FindViewById<NumberPicker>(Resource.Id.np).WrapSelectorWheel = e.IsChecked;
            };

            Reset();
        }

        protected void Reset()
        {
            NumberPicker np = FindViewById<NumberPicker>(Resource.Id.np);
            np.MinValue = 1;
            np.MaxValue = 10;
            np.Value = 5;
        }


        #endregion
    }
}