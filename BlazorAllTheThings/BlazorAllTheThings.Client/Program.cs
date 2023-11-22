using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

Console.WriteLine("WASM client is loaded.");

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Build().RunAsync();
