using System.ComponentModel.DataAnnotations;
namespace RPlace.UseCases.User.Login;

public record LoginPayload
{
    [Required]
    public string Email { get; init; }

    [Required]
    public string Password { get; init; }
}