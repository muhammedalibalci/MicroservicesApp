using CatalogService.Mapping;
using Shared.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddConsulConfig(builder.Configuration);

builder.Services.AddEntityFrameworkNpgsql()
                 .AddDbContext<CatalogContext>(options =>
                        options.UseNpgsql(builder.Configuration.GetConnectionString("catalogConn"))
                 );

builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("CatalogService"));

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseConsul(builder.Configuration);

app.Run();
