namespace RPlace.Models;

public class Room
{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public int Size {get; set;}
    public Guid CreatorPlayerId {get; set;}
    public Player CreatorPlayer {get; set;}
}