using RPlace.Models;

namespace RPlace.UseCases.User.CreateRoom;

public record CreateRoomUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        return Result<CreateRoomResponse>.Success(null);
    }
}

