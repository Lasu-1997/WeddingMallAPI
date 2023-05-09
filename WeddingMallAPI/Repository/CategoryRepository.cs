using Microsoft.EntityFrameworkCore;
using WeddingMallAPI.Models;

namespace WeddingMallAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WeddingDBContext weddingDBContext;

        public CategoryRepository(WeddingDBContext _weddingDBContext)
        {
            weddingDBContext = _weddingDBContext;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
           return await weddingDBContext.Category.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await weddingDBContext.Category.FindAsync(id);
        }
        public async Task<Category> Add(Category category)
        {
            weddingDBContext.Category.Add(category);
            await weddingDBContext.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Update(Category category)
        {
            weddingDBContext.Entry(category).State = EntityState.Modified;
            await weddingDBContext.SaveChangesAsync();
            return category;
        }

        public async void DeleteById(int id)
        {
            var result = await weddingDBContext.Category.FindAsync(id);
            if (result != null)
            {
                weddingDBContext.Category.Remove(result);
                await weddingDBContext.SaveChangesAsync();
            }
        }     
    }
}
