namespace PGB.Domain.Entities;

public class BookOrder
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public IEnumerable<Book> Books { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ReturnDate { get; set; }
}