using RPlace.Models;

namespace RPlace.UseCases.User.SeeMyRooms;

public record SeeMyRoomsUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeeMyRoomsResponse>> Do(SeeMyRoomsPayload payload)
    {
        return Result<SeeMyRoomsResponse>.Success(null);
    }
}

