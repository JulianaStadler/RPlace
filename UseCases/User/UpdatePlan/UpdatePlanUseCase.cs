using Microsoft.EntityFrameworkCore;
using RPlace.Models;

namespace RPlace.UseCases.User.UpdatePlan;

public record UpdatePlanUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<UpdatePlanResponse>> Do(UpdatePlanPayload payload)
    {
        var user = await ctx.Player.FirstOrDefaultAsync(p => p.Id == payload.PlayerId);
        return Result<UpdatePlanResponse>.Success(null);
    }
}

