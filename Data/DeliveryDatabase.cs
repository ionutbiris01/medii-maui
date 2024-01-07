using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Medii_maui.Models;
using SQLiteNetExtensionsAsync.Extensions;
using SQLiteNetExtensions.Extensions;

namespace Medii_maui.Data
{
    public class DeliveryDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public DeliveryDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Delivery>().Wait();
            _database.CreateTableAsync<Status>().Wait();
            _database.CreateTableAsync<ListStatus>().Wait();
            _database.ExecuteAsync("PRAGMA foreign_keys=ON;").Wait();

        }
        #region Delivery
        public Task<List<Delivery>> GetDeliveriesAsync()
        {
            return _database.GetAllWithChildrenAsync<Delivery>();
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
        #endregion

        #region Status

        public Task<int> SaveStatusAsync(Status status)
        {
            if (status.ID != 0)
            {
                return _database.UpdateAsync(status);
            }
            else
            {
                return _database.InsertAsync(status);
            }
        }
        public Task<int> DeleteStatusAsync(Status status)
        {
            return _database.DeleteAsync(status);
        }
        public Task<Status> GetStatusAsync(int id)
        {
            return _database.Table<Status>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<List<Status>> GetStatusesAsync()
        {
            return _database.Table<Status>().ToListAsync();
        }

        public Task<int> SaveListStatusAsync(ListStatus lists)
        {
            if (lists.ID != 0)
            {
                return _database.UpdateAsync(lists);
            }
            else
            {
                return _database.InsertAsync(lists);
            }
        }
        public Task<List<Status>> GetListStatusesAsync(int deliveryid)
        {
            return _database.QueryAsync<Status>(
            "select S.ID, S.StatusName from Status S"
            + " inner join ListStatus LS"
            + " on S.ID = LS.StatusID where LS.DeliveryID = ?",
            deliveryid);
        }

        public Task<Status> GetStatusByNameAsync(string statusName)
        {
            return _database.Table<Status>()
                .Where(s => s.StatusName == statusName)
                .FirstOrDefaultAsync();
        }


        #endregion

    }
}
