using System.ComponentModel.DataAnnotations;

namespace PGB.Domain.Entities;

public class UserPenalty
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PenaltiesInCurrentTrimester { get; set; }

    public UserPenalty(int userId)
    {
        UserId = userId;
        PenaltiesInCurrentTrimester = 1;
    }

    public void TryIncrementUserPenalty()
    {
        if (PenaltiesInCurrentTrimester < Restriction.MaxPenaltyByTrimester)
            PenaltiesInCurrentTrimester++;
    }

    public int GetUserPenaltiesCount()
        => PenaltiesInCurrentTrimester;
}