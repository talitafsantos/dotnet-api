using Microsoft.Azure.Cosmos;
using MyMicroservice.Models;

namespace MyMicroservice.Repositories
{
    public class CosmosDbRepository : IRepository
    {
        private readonly CosmosClient _cosmosClient;

        public CosmosDbRepository(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }

        public async Task Save(MyObjectDto dto)
        {
            var container = _cosmosClient.GetContainer("MyData", "Mycontainer");
            await container.CreateItemAsync(dto);
        }
    }
}
