using Microsoft.EntityFrameworkCore;
using RPlace.Models;
using RPlace.Services.Password;
using RPlace.Services.Users;

namespace RPlace.UseCases.User.CreateUser;

public class CreateUserUseCase(RPlaceDbContext ctx, IUsersService usersService, IPasswordService passwordService)
{
    public async Task<Result<CreateUserResponse>> Do(CreateUserPayload payload)
    {
        var usernamee = await ctx.Player.FirstOrDefaultAsync(p => p.Username == payload.Username); 

        if (usernamee is not null)
            return Result<CreateUserResponse>.Fail("Invalid Username! Try another name.");
        
        var email = await ctx.Player.FirstOrDefaultAsync(p => p.Email == payload.Email); 
        if (email is not null)
            return Result<CreateUserResponse>.Fail("Invalid E-mail! Try another E-mail.");

            var user = new Player
            {
                Bio = payload.Bio,
                Email = payload.Email,
                Username = payload.Username,
                Password = passwordService.Hash(payload.Password)
            };



        await usersService.Create(user);

        return Result<CreateUserResponse>.Success(new(user.Id));
    }
}

