namespace PGB.Application.Interfaces;

public interface IUserRestrictionHandler
{
    Task<bool> IsUserRestricted(int userId);
    Task HandleLateReturn(int userId);
}
