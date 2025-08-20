using RPlace.Models;
namespace RPlace.UseCases.SeeUsers;

public record SeeUserResponse(string Username, string Linkpicture, string Bio, Plan plan);