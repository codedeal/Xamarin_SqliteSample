using System;
using SQLite;

namespace WonderBooks.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
