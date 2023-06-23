namespace MyMicroservice.Models {
    public class MyObjectDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
}

public interface IRepository
{
    Task Save(MyObjectDto dto);
}
}

