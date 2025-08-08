namespace RPlace.UseCases.Room.SeePixels;

public record SeePixelsUseCase
{
    public async Task<Result<SeePixelsResponse>> Do(SeePixelsPayload payload)
    {
        return Result<SeePixelsResponse>.Success(null);
    }
}