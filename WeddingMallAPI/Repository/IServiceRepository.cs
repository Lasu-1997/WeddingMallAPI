using WeddingMallAPI.Models;

namespace WeddingMallAPI.Repository
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAll();
        Task<Service> GetById(int id);
        Task<Service> Add(Service service);
        Task<Service> Update(Service service);
        void DeleteById(int id);
    }
}
