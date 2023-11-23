using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

// Workaround for WASM not loading RCL
typeof(CounterCompany.CounterThing).GetType();

Console.WriteLine("WASM client is loaded.");

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Build().RunAsync();
