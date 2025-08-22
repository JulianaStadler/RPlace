using RPlace.Models;

namespace RPlace.UseCases.User.EditAccount;

public record EditAccountUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<EditAccountResponse>> Do(EditAccountPayload payload)
    {
        //var editi = 

        return Result<EditAccountResponse>.Success(null);
    }
}

