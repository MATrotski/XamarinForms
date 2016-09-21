using System.Collections.Generic;
using System.Threading.Tasks;
using App2.Database.Models;
using SQLite;
using Xamarin.Forms;

namespace App2.Database.Managers
{
    public class BooksManager
    {
        private SQLiteAsyncConnection _db;

        public BooksManager(string fileName)
        {
            _db = DependencyService.Get<ISQLite>().GetConnectionAsync(fileName);
            _db.CreateTableAsync<Book>();
        }

        public async Task<Book> GetItemAsync(int id)
        {
            return await _db.GetAsync<Book>(id);
        }

        public async Task<IEnumerable<Book>> GetAllItemsAsync()
        {
            return await _db.Table<Book>().ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(string author)
        {
            return await _db.QueryAsync<Book>("SELECT Name FROM Book WHERE Author={0}", author);
            //return await _db.Table<Book>().Where(b => b.Author == author).ToListAsync();
        }

        public async Task<int> AddOrUpdateAsync(Book book)
        {
            if (book.Id < 0)
            {
                await _db.UpdateAsync(book);
                return book.Id;
            }
            return await _db.InsertAsync(book);
        }

        public async Task<int> DeleteItemAsync(int id)
        {
            var book = await _db.GetAsync<Book>(id);
            return await _db.DeleteAsync(book);
        }

        public async Task RemoveAll()
        {
            var books = await GetAllItemsAsync();
            foreach (Book b in books)
            {
                await _db.DeleteAsync(b);
            }
        }
    }
}
