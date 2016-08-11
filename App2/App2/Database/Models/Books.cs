using SQLite;

namespace App2.Database.Models
{
    [Table("Books")]
    public class Book
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
