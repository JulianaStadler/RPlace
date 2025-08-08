using RPlace.Models;

namespace RPlace.UseCases.User.CreateRoom;

public class CreateRoomUseCase
{
    public async Task<Results<CreateRoom>> Do(CreateRoomPayload payload)
    {
        var room = new Room {
            Name = payload.Name,
            Width = payload.Width,
            Height = payload.Height 
        };
    }
}