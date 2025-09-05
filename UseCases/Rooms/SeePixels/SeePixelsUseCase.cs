using Microsoft.EntityFrameworkCore;
using RPlace.Models;
using RPlace.Services.Rooms;
using RPlace.Services.Users;


namespace RPlace.UseCases.Rooms.SeePixels;

public record SeePixelsUseCase(RPlaceDbContext ctx, IRoomService roomService)
{
    public async Task<Result<SeePixelsResponse>> Do(SeePixelsPayload payload)
    {
        var roomIdService = await roomService.FindById(payload.RoomId);
        if (roomIdService == null) 
            return Result<SeePixelsResponse>.Fail("No rooms");
        var roomId = roomIdService.Id;


        var picture = await ctx.Room
            .Where(r => r.Id == roomId)
            .SelectMany(r => r.Pixels)
            .Select(p => new PicturePixels
            {
                PixelId = p.Id,
                X = p.X,
                Y = p.Y,
                R = p.R,
                G = p.G,
                B = p.B
            })
            .ToArrayAsync();
            

        if (picture is null)
            return Result<SeePixelsResponse>.Fail("No avaliable picture");

        return Result<SeePixelsResponse>.Success(new(picture));
    }
}