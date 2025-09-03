namespace RPlace.UseCases.Rooms.SeePixels;

public record SeePixelsResponse(
    IEnumerable<PicturePixels?> Picture
);

public record PicturePixels
{
    public required Guid PixelId { get; set; }
    public required int X {get; init;}
    public required int Y {get; init;}
    public required int R {get; init;}
    public required int G {get; init;}
    public required int B {get; init;}
}