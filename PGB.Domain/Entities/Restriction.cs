namespace PGB.Domain.Entities;

public class Restriction
{
    public int MaxOrderByMonth { get; } = 3;
    public int MaxPenaltyByTrimester { get; } = 3;
}
