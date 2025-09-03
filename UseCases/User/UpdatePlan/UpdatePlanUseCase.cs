using Microsoft.EntityFrameworkCore;
using RPlace.Models;
using RPlace.Services.Password;
using RPlace.Services.Users;

namespace RPlace.UseCases.User.UpdatePlan;

public record UpdatePlanUseCase(RPlaceDbContext ctx, IUsersService usersService, IPasswordService passwordService)
{
    public async Task<Result<UpdatePlanResponse>> Do(UpdatePlanPayload payload)
    {
        var user = await ctx.Player.FirstOrDefaultAsync(p => p.Id == payload.PlayerId);

        if (user is null)
            return Result<UpdatePlanResponse>.Fail("User does not exist!");

        if (user.Password != passwordService.Hash(payload.Password))
            return Result<UpdatePlanResponse>.Fail("Incorrect Password!");

        var giftcard = await ctx.GiftCard.FindAsync(payload.GiftCardId);

        if (giftcard is null)
            return Result<UpdatePlanResponse>.Fail("GiftCard does not exist!");

        if (giftcard.ExpirationTime < DateTime.Today)
            return Result<UpdatePlanResponse>.Fail("Expired GiftCard!");

        user.Plan = giftcard.Plan;

        await ctx.SaveChangesAsync();        

        return Result<UpdatePlanResponse>.Success(new(user.Plan));
    }
}

