using RPlace.Models;

namespace RPlace.UseCases.User.Login;

public record LoginUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        return Result<LoginResponse>.Success(null);
    }
}

