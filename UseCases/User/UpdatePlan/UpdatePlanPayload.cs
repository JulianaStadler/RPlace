using System.ComponentModel.DataAnnotations;

namespace RPlace.UseCases.User.UpdatePlan;

public record UpdatePlanPayload
{
    [Required]
    public Guid PlayerId { get; init; }

    [Required]
    public Guid GiftCardId { get; init; }

    [Required]
    public string Password { get; init; }

}