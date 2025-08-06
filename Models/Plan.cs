namespace RPlace.Models;

public class Plan
{
    public Guid Id {get; set;}
    public string Type {get; set;}
    public DateTime ExpirationTime {get; set;}
    public int LimitRoomCreate {get; set;}
    public int PaintTime {get; set;}
}