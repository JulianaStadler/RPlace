using System.ComponentModel.DataAnnotations;

namespace RPlace.UseCases.SearchUser;

public record SearchUserPayload
{
    [Required]
    [MinLength(2)]
    [MaxLength(200)]
    public string UserName { get; init; }
    
}

