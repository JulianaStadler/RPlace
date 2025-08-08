namespace RPlace.UseCases.Room.RemoveUser;

public record RemoveUserUseCase
{
    public async Task<Result<RemoveUserResponse>> Do(RemoveUserPayload payload)
    {
        return Result<RemoveUserResponse>.Success(null);
    }
}