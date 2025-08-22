using RPlace.Models;

namespace RPlace.UseCases.User.AnswerInvite;

public record AnswerInviteUseCase()
{
    public async Task<Result<AnswerInviteResponse>> Do(AnswerInvitePayload payload)
    {
        return Result<AnswerInviteResponse>.Success(null);
    }
}

