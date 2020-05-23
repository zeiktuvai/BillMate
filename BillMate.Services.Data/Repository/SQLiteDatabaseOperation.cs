using BillMate.Services.Data.Factory;
using BillMate.Services.Data.Interfaces;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;

namespace BillMate.Services.Data.Repository
{
    public class SQLiteDatabaseOperation<T> : IDatabaseOperation<T> where T : class
    {
        // Constructor creates a new sqlite connection object using the db path
        internal SQLiteConnection con { get; set; }
        public static readonly string Path = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "bills.db3");

        public SQLiteDatabaseOperation(string DBPath = "")
        {
            DataConnectionFactory SQLiteConnection = new DataConnectionFactory();
            DBPath = (string.IsNullOrEmpty(DBPath)) ? DBPath = Path : DBPath;
            con = SQLiteConnection.InitiateSqliteConnection(DBPath);
        }

        /// <summary>
        /// Get a table from the DB as a list of objects
        /// </summary>
        /// <param name="TableType"></param>
        /// <returns>An IEnumerable of T, or null if the table is not found.</returns>
        public IEnumerable<T> GetTable(T TableType)
        {
            try
            {
                return (from p in con.Table<T>() select p).ToList();
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        public void CreateItem(T ItemToCreate)
        {
            con.Insert(ItemToCreate);
        }
        public void DeleteItem(T ItemToDelete)
        {
            con.Delete(ItemToDelete);
        }
        public void UpdateItem(T ItemToUpdate)
        {
            con.Update(ItemToUpdate);
        }
        public int ExecuteCmd(string cmd)
        {
            return con.Execute(cmd);
        }
    }
}
