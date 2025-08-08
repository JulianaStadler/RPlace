namespace RPlace.Models;

public class Permission
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public ICollection<RoomPlayer> RoomPlayers { get; set; } = [];
}