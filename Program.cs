using System.Data;
using System.Text.RegularExpressions;
using RPlace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using RPlace.UseCases.Rooms.ChangePermission;
using RPlace.UseCases.Rooms.InviteUser;
using RPlace.UseCases.Rooms.PaintPixel;
using RPlace.UseCases.Rooms.RemoveUser;
using RPlace.UseCases.Rooms.SeePixels;
using RPlace.UseCases.Rooms.SeePlayers;
using RPlace.UseCases.SeeUser;
using RPlace.UseCases.User.AnswerInvite;
using RPlace.UseCases.User.CreateRoom;
using RPlace.UseCases.User.CreateUser;
using RPlace.UseCases.User.EditAccount;
using RPlace.UseCases.User.Login;
using RPlace.UseCases.User.SeeInvite;
using RPlace.UseCases.User.SeeAllInvites;
using RPlace.UseCases.User.SeePlans;
using RPlace.UseCases.User.UpdatePlan;
using RPlace.UseCases.User.SeeMyRooms;
using RPlace.Services.JWT;
using RPlace.Services.Password;
using RPlace.Services.Rooms;
using RPlace.Services.Users;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RPlaceDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});


var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "RPlace",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddTransient<IPasswordService, PBKDF2PasswordService>();
builder.Services.AddSingleton<IJWTService, JWTService>();
// builder.Services.AddTransient<IProfilesService, EFProfileService>();
builder.Services.AddTransient<IRoomService, EFRoomService>();
builder.Services.AddTransient<IUsersService, EFUserService>();


builder.Services.AddTransient<ChangePermissionUseCase>();
builder.Services.AddTransient<InviteUserUseCase>();
builder.Services.AddTransient<PaintPixelUseCase>();
builder.Services.AddTransient<RemoveUserUseCase>();
builder.Services.AddTransient<SeePixelsUseCase>();
builder.Services.AddTransient<SeePlayersUseCase>();
builder.Services.AddTransient<AnswerInviteUseCase>();
builder.Services.AddTransient<CreateRoomUseCase>();
builder.Services.AddTransient<CreateUserUseCase>();
builder.Services.AddTransient<EditAccountUseCase>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<SeeInviteUseCase>();
builder.Services.AddTransient<SeeAllInvitesUseCase>();
builder.Services.AddTransient<SeePlansUseCase>();
builder.Services.AddTransient<UpdatePlanUseCase>();
builder.Services.AddTransient<SeeMyRoomsUseCase>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();