using RPlace.Models;
using RPlace.Services.Users;
using RPlace.Services.Password;
using RPlace.Services.JWT;

namespace RPlace.UseCases.User.Login;

public record LoginUseCase(IUsersService userService, IPasswordService passwordService, IJWTService jWTService)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await userService.FindByLogin(payload.Login);
        if (user is null)
            return Result<LoginResponse>.Fail("User not found");
        
        var passwordMatch = passwordService
            .Compare(payload.Password, user.Password);
        
        if (!passwordMatch)
            return Result<LoginResponse>.Fail("Incorrect password!");
        
        var jwt = jWTService.CreateToken(new(
            user.Id, user.Username
        ));

        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}

