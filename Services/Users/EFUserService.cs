using RPlace.Models;
using Microsoft.EntityFrameworkCore;
using RPlace.UseCases.User.EditAccount;

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

    public async Task<Player> Alter(EditAccountPayload payload)
    {
        var player = await ctx.Player.FindAsync(payload.PlayerId);

        if (player == null)
            throw new Exception("Player não encontrado");

        // player.Username = payload.Username ?? player.Username;
        // player.Username = payload.Username ?? player.Username;
        // player.Username = payload.Username ?? player.Username;
        // player.Username = payload.Username ?? player.Username;
        // player.Username = payload.Username ?? player.Username;

        if (payload.Email is not null)
        {
            player.Email = payload.Email;
        }
        if (payload.Password is not null)
        {
            player.Password = payload.Password;
        }
        if (payload.LinkPicture is not null)
        {
            player.LinkPicture = payload.LinkPicture;
        }
        if (payload.Bio is not null)
        {
            player.Bio = payload.Bio;
        }

        await ctx.SaveChangesAsync();
        return player;
    }
}