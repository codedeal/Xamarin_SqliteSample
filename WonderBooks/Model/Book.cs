using System;
using SQLite;
namespace WonderBooks.Model
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
    }
}
