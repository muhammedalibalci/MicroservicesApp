using IdentityServer4.Validation;
using Newtonsoft.Json;
using Shared.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IdentityServer.Configurations;
public class CustomTokenRequestValidator : ICustomTokenRequestValidator
{
    public Task ValidateAsync(CustomTokenRequestValidationContext context)
    {
        // Roles have to by user type

        var roles = new string[] { Roles.ReadOrder, Roles.WriteOrder };
        context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
        context.Result.ValidatedRequest.Client.UpdateAccessTokenClaimsOnRefresh = true;
        context.Result.ValidatedRequest.Client.ClientClaimsPrefix = "";
        context.Result.ValidatedRequest.ClientClaims.Add(
            new Claim("role", JsonConvert.SerializeObject(roles), JsonClaimValueTypes.JsonArray));

        return Task.CompletedTask;
    }
}
