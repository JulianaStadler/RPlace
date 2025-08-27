using RPlace.Models;

namespace RPlace.UseCases.User.AnswerInvite;

public record AnswerInviteUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<AnswerInviteResponse>> Do(AnswerInvitePayload payload)
    {
        // var InviteId = payload.InviteId;
        // var response = payload.Answer;
        // var RoomId = payload.RoomId;

        // var invite = await ctx.Invites.FindAsync(InviteId);
        // ctx.Invites.Remove(invite);
        // await ctx.SaveChangesAsync();

        // if (!response)
             return Result<AnswerInviteResponse>.Success(new(Guid.Empty));

        
       

        // return Result<AnswerInviteResponse>.Success(new(RoomId));
    }
}

