using Microsoft.EntityFrameworkCore;
using RPlace.Models;
using RPlace.Services.Rooms;

namespace RPlace.UseCases.Rooms.SeePlayers;

public record SeePlayersUseCase(RPlaceDbContext ctx, IRoomService roomService)
{
    public async Task<Result<SeePlayersResponse>> Do(SeePlayersPayload payload)
    {
        var roomIdService = await roomService.FindById(payload.RoomId);
        if (roomIdService == null) 
            return Result<SeePlayersResponse>.Fail("Room not found");
        var roomId = roomIdService.Id;
        
        var ThisPlayerExists = await roomService.ThisPlayerExists(payload.PlayerId);
        if (ThisPlayerExists == false) 
            return Result<SeePlayersResponse>.Fail("You are not in this room!");

        var users = await ctx.Room
            .Where(r => r.Id == roomId)
            .SelectMany(
                r => r.RoomPlayers.Select( 
                    rp => new PlayersInRoomm{
                        PlayerId = rp.Player.Id,
                        Username = rp.Player.Username,
                        Email = rp.Player.Email,
                        LinkPicture = rp.Player.LinkPicture
                    }
                ))
            .ToArrayAsync();

        // ******esse retorno nao existe pois ele pode retornar uma lista vazia
        // mesmo que nao existam usuarios na sala ele mostra uma lista vazia
        // if (users is null)
        //     return Result<SeePlayersResponse>.Fail("No users in this room");

        return Result<SeePlayersResponse>.Success(new(users));
    }
}