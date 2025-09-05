using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RPlace.UseCases.Rooms.ChangePermission;
using RPlace.UseCases.Rooms.InviteUser;
using RPlace.UseCases.Rooms.PaintPixel;
using RPlace.UseCases.Rooms.RemoveUser;
using RPlace.UseCases.Rooms.SeePixels;
using RPlace.UseCases.Rooms.SeePlayers;
using RPlace.Services.Rooms;
using RPlace.Services.Users;

namespace RPlace.Endpoints;

public static class RoomEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        /* ----------------- VER SALA COM TODOS OS PIXELS  ----------------------*/
        // GET: /room/{id}
        app.MapGet("/room/{id}", async (
            Guid id,
            HttpContext http,
            [FromServices] SeePixelsUseCase useCase
        ) => 
        {
            var payload = new SeePixelsPayload { RoomId = id };
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "No rooms") => Results.NotFound(result.Reason),
                (false, "No avaliable picture") => Results.NotFound(result.Reason),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };

        }).RequireAuthorization();

        /* ----------------------- VER OS PLAYERS DA SALA ---------------------------*/
        // GET: /room/{id}/players/
        app.MapGet("/room/{id}/players", async (
            Guid id,
            HttpContext http,
            [FromServices] SeePlayersUseCase useCase
        ) => 
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            var payload = new SeePlayersPayload { RoomId = id, PlayerId = userId };
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Room not found") => Results.NotFound(result.Reason),
                (false, "You are not in this room!") => Results.Unauthorized(),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };

        }).RequireAuthorization();

        /* --------------------- PINTAR PIXEL DA SALA ---------------------------*/
        // PUT: /room/{id}/pixel
        app.MapPut("/room/{id}/pixel", async (
            Guid Id,
            HttpContext http,
            [FromBody] PaintPixelPayload payload,
            [FromServices] PaintPixelUseCase useCase,
            [FromServices] IRoomService roomService
        ) => 
        {
            var roomIdService = await roomService.FindById(Id);
            if (roomIdService == null) 
                return Results.NotFound("Room not found");
            var roomId = roomIdService.Id;

            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            /*VALIDAR SE USER EXISTE NA SALA*/

            payload = payload with { RoomId = roomId };
            var result = await useCase.Do(payload);


            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };
        }).RequireAuthorization();

        /* ----------------------- CRIA UM CONVITE ------------------------------*/
        // POST: /room/{id}/invite/player/{id}
        app.MapPost("/room/{id}/invite/player/{playerid}", async (
            Guid Id,
            Guid PlayerId,
            HttpContext http,
            [FromBody] InviteUserPayload payload,
            [FromServices] InviteUserUseCase useCase,
            [FromServices] IRoomService roomService
        ) => 
        {
            var roomIdService = await roomService.FindById(Id);
            if (roomIdService == null) 
                return Results.NotFound("Room not found");

            var roomId = roomIdService.Id;

            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            /*VALIDAR SE USER EXISTE NA SALA*/
            
            payload = payload with {
                RoomId = roomId,
                RequestUserId = Id
            };
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok()
            };
        }).RequireAuthorization();


        /* ---------- ALTERA AS PERMISSOES DE UM PLAYER NA SALA -----------------*/
        // PUT: /room/{id}/player/{playerid}
        app.MapPut("/room/{id}/player/{playerid}", async (
            Guid Id,
            Guid PlayerId,
            HttpContext http,
            [FromBody] ChangePermissionPayload payload,
            [FromServices] ChangePermissionUseCase useCase,
            [FromServices] IRoomService roomService
        ) => 
        {
            var roomIdService = await roomService.FindById(Id);
            if (roomIdService == null) 
                return Results.NotFound("Room not found");

            var roomId = roomIdService.Id;

            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            payload = payload with {
                UserId = userId,
                RoomId = roomId
            };
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok()
            };
        }).RequireAuthorization();

        /* --------------------- RETIRA UM USER DA SALA -------------------------*/
        // DELETE: /room/{id}/player/{playerid}
        app.MapDelete("/room/{id}/player/{playerid}", async (
            Guid RoomId,
            Guid DeletePlayerId,
            HttpContext http,
            [FromServices] RemoveUserUseCase useCase,
            [FromServices] IRoomService roomService,
            [FromServices] IUsersService userService
        ) => 
        {
            var roomIdService = await roomService.FindById(RoomId);
            if (roomIdService == null) 
                return Results.NotFound("Room not found");
            var roomId = roomIdService.Id;

            var userIdService = await userService.FindById(DeletePlayerId);
            if (userIdService == null) 
                return Results.NotFound("User not found");
            var userId = userIdService.Id;

            var payload = new RemoveUserPayload {
                UserId = userId,
                RoomId = roomId
            };
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok()
            };
        }).RequireAuthorization();


    }
}

