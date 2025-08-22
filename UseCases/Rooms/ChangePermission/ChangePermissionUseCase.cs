using RPlace.Models;

namespace RPlace.UseCases.Rooms.ChangePermission;

public record ChangePermissionUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<ChangePermissionResponse>> Do(ChangePermissionPayload payload)
    {
        return Result<ChangePermissionResponse>.Success(null);
    }
}
