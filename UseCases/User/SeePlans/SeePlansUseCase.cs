using Microsoft.EntityFrameworkCore;
using RPlace.Models;

namespace RPlace.UseCases.User.SeePlans;

public record SeePlansUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeePlansResponse>> Do(SeePlansPayload payload)
    {
        var plans = ctx.Plan.Select(p => new PlansData{
            Id = p.Id,
            Type = p.Type,
            LimitRoomCreate = p.LimitRoomCreate,
            PaintTime = p.PaintTime
        });

        if (plans is null)
            return Result<SeePlansResponse>.Fail("No avaliable plans");

        return Result<SeePlansResponse>.Success(new(plans));
    }
}

