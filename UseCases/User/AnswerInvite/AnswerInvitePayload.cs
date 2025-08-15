namespace RPlace.UseCases.User.AnswerInvite;
using System.ComponentModel.DataAnnotations;

public record AnswerInvitePayload
{

    [Required]
    public Guid InviteId { get; init; }

    [Required]
    public Guid PlayerId { get; set; }

    [Required]
    public Guid RoomId { get; set; }
    
    [Required]
    public bool Answer { get; set; }
}