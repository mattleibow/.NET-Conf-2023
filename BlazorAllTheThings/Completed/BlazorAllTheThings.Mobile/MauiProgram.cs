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

        builder.Services.AddSingleton<WeatherService>();
        builder.Services.AddSingleton<StarService>();

        builder.Services.AddSingleton<IRenderModeAdjuster, RenderModeAdjuster>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    #region
    static BlazorAllTheThings.Components.Extras.Placeholder? ExtrasKeeper;
    static BlazorAllTheThings.Services.Placeholder? ServicesKeeper;
    #endregion
}
