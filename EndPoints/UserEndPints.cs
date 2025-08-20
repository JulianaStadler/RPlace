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
        // POST: /user
        app.MapPost("user/", async (
            [FromBody] CreateUserPayload payload, 
            [FromServices] CreateUserUseCase useCase
        ) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Created();
            
            return Results.BadRequest(result.Reason);
        });

        /* ------------------------- RETURN ACCOUNT -------------------------*/
        // GET: /user/{id}
        app.MapGet("user/{id}", async (
            Guid id,
            [FromServices] SeeUserUseCase useCase
        ) =>
        {
            var payload = new SeeUserPayload {id = id};
            var result = await useCase.Do(payload);

            if (result.IsSuccess)
                return Results.Ok(result.Data);
            
            return Results.BadRequest(result.Reason);
        });

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