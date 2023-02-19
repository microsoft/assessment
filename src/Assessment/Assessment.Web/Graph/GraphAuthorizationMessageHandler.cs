using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class GraphAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public GraphAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigation, IConfiguration config)
        : base(provider, navigation)
    {
        ConfigureHandler(
            authorizedUrls: new[] { config.GetSection("MicrosoftGraph")["BaseUrl"] },
            scopes: config.GetSection("MicrosoftGraph:Scopes").Get<List<string>>());
    }
}