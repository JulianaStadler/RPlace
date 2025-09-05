using RPlace.Models;
using Microsoft.EntityFrameworkCore;
using RPlace.UseCases.User.EditAccount;
using RPlace.Services.Password;

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
    public async Task<Player> FindById(Guid id)
    {
        var user = await ctx.Player.FirstOrDefaultAsync(
            p => p.Id == id
        );
        return user;
    }

    public async Task<Player> Alter(
        EditAccountPayload payload,
        IUsersService usersService,
        IPasswordService passwordService
        )
    {
        var player = await ctx.Player.FindAsync(payload.PlayerId);

        if (player == null)
            throw new Exception("User not found!");

        player.Username = payload.Username ?? player.Username;
        player.Email = payload.Email ?? player.Email;
        player.Password = passwordService.Hash(payload.Password) ?? player.Password;
        player.LinkPicture = payload.LinkPicture ?? player.LinkPicture;
        player.Bio = payload.Bio ?? player.Bio;

        await ctx.SaveChangesAsync();
        return player;
    }
}