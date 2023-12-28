namespace PGB.Domain.Entities;

public class CustomMessage
{
    public static string UserRestricted(int userId)
        => $"User ID: {userId}\nYour account is currently restricted. Please contact support for assistance.";

    public static string MaxOrderReached(int userId)
        => $"User ID: {userId}\nUnable to place another book order at the moment. Please try again later.";

    public static string InformBookReturned(int userId)
        => $"User ID: {userId}\nBooks successfully returned to the library.";

    public static string InformBookOrder(int userId)
    => $"User ID: {userId}\nYour book order has been successfully processed. We appreciate your choice of our library services. Thank you!";

    public static string NoBookOrderFound(int userId)
        => $"User ID: {userId}\nNo orders found. For assistance, please contact support.";

    public static string UserBanned(int userId)
        => $"User ID: {userId}\nYour account is temporarily restricted due to overdue book returns. Contact support for assistance. Thank you for your understanding.";


}