using RPlace.Models;

namespace RPlace.UseCases.User.SeePlans;

public record SeePlansUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<SeePlansResponse>> Do(SeePlansPayload payload)
    {
        return Result<SeePlansResponse>.Success(null);
    }
}

