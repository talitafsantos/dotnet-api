using Microsoft.Azure.Cosmos;
using Microsoft.Azure.ServiceBus;
using MyMicroservice.Filters;
using MyMicroservice.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(x => new CosmosClient(builder.Configuration["*********************************************************************************************************************************"]));

builder.Services.AddSingleton<ITopicClient>(x => new TopicClient("YourServiceBusConnectionString", "YourTopicName"));

builder.Services.AddSingleton<IRepository, CosmosDbRepository>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<MyExceptionFilter>();
    options.Filters.Add<MyActionFilter>();
});

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
