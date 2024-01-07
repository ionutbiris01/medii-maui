using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Medii_maui.Models;

namespace Medii_maui.Data
{
    public class DeliveryDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public DeliveryDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Delivery>().Wait();
        }
        public Task<List<Delivery>> GetDeliveriesAsync()
        {
            return _database.Table<Delivery>().ToListAsync();
        }
        public Task<Delivery> GetDeliveryAsync(int id)
        {
            return _database.Table<Delivery>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveDeliveryAsync(Delivery slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteDeliveryAsync(Delivery slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
