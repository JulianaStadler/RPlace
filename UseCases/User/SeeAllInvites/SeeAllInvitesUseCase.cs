using RPlace.Models;

namespace RPlace.UseCases.User.SeeAllInvites;

public record SeeAllInvitesUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeeAllInvitesResponse>> Do(SeeAllInvitesPayload payload)
    {
        return Result<SeeAllInvitesResponse>.Success(null);
    }
}

