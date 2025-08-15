using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Fofoquinha.Endpoints;

public static class PostEndpoints
{
    public static void ConfigurePostEndpoints(this WebApplication app)
    {
        // GET: /post/{id}
        app.MapGet("post/{id}", (string id) =>
        {
            // TODO: Implementar lógica para obter post por ID
            return Results.Ok();
        });

        // POST: /post
        app.MapPost("post", async (
            [FromBody] object payload, // Substituir pelo tipo correto (ex: PublishPostPayload)
            [FromServices] object useCase // Substituir pelo tipo correto (ex: PublishPostUseCase)
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