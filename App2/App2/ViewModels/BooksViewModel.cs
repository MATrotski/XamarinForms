using System.Collections.Generic;
using App2.Database.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModels
{
    class BooksViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddButtonCommand { get; set; }

        public ICommand RemoveAllButtonComand { get; set; }

        public IEnumerable<Book> ListItems
        {
            get
            { 
                return Task.Factory.StartNew(async () =>
                {
                    return await App._bookManager.GetAllItemsAsync();
                }).Result.Result;
            }

            set
            {
                Task.Factory.StartNew(async () =>
                {
                    foreach (var item in value)
                    {
                        await App._bookManager.AddOrUpdateAsync(item);
                    }
                    OnPropertyChanged("ListItems");
                });
            }
        }

        private string _selectedText = "";
        public string SelectedText
        {
            get
            {
                return _selectedText;
            }
            set
            {
                if (_selectedText != value)
                {
                    _selectedText = value;
                    OnPropertyChanged("selectedText");
                }
            }
        }

        public BooksViewModel()
        {
            this.AddButtonCommand = new Command(AddButton);
            this.RemoveAllButtonComand = new Command(RemoveAllButton);
        }

        private void AddButton()
        {
            var items = new List<Book>
            {
                new Book {Id = 1, Name = "ui", Author = "6768"},
                new Book {Id = 2, Name = ",m.,,.,k", Author = "65"},
                new Book {Id = 3, Name = "tytutyuyt", Author = "89877t76"},
                new Book {Id = 4, Name = "mn,hfgjgj", Author = "35345"},
                new Book {Id = 5, Name = "iuopp", Author = "77878"}
            };
            ListItems = items;
        }

        private void RemoveAllButton()
        {
            Task.Factory.StartNew(async()=>
            { 
                await App._bookManager.RemoveAll();
            });
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedText = ((Book)e.SelectedItem).Name;
        }

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
