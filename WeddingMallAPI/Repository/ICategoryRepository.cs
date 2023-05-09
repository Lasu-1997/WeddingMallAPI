using WeddingMallAPI.Models;

namespace WeddingMallAPI.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        void DeleteById(int id);

    }
}
