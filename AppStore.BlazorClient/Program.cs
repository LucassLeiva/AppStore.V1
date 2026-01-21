var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAppStoreServices(client =>
{
    client.BaseAddress =
    new Uri(builder.Configuration["WebApiAddress"]);
});

await builder.Build().RunAsync();
