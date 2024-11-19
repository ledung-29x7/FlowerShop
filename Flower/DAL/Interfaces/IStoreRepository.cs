using Flower.Areas.Admin.Models;
using Flower.Areas.Manager.Models;

namespace Flower.DAL.Interfaces
{
    public interface IStoreRepository 
    {
        Task CreateStore(Store store);
        Task<List<Store>> GetStores();
        Task<Store> GetStoreById(int store_id);
        Task UpdateStore(Store store);
        Task DeleteStore(int store_id);
    }
}
