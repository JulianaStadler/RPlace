using RPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace RPlace.Services.Rooms;

public class EFRoomService(RPlaceDbContext ctx) : IRoomService
{
    public async Task<Room> FindById(Guid id)
    {
        var room = await ctx.Room.FirstOrDefaultAsync(
            p => p.Id == id
        );
        return room;
    }

    public async Task<bool> ThisPlayerExists(Guid id)
    {
        var user = await ctx.Player.FirstOrDefaultAsync(
            p => p.Id == id
        );
        return user == null ? false : true;
    }
}