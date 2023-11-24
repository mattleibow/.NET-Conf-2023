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

        // TODO: [10]  3 [Shared Mobile] Register services
        //builder.Services.AddSingleton<WeatherService>();
        //builder.Services.AddSingleton<StarService>();

        // TODO: [10]  6 [Shared Mobile] Register RenderModeAdjuster concrete implementation for mobile
        //builder.Services.AddSingleton<IRenderModeAdjuster, RenderModeAdjuster>();

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

// TODO: [10]  2 [Shared Mobile] Add `_content/BlazorAllTheThings.Shared/` to all shared things in index.html
