using RPlace.Models;

namespace RPlace.UseCases.User.AnswerInvite;

public record AnswerInviteUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<AnswerInviteResponse>> Do(AnswerInvitePayload payload)
    {
        return Result<AnswerInviteResponse>.Success(null);
    }
}

