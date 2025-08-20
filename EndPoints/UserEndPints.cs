using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RPlace.UseCases.User.CreateUser;
using RPlace.UseCases.User.DeleteAccount;
using RPlace.UseCases.User.EditAccount;
using RPlace.UseCases.SeeUser;
using RPlace.UseCases.User.CreateUser;

namespace RPlace.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        /* ------------------------- CREATE ACCOUNT -------------------------*/
        /* ------------------------- RETURN ACCOUNT -------------------------*/
        // GET: /user/{id}
        app.MapGet("user/{id}", (
            int id,
            [FromServices] SeeUserUseCase usecase
        ) =>
        {
            // TODO: Implementar lógica para obter post por ID
            return Results.Ok();
        });

        /* ------------------------- DELETE ACCOUNT -------------------------*/
        /* ------------------------- CHANGE ACCOUNT -------------------------*/
        /* ------------------------- CHANGE ACCOUNT PLAN -------------------------*/
        /* ------------------------- RETURN ACCOUNT INVITE -------------------------*/

        

        // POST: /user
        app.MapPost("user", async (
            [FromBody] object CreateUserPayload, // Substituir pelo tipo correto (ex: PublishPostPayload)
            [FromServices] object CreateUserUseCase // Substituir pelo tipo correto (ex: PublishPostUseCase)
        ) =>
        {
            // TODO: Implementar lógica para publicar post
            // Exemplo de retorno padrão:
            return Results.Ok();
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