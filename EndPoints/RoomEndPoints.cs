using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RPlace.UseCases.Rooms.ChangePermission;
using RPlace.UseCases.Rooms.InviteUser;
using RPlace.UseCases.Rooms.PaintPixel;
using RPlace.UseCases.Rooms.RemoveUser;
using RPlace.UseCases.Rooms.SeePixels;
using RPlace.UseCases.Rooms.SeePlayers;

namespace RPlace.Endpoints;

public static class RoomEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        /* ----------------- VER SALA COM TODOS OS PIXELS  ----------------------*/
        // GET: /room/{id}
        app.MapGet("/room/{id}", async (
            Guid id,
            [FromServices] SeePixelsUseCase useCase
        ) => 
        {
            var payload = new SeePixelsPayload { RoomId = id };
            var result = await useCase.Do(payload);

            if (result.IsSuccess)
                return Results.Ok(result.Data);
            
            return Results.BadRequest(result.Reason);
        });

        /* ----------------------- VER OS PLAYERS DA SALA ---------------------------*/
        // GET: /room/{id}/players/
        app.MapGet("/room/{id}/players", async (
            Guid id,
            [FromServices] SeePlayersUseCase useCase
        ) =>
        {

            var payload = new SeePlayersPayload();
            var result = await useCase.Do(payload);

            if (result.IsSuccess)
                return Results.Ok(result.Data);
            
            return Results.BadRequest(result.Reason);
        });

        /* --------------------- PINTAR PIXEL DA SALA ---------------------------*/
        // PUT: /room/{id}/pixel
        app.MapPut("/room/{id}/pixel", async (
            Guid Id,
            HttpContext http,
            [FromBody] PaintPixelPayload payload,
            [FromServices] PaintPixelUseCase useCase  
        ) => {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

        }).RequireAuthorization();

        /* ------------------------ CRIA UMA SALA -------------------------------*/
        // POST: /room
        app.MapPost("/room", async (
            Guid Id,
            Guid PlayerId,
            HttpContext http,
            [FromBody] InviteUserPayload payload,
            [FromServices] InviteUserUseCase useCase  
        ) => {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

        }).RequireAuthorization();


        /* ----------------------- CRIA UM CONVITE ------------------------------*/
        // POST: /room/{id}/invite/player/{id}
        app.MapPost("/room/{id}/invite/player/{playerid}", async (
            Guid Id,
            Guid PlayerId,
            HttpContext http,
            [FromBody] InviteUserPayload payload,
            [FromServices] InviteUserUseCase useCase  
        ) => {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

        }).RequireAuthorization();


        /* ---------- ALTERA AS PERMISSOES DE UM PLAYER NA SALA -----------------*/
        // PUT: /room/{id}/player/{playerid}
        app.MapPut("/room/{id}/player/{playerid}", async (
            Guid Id,
            Guid PlayerId,
            HttpContext http,
            [FromBody] ChangePermissionPayload payload,
            [FromServices] ChangePermissionUseCase useCase  
        ) => {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

        }).RequireAuthorization();

        /* --------------------- RETIRA UM USER DA SALA -------------------------*/
        // DELETE: /room/{id}/player/{playerid}
        app.MapDelete("/room/{id}/player/{playerid}", async (
            Guid Id,
            Guid PlayerId,
            HttpContext http,
            [FromBody] ChangePermissionPayload payload,
            [FromServices] ChangePermissionUseCase useCase  
        ) => {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

        }).RequireAuthorization();


    }
}

