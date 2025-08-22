using System.ComponentModel.DataAnnotations;
namespace RPlace.UseCases.User.EditAccount;

public record EditAccountPayload
{
    [MinLength(5)]
    [MaxLength(20)]
    public string Username { get; init; }

    [EmailAddress]
    public string Email { get; init; }

    [MinLength(5)]
    //[NeedNumber]
    public string Password { get; init; }
 
    [Compare("Password")]
    public string RepeatPassword { get; init; }

    [Url]
    public string LinkPicture { get; set; }

    [MaxLength(200)]
    public string Bio { get; init; }
}