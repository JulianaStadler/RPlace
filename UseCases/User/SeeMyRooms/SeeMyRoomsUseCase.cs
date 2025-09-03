using Microsoft.EntityFrameworkCore;
using RPlace.Models;

namespace RPlace.UseCases.User.SeeMyRooms;

public record SeeMyRoomsUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeeMyRoomsResponse>> Do(SeeMyRoomsPayload payload)
    {
        var rooms = ctx.RoomPlayer.Where(rp => rp.PlayerId == payload.PlayerId).Select(rp => rp.Room);

        if (rooms is null)
            return Result<SeeMyRoomsResponse>.Fail("You are not in any rooms.");

        return Result<SeeMyRoomsResponse>.Success(new(rooms));
    }
}

