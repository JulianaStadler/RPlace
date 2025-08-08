using RPlace.Models;

namespace RPlace.UseCases.SearchUser;

public class SearchUserUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SearchUserResponse>> Do(SearchUserPayload payload)
    {
        return Result<SearchUserResponse>.Success(null);
    }
}