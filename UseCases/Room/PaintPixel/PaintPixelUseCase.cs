namespace RPlace.UseCases.Room.PaintPixel;

public record PaintPixelUseCase
{
    public async Task<Result<PaintPixelResponse>> Do(PaintPixelPayload payload)
    {
        return Result<PaintPixelResponse>.Success(null);
    }
}