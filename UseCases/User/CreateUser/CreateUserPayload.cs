using System.ComponentModel.DataAnnotations;
using RPlace.Models;

namespace RPlace.UseCases.User.CreateUser;

public record CreateUserPayload
{
    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string Username { get; init; }

    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    [MinLength(5)]
    //[NeedNumber]
    public string Password { get; init; }

    [Required]
    [Compare("Password")]
    public string RepeatPassword { get; init; }

    [Url]
    public string LinkPicture { get; set; }

    [MaxLength(200)]
    public string Bio { get; init; }

}
