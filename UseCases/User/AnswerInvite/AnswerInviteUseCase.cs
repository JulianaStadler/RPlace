using Microsoft.EntityFrameworkCore;
using RPlace.Models;

namespace RPlace.UseCases.User.AnswerInvite;

public record AnswerInviteUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<AnswerInviteResponse>> Do(AnswerInvitePayload payload)
    {
        var InviteId = payload.InviteId;
        var response = payload.Answer;
        var RoomId = payload.RoomId;

        var invite = await ctx.Invite.FindAsync(InviteId);
        ctx.Invite.Remove(invite);
        await ctx.SaveChangesAsync();

        if (!response)
            return Result<AnswerInviteResponse>.Success(new(Guid.Empty));

        var TypePermission = await ctx.Permissions.FirstOrDefaultAsync(p => p.Type == "Audience");
        var roomplayer = new RoomPlayer
        { 
            RoomId = payload.RoomId,
            PlayerId = payload.PlayerId,
            Permission = TypePermission
        };

        ctx.RoomPlayer.Add(roomplayer);
        await ctx.SaveChangesAsync();

        return Result<AnswerInviteResponse>.Success(new(RoomId));
    }
}

