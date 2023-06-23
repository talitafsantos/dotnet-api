using MyMicroservice.Models;

namespace MyMicroservice.Repositories
{
    public interface IRepository
    {
        Task Save(MyObjectDto dto);
    }
}
