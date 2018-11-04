using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using WonderBooks.Model;
using WonderBooks.Persistence;
using Xamarin.Forms;

namespace WonderBooks.View
{
    public partial class HomePage : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        private ObservableCollection<Book> _books;
        public HomePage()
        {
            InitializeComponent();

          
            _connection=  DependencyService.Get<ISQLiteDb>().GetConnection();  //return conection object

          

        }
       
        protected async override void OnAppearing()
        {

          
            //create table
            await _connection.CreateTableAsync<Book>();

            //fetch the list from database
           var books= await _connection.Table<Book>().ToListAsync();

            //assign it to list of ..
            _books = new ObservableCollection<Book>(books);
            bookListView.ItemsSource = _books;
            base.OnAppearing();
        }
        
        async void OnAdd(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddBookPage(_connection));
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var book = menuItem.CommandParameter as Book;
            await _connection.DeleteAsync(book);
            _books.Remove(book);
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var book = menuItem.CommandParameter as Book;
            var updatebook = new AddBookPage(_connection);
            updatebook.BindingContext = book;
            await Navigation.PushAsync(updatebook);

        }

        async void SelectBook(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var book = e.SelectedItem as Book;
            bookListView.SelectedItem = null;
            await Navigation.PushAsync(new BookDetailPage(book));
        }
    }
}
