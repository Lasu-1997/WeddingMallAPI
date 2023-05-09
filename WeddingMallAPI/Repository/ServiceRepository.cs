using Microsoft.EntityFrameworkCore;
using WeddingMallAPI.Models;

namespace WeddingMallAPI.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly WeddingDBContext weddingDBContext;

        public ServiceRepository(WeddingDBContext _weddingDBContext)
        {
            weddingDBContext = _weddingDBContext;
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await weddingDBContext.Service.ToListAsync();
        }
        public async Task<Service> GetById(int id)
        {
            return await weddingDBContext.Service.FindAsync(id);
        }
        public async Task<Service> Add(Service service)
        {
            weddingDBContext.Service.Add(service);
            await weddingDBContext.SaveChangesAsync();
            return service;
        }
        public async Task<Service> Update(Service service)
        {
            weddingDBContext.Entry(service).State = EntityState.Modified;
            await weddingDBContext.SaveChangesAsync();
            return service;
        }
        public async void DeleteById(int id)
        {
            var result = await weddingDBContext.Service.FindAsync(id);
            if(result != null)
            {
                weddingDBContext.Service.Remove(result);
                await weddingDBContext.SaveChangesAsync();
            }
        }      
    }
}
