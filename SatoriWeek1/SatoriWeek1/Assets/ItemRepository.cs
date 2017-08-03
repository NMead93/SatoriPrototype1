using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SatoriWeek1.Models;
using SQLite;

namespace SatoriWeek1
{
    public sealed class ItemRepository
    {
        private SQLiteAsyncConnection conn;

        // Singleton of the database repository object.
        private static ItemRepository instance;
        public static ItemRepository Instance
        {
            get
            { 
                if (instance == null)
                {
                    throw new Exception("You must call Initialize before retrieving the singleton for the ItemRepository.");
                }

                return instance;
            }
        }

        public string StatusMessage { get; set; }

        public static void Initialize(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename));
            }

            //avoid db Locking and free unmanaged resources
            if (instance != null)
            {
                instance.conn.GetConnection().Dispose();
            }

            instance = new ItemRepository(filename);
        }

        private ItemRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Item>();
        }

        public async Task AddNewItem(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = await conn.InsertAsync(new Item() { Name = name });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            try
            {
                return await conn.Table<Item>().ToListAsync();

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return Enumerable.Empty<Item>();
        }

        public async Task DeleteItem(int id)
        {
            try
            {
                var Item = await GetItem(id);
                var result = await conn.DeleteAsync(Item);
                StatusMessage = String.Format("Successfully deleted {0}", Item.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete data. {0}", ex.Message);
            }
        }

        public async Task<Item> GetItem(int id)
        {
            return await conn.Table<Item>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}