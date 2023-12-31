using System.ComponentModel.DataAnnotations;

namespace PGB.Domain.Entities;

public class UserOrder
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int OrdersInCurrentMonth { get; private set; }
    public DateTime? EndDate { get; private set; }

    public UserOrder(int userId)
    {
        UserId = userId;
        OrdersInCurrentMonth = 1;
        EndDate = null;
    }

    public bool CanPlaceOrder()
        => OrdersInCurrentMonth < Restriction.MaxOrderByMonth;

    public void TryIncrementOrdersInCurrentMonth()
    {
        if (OrdersInCurrentMonth < Restriction.MaxOrderByMonth)
            OrdersInCurrentMonth++;
    }

    public void TryBlockUserOrdersForOneMonth()
    {
        if (OrdersInCurrentMonth == Restriction.MaxOrderByMonth)
            EndDate = DateTime.Now.AddMonths(1);
    }


    public void Update(int ordersInCurrentMonth, DateTime? endDate)
    {
        OrdersInCurrentMonth = ordersInCurrentMonth;
        EndDate = endDate;
    }
}