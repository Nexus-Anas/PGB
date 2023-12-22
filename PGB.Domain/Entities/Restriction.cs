namespace PGB.Domain.Entities;

public class Restriction
{
    public static int MaxOrderByMonth { get; } = 3;
    public static int MaxPenaltyByTrimester { get; } = 3;
}