
using IdentityServer4.Models;
using Shared.Configurations;

namespace IdentityServer.Configurations;

public static class IdentityServerConfig
{
    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>
        {
            new(Roles.ReadOrder,"Read order"),
            new(Roles.WriteOrder,"Write order"),
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

    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("OrderService"){ Scopes = { Roles.ReadOrder,Roles.WriteOrder } },
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
                AllowedScopes = {Roles.ReadOrder,Roles.WriteOrder},
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                }
            }
        };
    }

}