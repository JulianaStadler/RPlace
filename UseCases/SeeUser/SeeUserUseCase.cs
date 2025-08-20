using RPlace.Models;

namespace RPlace.UseCases.SeeUsers;

public class SeeUserUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeeUserResponse>> Do(SeeUserPayload payload)
    {
        return Result<SeeUserResponse>.Success(null);
    }
}