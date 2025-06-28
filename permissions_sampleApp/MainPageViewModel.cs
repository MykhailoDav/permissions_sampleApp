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
    public async Task CheckPermissionsAsync()
    {
        bool granted = await permissionService.RequestStoragePermissionsLoopAsync();
        if (granted)
        {
            // Виконати логіку з файлами
        }
    }
}
