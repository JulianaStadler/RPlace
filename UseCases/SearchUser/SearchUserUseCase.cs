namespace RPlace.UseCases.SearchUser;

public class SearchUserUseCase
{
    public async Task<Result<SearchUserResponse>> Do(SearchUserPayload payload)
    {
        return Result<SearchUserResponse>.Success(null)
    }
}