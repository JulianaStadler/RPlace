using Microsoft.EntityFrameworkCore;
using RPlace.Models;
using RPlace.Services.Rooms;

namespace RPlace.UseCases.Rooms.SeePlayers;

public record SeePlayersUseCase(RPlaceDbContext ctx, EFRoomService roomService)
{
    public async Task<Result<SeePlayersResponse>> Do(SeePlayersPayload payload)
    {
        var roomIdService = await roomService.FindById(payload.RoomId);
        if (roomIdService == null) 
            return Result<SeePlayersResponse>.Fail("Room not found");
        var roomId = roomIdService.Id;



        return Result<SeePlayersResponse>.Success(null);
    }
}