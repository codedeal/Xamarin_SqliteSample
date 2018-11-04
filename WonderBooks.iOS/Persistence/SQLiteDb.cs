using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using WonderBooks.Persistence;
using WonderBooks.iOS.Persistence;

[assembly: Dependency(typeof(SQLiteDb))]
namespace WonderBooks.iOS.Persistence
{
    public class SQLiteDb: ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLiteBooks.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
