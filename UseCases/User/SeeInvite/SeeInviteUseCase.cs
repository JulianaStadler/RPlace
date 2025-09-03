using RPlace.Models;

namespace RPlace.UseCases.User.SeeInvite;

public record SeeInviteUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeeInviteResponse>> Do(SeeInvitePayload payload)
    {
        var invite = ctx.Invite.FirstOrDefault(i => i.Id == payload.Id);
        
        if (invite is null)
            return Result<SeeInviteResponse>.Fail("Invite not Found!");

        var nameroom = invite.Room.Name;

        return Result<SeeInviteResponse>.Success(new(nameroom));
    }
}

