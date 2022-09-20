using Blazor;
using Blazor.BL.Interface;
using Blazor.BL.Repository;
using Blazor.DAL.DataBase;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(
                client => client.BaseAddress = new Uri("http://localhost:5041"));

builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(
    client => client.BaseAddress = new Uri("http://localhost:5041"));

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


await builder.Build().RunAsync();
