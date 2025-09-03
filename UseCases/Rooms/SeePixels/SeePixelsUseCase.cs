using Microsoft.EntityFrameworkCore;
using RPlace.Models;
using RPlace.Services.Rooms;
using RPlace.Services.Users;


namespace RPlace.UseCases.Rooms.SeePixels;

public record SeePixelsUseCase(RPlaceDbContext ctx, EFRoomService roomService)
{
    public async Task<Result<SeePixelsResponse>> Do(SeePixelsPayload payload)
    {
        var roomIdService = await roomService.FindById(payload.RoomId);
        if (roomIdService == null) 
            return Result<SeePixelsResponse>.Fail("No rooms");
        var roomId = roomIdService.Id;


        var picture = await ctx.Room
            .Include(r => r.Pixels)
            .ToArrayAsync();

        if (picture is null)
            return Result<SeePixelsResponse>.Fail("No avaliable picture");

        return Result<SeePixelsResponse>.Success(new(PicturePixels));
    }
}