using Assessment.Shared.ZeroTrust;
using Assessment.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Fast.Components.FluentUI;
using Syncfusion.Blazor;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTE2NzYwNUAzMjMwMmUzNDJlMzBMU2JQWXQ2UUJ5OXYwWGVUR0ZPVXIyWFA1ZUVNSTkxYVZyeXN4bkplRGkwPQ==");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFluentUIComponents();
builder.Services.AddScoped<GlobalState>();

builder.Services.AddMsalAuthentication(options =>
{
    options.ProviderOptions.DefaultAccessTokenScopes.Add("DeviceManagementApps.Read.All");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("Directory.Read.All");
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

var graphBaseUrl = string.Join("/",
    builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"],
    builder.Configuration.GetSection("MicrosoftGraph")["Version"]);
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(graphBaseUrl, scopes);

builder.Services.AddTransient<GraphAuthorizationMessageHandler>();
builder.Services.AddHttpClient("GraphAPI", client => client.BaseAddress = new Uri(graphBaseUrl))
    .AddHttpMessageHandler<GraphAuthorizationMessageHandler>();

builder.Services.AddScoped<IZeroTrustDataService, ZeroTrustDataService>();

builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
