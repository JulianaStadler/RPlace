namespace RPlace.UseCases.Rooms.SeePlayers;

public record SeePlayersResponse(
    IEnumerable<PlayersInRoomm?> PlayersInRoom
);

public record PlayersInRoomm
{
    public required Guid PlayerId { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required string LinkPicture { get; init; }
}