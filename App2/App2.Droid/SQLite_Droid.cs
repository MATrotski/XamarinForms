using SQLite;
using System;
using App1.Droid;
using System.IO;
using App2;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Droid))]
namespace App1.Droid
{
    public class SQLite_Droid : ISQLite
    {
        public SQLite_Droid() { }

        public SQLiteAsyncConnection GetConnectionAsync(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLiteAsyncConnection(path);
            
            return conn;
        }
    }
}