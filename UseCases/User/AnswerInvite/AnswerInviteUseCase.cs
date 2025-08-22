using RPlace.Models;

namespace RPlace.UseCases.User.AnswerInvite;

public record AnswerInviteUseCase()
{
    public async Task<Result<AnswerInviteResponse>> Do(AnswerInvitePayload payload)
    {
        return Result<AnswerInviteResponse>.Success(null);
    }
}

// public class SeeUserUseCase
// {
//     private readonly IUserRepository _repo;

//     public SeeUserUseCase(IUserRepository repo)
//     {
//         _repo = repo;
//     }

//     public async Task<Result<UserDto>> Do(SeeUserPayload payload)
//     {
//         var user = await _repo.FindByIdAsync(payload.Id);

//         if (user == null)
//             return Result<UserDto>.Fail("User not found");

//         return Result<UserDto>.Success(new UserDto(user.Id, user.Username));
//     }
// }