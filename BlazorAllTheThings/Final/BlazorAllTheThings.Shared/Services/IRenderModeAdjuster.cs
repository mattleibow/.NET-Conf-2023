using Microsoft.AspNetCore.Components;

namespace BlazorAllTheThings.Services;

public interface IRenderModeAdjuster
{
    IComponentRenderMode? Adjust(IComponentRenderMode mode);
}
