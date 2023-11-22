using BlazorAllTheThings.Components;
using BlazorAllTheThings.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// TODO: 07 [Render Mode] Add `.AddInteractiveServerComponents()` to enable interactive server-side components
// TODO: 10 [Render Mode] Add `.AddInteractiveWebAssemblyComponents()` to enable interactive wasm components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // TODO: 12 [Debugging] Add `app.UseWebAssemblyDebugging()` to enable interactive wasm components
    app.UseWebAssemblyDebugging();
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

// TODO: 08 [Render Mode] Add `.AddInteractiveServerRenderMode()` to enable interactive server-side components
// TODO: 11 [Render Mode] Add `.AddInteractiveWebAssemblyRenderMode()` to enable interactive wasm components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    ;

app.Run();
