using RPlace.Models;
using RPlace.Services.Password;
using RPlace.Services.Users;

namespace RPlace.UseCases.User.EditAccount;

public record EditAccountUseCase(IUsersService usersService, IPasswordService passwordService)
{
    public async Task<Result<EditAccountResponse>> Do(EditAccountPayload payload)
    {
        await usersService.Alter(payload, usersService, passwordService);

        return Result<EditAccountResponse>.Success(null);
    }
}

