namespace RPlace.Models;

public class GiftCard
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public bool WasUsed { get; set; }
    public Guid PlanId { get; set; }
    public Plan Plan { get; set; }
    public DateTime ExpirationTime {get; set;}
}