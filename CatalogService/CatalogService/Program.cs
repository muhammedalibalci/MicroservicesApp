using CatalogService.Mapping;
using CatalogService.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

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

app.Run();
