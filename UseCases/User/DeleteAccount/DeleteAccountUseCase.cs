using RPlace.Models;

namespace RPlace.UseCases.User.DeleteAccount;

public record DeleteAccountUseCase(RPlaceDbContext ctx)
{
    public async Task<Result<DeleteAccountResponse>> Do(DeleteAccountPayload payload)
    {
        return Result<DeleteAccountResponse>.Success(null);
    }
}

