using Android.Runtime;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Canvas
{
    [Activity(Label = "Tutorial")]
    public class PickFileActivity : BaseActivity
    {
        public const int RequestCodeImage = 1000;

        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.PickFileActivity;

        #endregion

        #region life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViewById<Button>(Resource.Id.btnPick).Click += (s, e) =>
            {
                Android.Content.Intent intent = new Android.Content.Intent();
                intent.SetType("image/*");
                intent.SetAction(Android.Content.Intent.ActionGetContent);

                StartActivityForResult(Android.Content.Intent.CreateChooser(intent, "Select Picture"), RequestCodeImage);

            };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (data == null) return;
            if (resultCode != Result.Ok) return;
            switch (requestCode)
            {
                case RequestCodeImage:
                    if (data != null)
                    {
                        FindViewById<TextView>(Resource.Id.tvFile).Text = data.Data.ToString();
                    }
                    break;
            }
        }

        #endregion



    }
}