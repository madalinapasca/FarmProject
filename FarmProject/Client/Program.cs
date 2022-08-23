using FarmProject.Client;
using FarmProject.Client.Services.AnimalServices;
using FarmProject.Client.Services.FoodServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAnimalService, AnimalsService>();
builder.Services.AddScoped<IFoodService, FoodService>();


await builder.Build().RunAsync();
