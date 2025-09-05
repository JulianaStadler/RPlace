using RPlace.Models;
namespace RPlace.UseCases.SeeUser;

public record SeeUserResponse(
    string Username,
    string Linkpicture,
    string Bio,
    string planname
);