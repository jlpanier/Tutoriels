using Android.Views;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.NavigationBar
{
    [Activity(Label = "Tutorial")]
    public class NavigationBarActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.NavigationBarActivity;

        #endregion

        private CheckBox cbSystemUiVisibility;
        private CheckBox cbLowProfile;
        private CheckBox cbHideNavigation;
        private CheckBox cbFullscreen;
        private CheckBox cbLightNavigationBar;
        private CheckBox cbLayoutStable;
        private CheckBox cbLayoutHideNavigation;
        private CheckBox cbLayoutFullscreen;
        private CheckBox cbLayoutFlags;
        private CheckBox cbImmersive;
        private CheckBox cbImmersiveSticky;
        private CheckBox cbLightStatusBar;

        #region Life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            cbSystemUiVisibility = FindViewById<CheckBox>(Resource.Id.cbSystemUiVisibility);
            cbSystemUiVisibility.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbLowProfile = FindViewById<CheckBox>(Resource.Id.cbLowProfile);
            cbLowProfile.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbHideNavigation = FindViewById<CheckBox>(Resource.Id.cbHideNavigation);
            cbHideNavigation.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbFullscreen = FindViewById<CheckBox>(Resource.Id.cbFullscreen);
            cbFullscreen.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbLightNavigationBar = FindViewById<CheckBox>(Resource.Id.cbLightNavigationBar);
            cbLightNavigationBar.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbLayoutStable = FindViewById<CheckBox>(Resource.Id.cbLayoutStable);
            cbLayoutStable.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbLayoutHideNavigation = FindViewById<CheckBox>(Resource.Id.cbLayoutHideNavigation);
            cbLayoutHideNavigation.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbLayoutFullscreen = FindViewById<CheckBox>(Resource.Id.cbLayoutFullscreen);
            cbLayoutFullscreen.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbLayoutFlags = FindViewById<CheckBox>(Resource.Id.cbLayoutFlags);
            cbLayoutFlags.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbImmersive = FindViewById<CheckBox>(Resource.Id.cbImmersive);
            cbImmersive.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbImmersiveSticky = FindViewById<CheckBox>(Resource.Id.cbImmersiveSticky);
            cbImmersiveSticky.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };
            cbLightStatusBar = FindViewById<CheckBox>(Resource.Id.cbLightStatusBar);
            cbLightStatusBar.CheckedChange += (s, e) =>
            {
                Window.DecorView.SystemUiVisibility = GetStatus();
            };

            Window.DecorView.SystemUiVisibilityChange += (s, e) =>
            {
                Message(e.Visibility.ToString());
            };
        }

        protected override void OnResume()
        {
            base.OnResume();

            StatusBarVisibility statusBarVisibility = Window.DecorView.SystemUiVisibility;
            cbSystemUiVisibility.Checked = statusBarVisibility == StatusBarVisibility.Visible;
            cbLowProfile.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.LowProfile) == SystemUiFlags.LowProfile;
            cbHideNavigation.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.HideNavigation) == SystemUiFlags.HideNavigation;
            cbFullscreen.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.Fullscreen) == SystemUiFlags.Fullscreen;
            cbLightNavigationBar.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.LightNavigationBar) == SystemUiFlags.LightNavigationBar;
            cbLayoutStable.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.LayoutStable) == SystemUiFlags.LayoutStable;
            cbLayoutHideNavigation.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.LayoutHideNavigation) == SystemUiFlags.LayoutHideNavigation;
            cbLayoutFullscreen.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.LayoutFullscreen) == SystemUiFlags.LayoutFullscreen;
            cbLayoutFlags.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.LayoutFlags) == SystemUiFlags.LayoutFlags;
            cbImmersive.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.Immersive) == SystemUiFlags.Immersive;
            cbImmersiveSticky.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.ImmersiveSticky) == SystemUiFlags.ImmersiveSticky;
            cbLightStatusBar.Checked = (Window.DecorView.WindowSystemUiVisibility & SystemUiFlags.LightStatusBar) == SystemUiFlags.LightStatusBar;
        }

        private StatusBarVisibility GetStatus()
        {
            SystemUiFlags status = 0;
            if (cbLowProfile.Checked) status |= SystemUiFlags.LowProfile;
            if (cbHideNavigation.Checked) status |= SystemUiFlags.HideNavigation;
            if (cbFullscreen.Checked) status |= SystemUiFlags.Fullscreen;
            if (cbLightNavigationBar.Checked) status |= SystemUiFlags.LightNavigationBar;
            if (cbLayoutStable.Checked) status |= SystemUiFlags.LayoutStable;
            if (cbLayoutHideNavigation.Checked) status |= SystemUiFlags.LayoutHideNavigation;
            if (cbLayoutFullscreen.Checked) status |= SystemUiFlags.LayoutFullscreen;
            if (cbLayoutFlags.Checked) status |= SystemUiFlags.LayoutFlags;
            if (cbImmersive.Checked) status |= SystemUiFlags.Immersive;
            if (cbImmersiveSticky.Checked) status |= SystemUiFlags.ImmersiveSticky;
            if (cbLightStatusBar.Checked) status |= SystemUiFlags.LightStatusBar;

            return (StatusBarVisibility)status;
        }

        #endregion
    }
}
