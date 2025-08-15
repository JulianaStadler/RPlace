using RPlace.Models;

namespace RPlace.UseCases.User.SeeCreatedRooms;

public record SeeCreatedRoomsUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeeCreatedRoomsResponse>> Do(SeeCreatedRoomsPayload payload)
    {
        return Result<SeeCreatedRoomsResponse>.Success(null);
    }
}

