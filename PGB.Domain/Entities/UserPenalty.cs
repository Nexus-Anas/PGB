using System.ComponentModel.DataAnnotations;

namespace PGB.Domain.Entities;

public class UserPenalty
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PenaltiesInCurrentTrimester { get; set; }
}