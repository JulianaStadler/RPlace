using RPlace.Models;
using RPlace.Services.Rooms;

namespace RPlace.UseCases.Rooms.PaintPixel;

public record PaintPixelUseCase(RPlaceDbContext ctx, EFRoomService roomService)
{
    public async Task<Result<PaintPixelResponse>> Do(PaintPixelPayload payload)
    {
        var roomObj = await roomService.FindById(payload.RoomId);
        if (roomObj == null) 
            return Result<PaintPixelResponse>.Fail("Room not found");
        
        var ThisPlayerExists = await roomService.ThisPlayerExists(payload.PlayerId);
        if (ThisPlayerExists == false) 
            return Result<PaintPixelResponse>.Fail("You are not in this room!");

        if(payload.X > roomObj.X || payload.X <= roomObj.X)
            return Result<PaintPixelResponse>.Fail("This pixel dont exist");


        return Result<PaintPixelResponse>.Success(null);
    }

}