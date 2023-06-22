public class CosmosDbRepository : IRepository
{
    private readonly CosmosClient _cosmosClient;

    public CosmosDbRepository(CosmosClient cosmosClient)
    {
        _cosmosClient = cosmosClient;
    }

    public async Task Save(MyObjectDto dto)
    {
        var container = _cosmosClient.GetContainer("MyData", "Mycontainer"); // Substitua "databaseId" e "containerId" pelos seus próprios valores.

        var itemResponse = await container.CreateItemAsync(dto);

        // Faça algo com itemResponse, se necessário.
    }
}
