namespace Authentication.API.Entities;

public class UserOrder
{
    public int UserId { get; set; }
    public IEnumerable<Book> Books { get; set; }
}
