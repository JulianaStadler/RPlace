using RPlace.Models;
using RPlace.Services.Rooms;
using RPlace.Services.Users;


namespace RPlace.UseCases.Rooms.SeePixels;

public record SeePixelsUseCase(RPlaceDbContext ctx, EFRoomService roomService)
{
    public async Task<Result<SeePixelsResponse>> Do(SeePixelsPayload payload)
    {
        var roomIdService = await roomService.FindById(id);
            if (roomIdService == null) 
                return Results.NotFound("Room not found");

            var roomId = roomIdService.Id;
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;


        return Result<SeePixelsResponse>.Success(null);
    }
}