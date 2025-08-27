using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RPlace.UseCases.User.CreateUser;
using RPlace.UseCases.User.EditAccount;
using RPlace.UseCases.User.SeePlans;
using RPlace.UseCases.User.UpdatePlan;
using RPlace.UseCases.User.SeeInvite;
using RPlace.UseCases.User.AnswerInvite;
using RPlace.UseCases.User.CreateRoom;
using RPlace.UseCases.User.SeeCreatedRooms;
using RPlace.UseCases.SeeUser;

namespace RPlace.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        /* ----------------------- CREATE ACCOUNT -------------------------*/
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

        /* ------------------------ RETURN ACCOUNT -------------------------*/
        // GET: /user/{id}
        app.MapGet("user/{id}", async (
            Guid id,
            [FromServices] SeeUserUseCase useCase
        ) =>
        {
            var payload = new SeeUserPayload {PlayerId = id};
            var result = await useCase.Do(payload);

            if (result.IsSuccess)
                return Results.Ok(result.Data);
            
            return Results.BadRequest(result.Reason);
        });

        /* ------------------------ EDIT ACCOUNT -------------------------*/
        app.MapPut("user/{id}", async(
            Guid id,
            HttpContext http,
            [FromBody] EditAccountPayload payload,
            [FromServices] EditAccountUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            payload = payload with {PlayerId = userId};
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok()
            };

        }).RequireAuthorization();

        /* -------------------------- SEE PLANS -------------------------*/
        app.MapPut("user/{id}/plan", async(
            Guid id,
            HttpContext http,
            [FromServices] SeePlansUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            var payload = new SeePlansPayload();
            var result = await useCase.Do(payload);

            if (result.IsSuccess)
                return Results.Ok(result.Data);
            
            return Results.BadRequest(result.Reason);
        }).RequireAuthorization();

        /* --------------------- CHANGE ACCOUNT PLAN -------------------------*/
        // PUT: /user/{id}/plan/{code}
        app.MapPut("user/{id}/plan/{code}", async(
            Guid id,
            Guid code,
            HttpContext http,
            [FromBody] UpdatePlanPayload payload,
            [FromServices] UpdatePlanUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            payload = payload with {PlayerId = userId, GiftCardId = code};
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok()
            };

        }).RequireAuthorization();

        /* ------------------------- SEE INVITES -------------------------*/
        //GET: user/{id}/invite/
        app.MapGet("user/{id}/invite/", async (
            Guid id,
            HttpContext http,
            [FromServices] SeeInviteUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            var payload = new SeeInvitePayload();
            var result = await useCase.Do(payload);

            if (result.IsSuccess)
                return Results.Ok(result.Data);
            
            return Results.BadRequest(result.Reason);
        }).RequireAuthorization();

        /* --------------------- RETURN ACCOUNT INVITE -------------------------*/
        // POST: /user/{id}/invite/{idInvite}
        app.MapPost("user/{id}/invite/{idInvite}", async (
            Guid id,
            Guid idInvite,
            HttpContext http,
            [FromServices] AnswerInviteUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            var payload = new AnswerInvitePayload {InviteId = idInvite, PlayerId = userId};
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok()
            };

        }).RequireAuthorization();

        /* ------------------------- CREATE ROOM -------------------------*/
        //POST: user/{id}/room/
        app.MapPost("user/{id}/room/", async (
            Guid id,
            HttpContext http,
            [FromBody] CreateRoomPayload payload,
            [FromServices] CreateRoomUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            var result = await useCase.Do(payload);
        
            return Results.Created($"/room/{result.Data.RoomId}", result);
        }).RequireAuthorization();

        /* ---------------------- SEE CREATED ROOMs -------------------------*/
        //GET: user/{id}/Room/
        app.MapGet("user/{id}/room/", async (
            Guid id,
            HttpContext http,
            [FromServices] SeeCreatedRoomsUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            var payload = new SeeCreatedRoomsPayload();
            var result = await useCase.Do(payload);

            if (result.IsSuccess)
                return Results.Ok(result.Data);
            
            return Results.BadRequest(result.Reason);
        }).RequireAuthorization();
        

    }
}