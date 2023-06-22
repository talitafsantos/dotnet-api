public class MyObjectDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    // Adicione outros campos conforme necessário
}

public interface IRepository
{
    Task Save(MyObjectDto dto);
}
