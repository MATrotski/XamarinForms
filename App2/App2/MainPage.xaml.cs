using App2.Database.Models;
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

        protected override async void OnAppearing()
        {
            await App._bookManager.AddOrUpdate(new Book { Id = 0, Name = "kljkhg", Author = "1111" });
            await App._bookManager.AddOrUpdate(new Book { Id = 1, Name = "ui", Author = "6768" });
            await App._bookManager.AddOrUpdate(new Book { Id = 2, Name = ",m.,,.,k", Author = "65" });
            await App._bookManager.AddOrUpdate(new Book { Id = 3, Name = "tytutyuyt", Author = "89877t76" });
            await App._bookManager.AddOrUpdate(new Book { Id = 4, Name = "mn,hfgjgj", Author = "35345" });
            await App._bookManager.AddOrUpdate(new Book { Id = 5, Name = "iuopp", Author = "77878" });
            var qqq = await App._bookManager.GetAllItems();
            DbList.BindingContext = await App._bookManager.GetAllItems();//books;
            base.OnAppearing();
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Selected.Text = ((Book)e.SelectedItem).Name;
        }
    }
}
