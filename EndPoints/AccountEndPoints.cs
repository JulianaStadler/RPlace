using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RPlace.UseCases;
using RPlace.UseCases.SearchUser;
using RPlace.UseCases.User.CreateUser;

namespace RPlace.Endpoints;

public static class AccountEndpoints
{
    public static void ConfigureAccountEndpoints(this WebApplication app)
    {
        // POST: /user
        app.MapPost("profile", async (
            [FromBody]CreateUserPayload payload, 
            [FromServices]CreateUserUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Created();
            
            return Results.BadRequest(result.Reason);
        });


        // DELETE: /post/{id}
        app.MapDelete("post/{id}", async (
            string id,
            HttpContext http,
            [FromServices] object useCase // Substituir pelo tipo correto (ex: DeletePostUseCase)
        ) =>
        {
            // TODO: Implementar lógica para deletar post
            // Exemplo de acesso ao userId via Claims:
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim != null ? Guid.Parse(claim.Value) : Guid.Empty;

            return Results.Ok();
        }).RequireAuthorization();
    }
}