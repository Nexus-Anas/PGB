using System.ComponentModel.DataAnnotations;

namespace PGB.Domain.Entities;

public class UserOrder
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OrdersInCurrentMonth { get; set; }
    public DateTime? EndDate { get; set; }
}
