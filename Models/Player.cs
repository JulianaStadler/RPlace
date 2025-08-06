namespace RPlace.Models;

public class Player
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string LinkPicture { get; set; }
    public string Bio { get; set; }
    public Guid PlanId { get; set; }
    public Plan Plan { get; set; }
    public DateTime PlanExpirationDate { get; set; }

    public ICollection<Room> Rooms { get; set; } = []; 
}