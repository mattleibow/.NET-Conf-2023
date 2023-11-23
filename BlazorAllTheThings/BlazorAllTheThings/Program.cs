using BlazorAllTheThings.Components;
using BlazorAllTheThings.Services;

var builder = WebApplication.CreateBuilder(args);

// TODO: [ 4] 3 [Render Mode] Add `.AddInteractiveServerComponents()` to enable interactive server-side components
// TODO: [ 5] 2 [Render Mode] Add `.AddInteractiveWebAssemblyComponents()` to enable interactive wasm components

// Add services to the container.
builder.Services.AddRazorComponents();

builder.Services.AddSingleton<WeatherService>();
builder.Services.AddSingleton<StarService>();
// TODO: [10] 5 [Shared Mobile] Add RenderModeAdjuster concrete implementation for web
builder.Services.AddSingleton<IRenderModeAdjuster, RenderModeAdjuster>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // TODO: [ 5] 4 [Debugging] Add `app.UseWebAssemblyDebugging();` to enable interactive wasm components
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// TODO: [ 4] 4 [Render Mode] Add `.AddInteractiveServerRenderMode()` to enable interactive server-side components
// TODO: [ 5] 3 [Render Mode] Add `.AddInteractiveWebAssemblyRenderMode()` to enable interactive wasm components
// TODO: [ 9] 2 [Shared Library] Add `.AddAdditionalAssemblies(typeof(BlazorAllTheThings.Components.Layout.MainLayout).Assembly)`

app.MapRazorComponents<App>();

app.Run();

// TODO: [ 1] ----- Streaming
// TODO: [ 2] ----- Enhanced Navigation
// TODO: [ 3] ----- Enhanced Forms
// TODO: [ 4] ----- Interactive Server
// TODO: [ 5] ----- Interactive WASM
// TODO: [ 6] ----- Interactive Auto
// TODO: [ 7] ----- Dynamic Static
// TODO: [ 8] ----- Shared Components
// TODO: [ 9] ----- Shared Library
// TODO: [10] ----- Shared Mobile
