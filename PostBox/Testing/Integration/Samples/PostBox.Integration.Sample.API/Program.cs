using PostBox.Common.DataAccess.DAL;
using PostBox.Common.DataAccess.DAL.InMemory;
using PostBox.Outbound.Ingestion.Interface;
using PostBox.Outbound.Ingestion.Interface.Ingestors;
using PostBox.Outbound.Relayer.Interface;
using PostBox.Outbound.Relayer.Interface.Models;
using PostBox.Outbound.Relayer.Interface.Relayers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IPostboxOutboundIngestor<>), typeof(RabbitMqIngestor<>));
builder.Services.AddSingleton<IPostboxMessageRepository, PostboxInMemoryRepositroy>();
builder.Services.Configure<PostboxOutboundRelayerConfig>(builder.Configuration.GetSection("RelayerSettings")); 
builder.Services.AddSingleton<IPostboxOutboundRelayer, RabbitMqOutboundRelayer>();
PostBox.Outbound.Relayer.Interface.Relayers.RegistrationHooks.Register(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
