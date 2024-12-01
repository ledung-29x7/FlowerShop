using Flower.Areas.Admin.Models;
using Flower.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Flower.DAL.Repositorys
{
    public class StoreRepository : IStoreRepository
    {
        private readonly FlowerDbContext _context;

        public StoreRepository(FlowerDbContext context) 
        {
            _context = context;
        }
        public async Task CreateStore(Store store)
        {
            var Name_param = new SqlParameter("@Name", store.Store_name);
            var Address_param = new SqlParameter("@Address", store.Address);
            var Phone_param = new SqlParameter("@Phone_number", store.Phone_number);
            var Email_param = new SqlParameter("@Email", store.Email);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.CreateStore @Name, @Address, @Phone_number, @Email", Name_param, Address_param, Phone_param, Email_param);

        }

        public async Task DeleteStore(int store_id)
        {
            var id_Param = new SqlParameter("@Store_id", store_id);
            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.DeleteStore @Store_id", id_Param);
        }

        public async Task<List<Store>> GetStores()
        {
            return await Task.FromResult(_context.stores.FromSqlRaw("EXECUTE dbo.GetStores").ToList());
        }

        public async Task<Store> GetStoreById(int store_id)
        {
            var id_Param = new SqlParameter("@Store_id", store_id);
            var stores = await _context.stores
                .FromSqlRaw("EXECUTE dbo.GetStoreById @Store_id", id_Param)
                .ToListAsync();
            return stores.FirstOrDefault();
        }

        public async Task UpdateStore(Store store)
        {
            var id_Param = new SqlParameter("@Store_id", store.Store_id);
            var Name_param = new SqlParameter("@Name", store.Store_name);
            var Address_param = new SqlParameter("@Address", store.Address);
            var Phone_param = new SqlParameter("@Phone_number", store.Phone_number);
            var Email_param = new SqlParameter("@Email", store.Email);
            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.UpdateStore @Store_id, @Name, @Address, @Phone_number, @Email", id_Param, Name_param, Address_param, Phone_param, Email_param);
        }
    }
}
