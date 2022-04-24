using IdentityServer.Configurations;
using Shared.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    //.AddCustomTokenRequestValidator<CustomTokenRequestValidator>()
    .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
    .AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes())
    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
    .AddInMemoryClients(IdentityServerConfig.GetClients());

builder.Services.AddConsulConfig(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseIdentityServer();

app.UseConsul(builder.Configuration);

app.Run();
