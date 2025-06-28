#if ANDROID
using AndroidX.Core.App;
#endif

namespace permissions_sampleApp.Services;

public class PermissionService : IPermissionService
{
    public async Task<bool> RequestStoragePermissionsLoopAsync()
    {
        while (true)
        {
            var readStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            var writeStatus = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (readStatus == PermissionStatus.Granted && writeStatus == PermissionStatus.Granted)
                return true;

            readStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
            writeStatus = await Permissions.RequestAsync<Permissions.StorageWrite>();

            if (readStatus == PermissionStatus.Granted && writeStatus == PermissionStatus.Granted)
                return true;

            bool canRequestAgain =
                ActivityCompat.ShouldShowRequestPermissionRationale(Platform.CurrentActivity, Android.Manifest.Permission.ReadExternalStorage) ||
                ActivityCompat.ShouldShowRequestPermissionRationale(Platform.CurrentActivity, Android.Manifest.Permission.WriteExternalStorage);


            if (!canRequestAgain)
            {
                bool goToSettings = await Application.Current.MainPage.DisplayAlert(
                    "Assign Permissions",
                    "You have permanently denied access to storage, but app needs it to function properly. Open app settings to allow it manually?",
                    "Open",
                    " ");

                if (goToSettings)
                {
                    OpenAppSettings();
                    await Task.Delay(5000);
                }
            }
        }
    }

#if ANDROID
    private static void OpenAppSettings()
    {
        AppInfo.ShowSettingsUI();
    }
#endif
}
