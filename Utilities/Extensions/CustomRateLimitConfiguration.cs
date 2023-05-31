using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Utilities.Extensions;

public class CustomRateLimitConfiguration : RateLimitConfiguration
{
    public CustomRateLimitConfiguration(
        IOptions<IpRateLimitOptions> ipOptions,
        IOptions<ClientRateLimitOptions> clientOptions) : base(ipOptions, clientOptions)
    {
    }

    public override void RegisterResolvers()
    {
        ClientResolvers.Add(new ClientIdResolverContributor());
    }
}

public class ClientIdResolverContributor : IClientResolveContributor
{
    public Task<string> ResolveClientAsync(HttpContext httpContext)
    {
        return Task.FromResult<string>(httpContext.Request.Query["CustomKey"]);
    }
}