namespace RPlace.UseCases.Room.PaintPixel;
using System.ComponentModel.DataAnnotations;


public record PaintPixelPayload
{
    [Required]
    [Range(0, int.MaxValue)]
    public int X {get; init;}
    
    [Required]
    [Range(0, int.MaxValue)]
    public int Y {get; init;}
    

    [Required]
    [Range(0, 255)]
    public int R {get; init;}

    [Required]
    [Range(0, 255)]
    public int G {get; init;}

    [Required]
    [Range(0, 255)]
    public int B {get; init;}

}