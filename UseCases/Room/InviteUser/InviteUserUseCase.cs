using RPlace.Models;

namespace RPlace.UseCases.Room.InviteUser;

public record InviteUserUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<InviteUserResponse>> Do(InviteUserPayload payload)
    {
        return Result<InviteUserResponse>.Success(null);
    }
}