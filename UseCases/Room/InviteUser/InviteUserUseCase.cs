namespace RPlace.UseCases.Room.InviteUser;

public record InviteUserUseCase
{
    public async Task<Result<InviteUserResponse>> Do(InviteUserPayload payload)
    {
        return Result<InviteUserResponse>.Success(null);
    }
}