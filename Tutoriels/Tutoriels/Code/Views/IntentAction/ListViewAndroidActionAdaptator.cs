using Android.Provider;
using Android.Views;
using AndroidX.Core.Content;

namespace Tutoriels.Code.Activities.IntentAction
{
    public class ListViewAndroidActionAdaptator : SimpleAdapter<ListViewAndroidActionsItem>
    {
        protected override int LayoutResourceId => Resource.Layout.AndroidActionsItems;

        public ListViewAndroidActionAdaptator(Activity context, bool allaction) : base(context)
        {
            Load(allaction);
        }

        private void Load(bool allaction)
        {
            var items = new List<ListViewAndroidActionsItem>();
            //var action = Android.Content.Intent.ActionPackageFirstLaunch;
            //Type t = action.GetType();
            //PropertyInfo[] props = t.GetProperties();
            //foreach (PropertyInfo prop in props)
            //{
            //    if (prop.GetIndexParameters().Length == 0 && prop.PropertyType.Name.StartsWith("Action"))
            //    {
            //        items.Add(new ListViewAndroidActionsItem(prop.Name));
            //    }
            //}
            items.Add(new ListViewAndroidActionsItem(string.Empty));
            items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionCall));
            items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionDefault));
            items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionEdit));
            items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMain));
            items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPick));
            items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPickActivity));
            items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionView));
            items.Add(new ListViewAndroidActionsItem(MediaStore.ActionImageCapture));
            items.Add(new ListViewAndroidActionsItem(MediaStore.ExtraShowActionIcons));
            items.Add(new ListViewAndroidActionsItem(MediaStore.IntentActionVideoCamera));



            if (allaction)
            {
                items.Add(new ListViewAndroidActionsItem(MediaStore.ActionImageCaptureSecure));
                items.Add(new ListViewAndroidActionsItem(MediaStore.ActionVideoCapture));

                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionAirplaneModeChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionAllApps));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionAnswer));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionAppError));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionApplicationPreferences));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionApplicationRestrictionsChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionAssist));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionAttachData));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionBatteryChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionBatteryLow));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionBatteryOkay));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionBootCompleted));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionBugReport));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionCallButton));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionCarrierSetup));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionChooser));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionCloseSystemDialogs));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionConfigurationChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionCreateDocument));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionCreateShortcut));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionDateChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionDelete));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionDial));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionDockEvent));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionDreamingStarted));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionDreamingStopped));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionExternalApplicationsAvailable));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionExternalApplicationsUnavailable));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionFactoryTest));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionGetContent));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionGetRestrictionEntries));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionGtalkServiceConnected));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionGtalkServiceDisconnected));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionHeadsetPlug));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionInputMethodChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionInsert));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionInsertOrEdit));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionInstallPackage));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionLocaleChanged));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionLockedBootCompleted));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionManagedProfileAdded));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionManagedProfileAvailable));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionManagedProfileRemoved));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionManagedProfileUnavailable));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionManagedProfileUnlocked));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionManageNetworkUsage));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionManagePackageStorage));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaBadRemoval));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaButton));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaChecking));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaEject));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaMounted));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaNofs));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaRemoved));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaScannerFinished));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaScannerScanFile));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaScannerStarted));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaShared));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaUnmountable));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMediaUnmounted));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionMyPackageReplaced));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionNewOutgoingCall));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionOpenDocument));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionOpenDocumentTree));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageAdded));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageDataCleared));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageFirstLaunch));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageFullyRemoved));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageNeedsVerification));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageRemoved));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageReplaced));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageRestarted));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackagesSuspended));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackagesUnsuspended));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPackageVerified));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPaste));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPowerConnected));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPowerDisconnected));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionPowerUsageSummary));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionProcessText));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionProviderChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionQuickClock));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionQuickView));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionReboot));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionRun));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionScreenOff));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionScreenOn));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionSearch));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionSearchLongPress));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionSend));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionSendMultiple));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionSendto));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionSetWallpaper));
                //items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionShowAppInfo));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionShutdown));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionSync));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionSystemTutorial));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionTimeChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionTimeTick));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionTimezoneChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionUidRemoved));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionUmsConnected));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionUmsDisconnected));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionUninstallPackage));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionUserBackground));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionUserForeground));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionUserInitialize));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionUserPresent));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ExtraShutdownUserspaceOnly));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionVoiceCommand));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionWallpaperChanged));
                items.Add(new ListViewAndroidActionsItem(Android.Content.Intent.ActionWebSearch));

            }
            Reset(items);
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            ListViewAndroidActionsHolder holder = view.Tag as ListViewAndroidActionsHolder;

            if (holder == null)
            {
                holder = new ListViewAndroidActionsHolder();
                holder.tvAction = view.FindViewById<TextView>(Resource.Id.tvAction);
                holder.imgStatus = view.FindViewById<ImageView>(Resource.Id.imgStatus);
                view.Tag = holder;
            }

            holder.Item = Items[position];
            holder.tvAction.Text = holder.Item.Name;
            switch (holder.Item.Status)
            {
                case ListViewAndroidActionsItem.EnumStatus.NotSet:
                    holder.imgStatus.SetImageResource(Android.Resource.Drawable.CheckboxOffBackground);
                    holder.tvAction.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this.Context, Resource.Color.textColorSecondary)));
                    break;
                case ListViewAndroidActionsItem.EnumStatus.Enable:
                    holder.imgStatus.SetImageResource(Android.Resource.Drawable.CheckboxOnBackground);
                    holder.tvAction.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this.Context, Resource.Color.textColorPrimary)));
                    break;
                case ListViewAndroidActionsItem.EnumStatus.Disable:
                    holder.imgStatus.SetImageResource(Android.Resource.Drawable.IcDialogAlert);
                    holder.tvAction.SetTextColor(Android.Graphics.Color.Red);
                    break;
            }

            return view;
        }

    }
}