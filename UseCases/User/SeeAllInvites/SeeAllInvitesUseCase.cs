using RPlace.Models;

namespace RPlace.UseCases.User.SeeAllInvites;

public record SeeAllInvitesUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeeAllInvitesResponse>> Do(SeeAllInvitesPayload payload)
    {
        var invites = ctx.Invite.Where(i => i.PlayerId == payload.PlayerId);

        if (invites is null)
            return Result<SeeAllInvitesResponse>.Fail("No one loves you!!!");

        return Result<SeeAllInvitesResponse>.Success(new(invites));
    }
}

