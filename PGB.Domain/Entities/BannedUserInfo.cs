namespace PGB.Domain.Entities;

public class BannedUserInfo
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public BannedUserInfo(int userId)
    {
        UserId = userId;
        StartDate = DateTime.Now;
        EndDate = DateTime.Now.AddDays(7);
    }

    public void BanUserForOneYear()
        => EndDate = DateTime.Now.AddYears(1);
}