using RPlace.Models;

namespace RPlace.UseCases.Room.PaintPixel;

public record PaintPixelUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<PaintPixelResponse>> Do(PaintPixelPayload payload)
    {
        return Result<PaintPixelResponse>.Success(null);
    }
}