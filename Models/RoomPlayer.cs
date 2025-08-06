namespace RPlace.Models;

public class RoomPlayer
{
    public Guid Id { get; set; }
    public Player Player { get; set; }
    public Guid PlayerId { get; set; }
    public Room Room { get; set; }
    public Guid RoomId { get; set; }
    public Permission Permission { get; set; }
    public Guid PermissionId { get; set; }

}