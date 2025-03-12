using maui_test.Pages;
using maui_test.Services;
using maui_test.ViewModels;
using Microsoft.Extensions.Logging;

namespace maui_test;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<HackerNewsAPI>();

		builder.Services.AddTransient<AllNewsVM>();
		builder.Services.AddTransient<SettingVM>();
		builder.Services.AddTransient<TrendingVM>();
		builder.Services.AddTransient<FilteredNewsVM>();

        return builder.Build();
	}
}
