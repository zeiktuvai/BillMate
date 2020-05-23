using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillMate.Services.Data.Factory
{
    public class DataConnectionFactory
    {
        public SQLiteConnection SQLiteCon { get; set; }
        public SQLiteConnection InitiateSqliteConnection(string DBPath)
        {            
            SQLiteCon = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath);
            return SQLiteCon;
        }

    }
}
