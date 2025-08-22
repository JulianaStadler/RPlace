using System.ComponentModel.DataAnnotations;
using RPlace.Models;
namespace RPlace.UseCases.SeeUser;

public record SeeUserPayload
{
    [Required]
    public Guid PlayerId { get; init; }
}