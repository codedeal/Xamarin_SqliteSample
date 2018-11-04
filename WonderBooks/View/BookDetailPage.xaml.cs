using System;
using System.Collections.Generic;
using WonderBooks.Model;
using Xamarin.Forms;

namespace WonderBooks.View
{
    public partial class BookDetailPage : ContentPage
    {
        private Book _book;
        public BookDetailPage(Book book)
        {
            _book = book;
            InitializeComponent();
            BindingContext = _book;
            //bookTable = _book;

        }
    }
}
