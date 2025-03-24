using Metalurgica.Web;
using Metalurgica.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Text.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton(new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
});
builder.Services.AddScoped<LoginWebService>();
builder.Services.AddScoped<ProductWebService>();
builder.Services.AddScoped<QuesitoWebService>();
builder.Services.AddScoped<EmbalagemWebService>();
builder.Services.AddScoped<LoteWebService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7147/api") });


builder.Services.AddMudServices();

await builder.Build().RunAsync();
