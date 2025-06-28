using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using permissions_sampleApp.Services;

namespace permissions_sampleApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiCommunityToolkit()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
			
		builder.Services.AddTransientWithShellRoute<MainPage, MainPageViewModel>(nameof(MainPage));
		builder.Services.AddSingleton<IPermissionService, PermissionService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
