
using IdentityServer4.Models;

namespace IdentityServer.Configurations;

public static class IdentityServerConfig
{
    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>
        {
            new("default-api","default api"),
        };
    }

    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResources.Phone()
        };
    }

    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            new()
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"default-api"},
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                }
            }
        };
    }

}