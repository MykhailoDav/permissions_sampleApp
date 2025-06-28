using CommunityToolkit.Mvvm.ComponentModel;
using permissions_sampleApp.Services;

namespace permissions_sampleApp;

public partial class MainPageViewModel : ObservableObject
{
    private readonly IPermissionService permissionService;

    public MainPageViewModel(IPermissionService permissionService)
    {
        this.permissionService = permissionService;
        CheckPermissionsAsync().ConfigureAwait(false);

    }
    public static async Task CheckPermissionsAsync()
    {
        var permissionService = new PermissionService();
        bool hasPermissions = await permissionService.RequestStoragePermissionsLoopAsync();

        if (hasPermissions)
        {
            // Continue working with file storage
        }
        else
        {
            // Handle user denial gracefully
        }
    }
}
