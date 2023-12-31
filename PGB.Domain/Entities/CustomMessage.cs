namespace PGB.Domain.Entities;

public static class CustomMessage
{
    public static string UserRestricted()
        => "Your account is currently restricted. Please contact support for assistance.";

    public static string MaxOrderReached()
        => "Unable to place another book order at the moment. Please try again later.";

    public static string InformBookReturned()
        => "Books successfully returned to the library.";

    public static string InformBookOrder()
        => "Your book order has been successfully processed. We appreciate your choice of our library services. Thank you!";

    public static string NoBookOrderFound()
        => "No orders found. For assistance, please contact support.";

    public static string UserBanned()
        => "Your account is temporarily restricted due to overdue book returns. Contact support for assistance. Thank you for your understanding.";

    public static string ErrorOccurred()
        => "Something went wrong. Try again later.";


}