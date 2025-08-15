using RPlace.Models;

namespace RPlace.UseCases.User.UpdatePlan;

public record UpdatePlanUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<UpdatePlanResponse>> Do(UpdatePlanPayload payload)
    {
        return Result<UpdatePlanResponse>.Success(null);
    }
}

