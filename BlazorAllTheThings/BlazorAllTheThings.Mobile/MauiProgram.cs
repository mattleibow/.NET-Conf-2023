using BlazorAllTheThings.Mobile.Services;
using BlazorAllTheThings.Services;
using Microsoft.Extensions.Logging;

namespace BlazorAllTheThings.Mobile;

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
            });

        // TODO: [10] 5 [Shared Mobile] Register services
        //builder.Services.AddSingleton<WeatherService>();
        //builder.Services.AddSingleton<StarService>();
        // TODO: [10] 5 [Shared Mobile] Add RenderModeAdjuster concrete implementation for web
        //builder.Services.AddSingleton<IRenderModeAdjuster, RenderModeAdjuster>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
