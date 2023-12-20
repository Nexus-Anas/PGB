namespace PGB.Domain.Entities;

public class BookReturn
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public IEnumerable<Book> Books { get; set; }
    public DateTime ReturnDate { get; set; }
}
