using BasketService.Consumers;
using Shared;
using Shared.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
                 .AddDbContext<BasketContext>(options =>
                        options.UseNpgsql(builder.Configuration.GetConnectionString("basketConn"))
                 );

builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("BasketService"));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHttpContextAccessor();

builder.Services.AddConsulConfig(builder.Configuration);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderCompletedEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ReceiveEndpoint(RabbitMQSettings.OrderCompletedEventQueueName, e =>
        {
            e.ConfigureConsumer<OrderCompletedEventConsumer>(context);
        });

        cfg.Host(builder.Configuration.GetConnectionString("RabbitMQ"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

builder.Services.AddMassTransitHostedService();

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
