using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyMicroservice.Filters;
using MyMicroservice.Models;
using MyMicroservice.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure o Cosmos DB
builder.Services.AddSingleton(x => new CosmosClient("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="));
builder.Services.AddSingleton(x => new CosmosClient(builder.Configuration["CosmosDb:ConnectionString"]));

// Configure o Azure Service Bus
builder.Services.AddSingleton<ITopicClient>(x => new TopicClient("YourServiceBusConnectionString", "YourTopicName"));

// Adicione os serviços ao DI container
builder.Services.AddSingleton<IRepository, CosmosDbRepository>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<MyAuthorizationFilter>();
    options.Filters.Add<MyExceptionFilter>();
    options.Filters.Add<MyActionFilter>();
});

// Crie o aplicativo
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
