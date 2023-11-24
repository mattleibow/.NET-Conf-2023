using BlazorAllTheThings.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorAllTheThings.Mobile.Services;

public class RenderModeAdjuster : IRenderModeAdjuster
{
    public IComponentRenderMode? Adjust(IComponentRenderMode mode) => null;
}
