namespace PGB.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int Quantity { get; set; }

    public Book(int bookId, int quantity)
    {
        BookId = bookId;
        Quantity = quantity;
    }
}
