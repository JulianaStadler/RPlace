using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RPlace.UseCases.User.SeeInvite;

namespace RPlace.Endpoints;

public static class Estudando
{
    public static void ConfigureEstudando(this WebApplication app)
    {
        app.MapGet("user/invites/{id}", async(
           Guid id,
           [FromServices] SeeInviteUseCase useCase) =>
        {
            var payload = new SeeInvitePayload { Id = id };
            var response = await useCase.Do(payload);

            return (response.IsSuccess, response.Reason) switch
            {
                (false, "Invite not Found!") => Results.NotFound(response.Reason),
                (false, _) => Results.BadRequest(response.Reason),
                (true, _) => Results.Ok(response.Data)
            };
        }).RequireAuthorization();
    }
}