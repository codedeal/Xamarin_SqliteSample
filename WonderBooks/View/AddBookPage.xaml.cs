using System;
using System.Collections.Generic;
using WonderBooks.Model;
using Xamarin.Forms;
using SQLite;
using System.Collections.ObjectModel;

namespace WonderBooks.View
{
    public partial class AddBookPage : ContentPage
    {
        SQLiteAsyncConnection connection;
        private ObservableCollection<Book> _books;
        public AddBookPage(SQLiteAsyncConnection _connection)
        {
            connection = _connection;
            _books = new ObservableCollection<Book>();
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
           
            base.OnAppearing();
        }
        async void AddBookClicked(object sender, System.EventArgs e)
        {
            var todoItem = (Book)BindingContext;
            if (todoItem == null)
            {
                var book = new Book { Name = bookName.Text, Author = bookAuthor.Text, Price = Convert.ToDouble(bookPrice.Text) };
                await connection.InsertAsync(book);
                _books.Add(book);
            }
            else
            {

                if (todoItem.Id != 0)
                {
                    await connection.UpdateAsync(todoItem);


                }
                //else
                //{
                //    var book = new Book { Name = bookName.Text, Author = bookAuthor.Text, Price = Convert.ToDouble(bookPrice.Text) };
                //    await connection.InsertAsync(book);
                //    _books.Add(book);
                //}
            }
                var addbookPage = new HomePage();
                addbookPage.BindingContext = _books;

                await Navigation.PopAsync();

        }
    }
}
