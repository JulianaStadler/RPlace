using RPlace.Models;

namespace RPlace.UseCases.User.SeeMyRooms;

public record SeeMyRoomsResponse(
    IEnumerable<Room> Rooms
);
