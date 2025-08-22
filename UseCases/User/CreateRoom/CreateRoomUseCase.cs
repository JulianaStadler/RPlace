using Microsoft.AspNetCore.Authorization.Infrastructure;
using RPlace.Models;

namespace RPlace.UseCases.User.CreateRoom;

public record CreateRoomUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        // var room = new Room
        // {
        //     //NameAuthorizationRequirement =
        // }
        return Result<CreateRoomResponse>.Success(null);
    }
}

