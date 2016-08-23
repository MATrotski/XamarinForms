using App2.Database.Models;
using App2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{

    public partial class MainPage : ContentPage
    {
        private readonly IList<Book> books;
        public MainPage()
        {
            InitializeComponent();
            /*books = new List<Book>()
            {
                new Book {Id = 0, Name="kljkhg", Author = "1111"},
                new Book {Id = 1, Name="fsfsgfd", Author = "dhgfhfghf"},
                new Book {Id = 2, Name="4543654", Author = "qwe"},
                new Book {Id = 3, Name="fdfgf", Author = "333333"}
            };*/
        }

        protected override void OnAppearing()
        {
            //this.BindingContext = new BooksViewModel();
            //DbList.BindingContext = await App._bookManager.GetAllItems();
            base.OnAppearing();
        }

        //protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
            //Selected.Text = ((Book)e.SelectedItem).Name;
        //}

    }
}
