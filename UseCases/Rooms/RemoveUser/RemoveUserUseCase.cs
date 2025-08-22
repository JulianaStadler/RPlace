using RPlace.Models;

namespace RPlace.UseCases.Rooms.RemoveUser;

public record RemoveUserUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<RemoveUserResponse>> Do(RemoveUserPayload payload)
    {
        return Result<RemoveUserResponse>.Success(null);
    }
}