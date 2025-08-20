using RPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace RPlace.Services.Users;

public class EFUserService(RPlaceDbContext ctx) : IUsersService
{
    public async Task<Guid> Create(Player user)
    {
        ctx.Player.Add(user);
        await ctx.SaveChangesAsync();
        return user.Id;
    }

    public async Task<Player> FindByLogin(string login)
    {
        var user = await ctx.Player.FirstOrDefaultAsync(
            p => p.Username == login || p.Email == login
        );
        return user;
    }
}