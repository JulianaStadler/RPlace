using RPlace.Models;

namespace RPlace.UseCases.User.SeePlans;

public record SeePlansResponse(
    IEnumerable<PlansData> Plans
);

public record PlansData
{
    public required Guid Id { get; set; }
    public required string Type { get; set; }
    public required int LimitRoomCreate { get; set; }
    public required int PaintTime { get; set; }
}
