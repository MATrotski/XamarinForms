using SQLite;
using System.Threading.Tasks;

namespace App2
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnectionAsync(string filename);
    }
}