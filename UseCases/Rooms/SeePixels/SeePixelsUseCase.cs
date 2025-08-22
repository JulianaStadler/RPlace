using RPlace.Models;

namespace RPlace.UseCases.Rooms.SeePixels;

public record SeePixelsUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeePixelsResponse>> Do(SeePixelsPayload payload)
    {
        return Result<SeePixelsResponse>.Success(null);
    }
}