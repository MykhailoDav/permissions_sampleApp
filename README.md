# permissions_sampleApp

`permissions_sampleApp` is a .NET MAUI sample demonstrating how to implement a storage permission request service for Android. It handles checking and requesting read/write storage permissions in a loop until granted, and guides users to the app settings if permissions are permanently denied.

## Features

- Checks and requests `StorageRead` and `StorageWrite` permissions.
- Automatically repeats permission requests until the user grants permissions or cancels.
- Detects when permissions are permanently denied and prompts users to open app settings to enable permissions manually.
- Android-specific implementation using `ActivityCompat` and `Platform.CurrentActivity`.
- Safe fallback for other platforms, returning false if permissions are not granted.

## Usage

1. Add the `PermissionService` to your dependency injection container or instantiate it directly.

2. Call the asynchronous method `RequestStoragePermissionsLoopAsync()` to ensure storage permissions:

```csharp
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
