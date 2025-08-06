namespace RPlace.Models;

public class Invite
{
    public Guid Id {get; set;}
    public Player PlayerId {get; set;}
    public Player Player {get; set;}
    public Guid RoomId {get; set;}
    public Room Room {get; set;}
    public bool Acception {get; set;}
}