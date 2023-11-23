using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

#region
// Workaround for WASM not loading RCL
typeof(CounterCompany.CounterThing).GetType();
#endregion

Console.WriteLine("WASM client is loaded.");

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Build().RunAsync();
