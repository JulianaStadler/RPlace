using RPlace.Models;

namespace RPlace.UseCases.User.CreateUser;

public record CreateUserUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<CreateUserResponse>> Do(CreateUserPayload payload)
    {
        return Result<CreateUserResponse>.Success(null);
    }
}

