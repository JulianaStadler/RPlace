using System.Drawing;

namespace RPlace.Models;

public class Pixel
{
    public Guid Id {get; set;}
    public int X {get; set;}
    public int Y {get; set;}
    public string Color {get; set;}
    public Guid RoomId {get; set;}
    public Room Room {get; set;}
}