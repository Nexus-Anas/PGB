using System.ComponentModel.DataAnnotations;

namespace PGB.Domain.Entities;

public class BannedUser
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public BannedUser(int userId) => UserId = userId;
}