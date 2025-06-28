namespace permissions_sampleApp.Services;

public interface IPermissionService
{
    Task<bool> RequestStoragePermissionsLoopAsync();
}