using Microsoft.AspNetCore.Authentication;

namespace Host.Authentication;

public class ApiKeyAuthenticationSchemeOptions: AuthenticationSchemeOptions {
    public string ApiKey {get; set;}
}