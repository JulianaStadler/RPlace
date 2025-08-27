using Microsoft.AspNetCore.Authorization.Infrastructure;
using RPlace.Models;

namespace RPlace.UseCases.User.CreateRoom;

public record CreateRoomUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        var room = new Room
        {
            Name = payload.Name,
            Width = payload.Width,
            Height = payload.Height
        };

        ctx.Room.Add(room);
        await ctx.SaveChangesAsync();

        return Result<CreateRoomResponse>.Success(new(room.Id));
    }
}

