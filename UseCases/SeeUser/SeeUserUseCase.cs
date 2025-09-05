using Azure;
using RPlace.Models;
using RPlace.Services.Users;

namespace RPlace.UseCases.SeeUser;


public class SeeUserUseCase(RPlaceDbContext ctx, IUsersService usersService)
{
    public async Task<Result<SeeUserResponse>> Do(SeeUserPayload payload)
    {
        var user = await usersService.FindById(payload.PlayerId);

        if (user is null)
            return Result<SeeUserResponse>.Fail("User Not Found!");

        var response = new SeeUserResponse(user.Username, user.LinkPicture, user.Bio, user.Plan.Type);

        return Result<SeeUserResponse>.Success(response);
    }
}