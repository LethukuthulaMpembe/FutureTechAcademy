using FutureTechAcademy.Models;
using FutureTechAcademy.Services;
using Microsoft.Azure.Cosmos;

public class CosmosService : ICosmosService
{
    private readonly Container _container;

    public CosmosService(CosmosClient dbClient, string databaseName, string containerName)
    {
        _container = dbClient.GetContainer(databaseName, containerName);
    }

    public async Task AddStudentAsync(Student student)
    {
        await _container.CreateItemAsync(student, new PartitionKey(student.Id));
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        var query = _container.GetItemQueryIterator<Student>(new QueryDefinition("SELECT * FROM c"));
        List<Student> results = new List<Student>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }
        return results;
    }

    public async Task<Student> GetStudentByIdAsync(string id)
    {
        try
        {
            ItemResponse<Student> response = await _container.ReadItemAsync<Student>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch { return null; }
    }

    public async Task UpdateStudentAsync(Student student)
    {
        await _container.UpsertItemAsync(student, new PartitionKey(student.Id));
    }

    public async Task DeleteStudentAsync(string id)
    {
        await _container.DeleteItemAsync<Student>(id, new PartitionKey(id));
    }
}
