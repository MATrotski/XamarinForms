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

        public ICommand AddButtonCommand { protected get; set; }

        public IEnumerable<Book> ListItems
        {
            get
            {
                return App._bookManager.GetAllItems().Result;
            }

            set
            {
                Task.Factory.StartNew(async () =>
                {
                    foreach (var item in value)
                    {
                        await App._bookManager.AddOrUpdate(item);
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

        //Book Book { get; set; }

        public BooksViewModel()
        {
            //Book = new Book();
            this.AddButtonCommand = new Command(AddButton);
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
            /*Task.Factory.StartNew(async () =>
            {
                await App._bookManager.AddOrUpdate(new Book {Id = 1, Name = "ui", Author = "6768"});
                await App._bookManager.AddOrUpdate(new Book {Id = 2, Name = ",m.,,.,k", Author = "65"});
                await App._bookManager.AddOrUpdate(new Book {Id = 3, Name = "tytutyuyt", Author = "89877t76"});
                await App._bookManager.AddOrUpdate(new Book {Id = 4, Name = "mn,hfgjgj", Author = "35345"});
                await App._bookManager.AddOrUpdate(new Book {Id = 5, Name = "iuopp", Author = "77878"});
            });*/
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedText = ((Book)e.SelectedItem).Name;
        }

        /*public int Id {
            get { return Book.Id; }
            set
            {
                if (Book.Id != value)
                {
                    Book.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get { return Book.Name; }
            set
            {
                if (Book.Name != value)
                {
                    Book.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Author
        {
            get { return Book.Author; }
            set
            {
                if (Book.Author != value)
                {
                    Book.Author = value;
                    OnPropertyChanged("Author");
                }
            }
        }*/


        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
