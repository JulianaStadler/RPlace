using RPlace.Models;

namespace RPlace.Services.Rooms;

public interface IRoomService
{
    Task<Room> FindById(Guid id);
    Task<bool> ThisPlayerExists(Guid id);
}