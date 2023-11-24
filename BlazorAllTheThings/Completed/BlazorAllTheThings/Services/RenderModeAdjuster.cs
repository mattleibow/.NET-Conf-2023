using Microsoft.AspNetCore.Components;

namespace BlazorAllTheThings.Services;

public class RenderModeAdjuster : IRenderModeAdjuster
{
    public IComponentRenderMode? Adjust(IComponentRenderMode mode) => mode;
}
