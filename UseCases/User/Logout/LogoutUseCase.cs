using RPlace.Models;

namespace RPlace.UseCases.User.Logout;

public record LogoutUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<LogoutResponse>> Do(LogoutPayload payload)
    {
        return Result<LogoutResponse>.Success(null);
    }
}

