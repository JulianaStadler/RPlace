using RPlace.Models;

namespace RPlace.UseCases.User.SeeInvite;

public record SeeInviteUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeeInviteResponse>> Do(SeeInvitePayload payload)
    {
        return Result<SeeInviteResponse>.Success(null);
    }
}

