namespace RPlace.UseCases.Room.SeePlayers;

public record SeePlayersUseCase
{
    public async Task<Result<SeePlayersResponse>> Do(SeePlayersPayload payload)
    {
        return Result<SeePlayersResponse>.Success(null);
    }
}