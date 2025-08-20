using RPlace.Models;
using RPlace.Services.Password;
using RPlace.Services.Users;

namespace RPlace.UseCases.User.CreateUser;

public class CreateUserUseCase(
    IUsersService usersService,
    IPasswordService passwordService
)
{
    public async Task<Result<CreateUserResponse>> Do(CreateUserPayload payload)
    {
        var user = new Player
        {
            Bio = payload.Bio,
            Email = payload.Email,
            Username = payload.Username,
            Password = passwordService.Hash(payload.Password)
        };

        await usersService.Create(user);

        return Result<CreateUserResponse>.Success(new());
    }
}

