namespace RPlace.Models;

public class Room
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public ICollection<RoomPlayer> RoomPlayers { get; set; } = [];
    public ICollection<Pixel> Pixels { get; set; } = [];
}