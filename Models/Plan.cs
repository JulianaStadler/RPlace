namespace RPlace.Models;

public class Plan
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public int LimitRoomCreate { get; set; }
    public int PaintTime { get; set; }
    public ICollection<Player> Players { get; set; } = [];
    public ICollection<GiftCard> GiftCards { get; set; } = [];
}