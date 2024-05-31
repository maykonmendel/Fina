using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fina.Client;
using Fina.Client.Handlers;
using Fina.Core;
using Fina.Core.Handlers;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services
    .AddHttpClient(
        WebConfiguration.HttpClientName,
        opt =>
        {
            opt.BaseAddress = new Uri(Configuration.BackendUrl);
        });

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

await builder.Build().RunAsync();
