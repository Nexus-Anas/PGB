namespace PGB.Domain.Entities;

public class BookOrder
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public IEnumerable<Book> Books { get; private set; }
    public DateTime OrderDate { get; private set; }
    public DateTime ExpectedReturnDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }

    public BookOrder(int userId, IEnumerable<Book> books)
    {
        UserId = userId;
        Books = books;
        OrderDate = DateTime.Now;
        ExpectedReturnDate = DateTime.Now.AddDays(7);
        ReturnDate = null;
    }

    public void SetReturnDate()
        => ReturnDate = DateTime.Now;

    public bool BooksReturnedInExpectedDate()
        => ExpectedReturnDate >= DateTime.Now;
}