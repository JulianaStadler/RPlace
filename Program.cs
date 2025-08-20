using System.Data;
using System.Text.RegularExpressions;
using RPlace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using RPlace.UseCases.Room.ChangePermission;
using RPlace.UseCases.Room.InviteUser;
using RPlace.UseCases.Room.PaintPixel;
using RPlace.UseCases.Room.RemoveUser;
using RPlace.UseCases.Room.SeePixels;
using RPlace.UseCases.Room.SeePlayers;
using RPlace.UseCases.SearchUser;
using RPlace.UseCases.SeeUsers;
using RPlace.UseCases.User.AnswerInvite;
using RPlace.UseCases.User.CreateRoom;
using RPlace.UseCases.User.CreateUser;
using RPlace.UseCases.User.DeleteAccount;
using RPlace.UseCases.User.EditAccount;
using RPlace.UseCases.User.Login;
using RPlace.UseCases.User.Logout;
using RPlace.UseCases.User.SeeCreatedRooms;
using RPlace.UseCases.User.SeeInvite;
using RPlace.UseCases.User.SeePlans;
using RPlace.UseCases.User.UpdatePlan;
using RPlace.Services.JWT;
using RPlace.Services.Password;
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

builder.Services.AddTransient<ChangePermissionUseCase>();
builder.Services.AddTransient<InviteUserUseCase>();
builder.Services.AddTransient<PaintPixelUseCase>();
builder.Services.AddTransient<RemoveUserUseCase>();
builder.Services.AddTransient<SeePixelsUseCase>();
builder.Services.AddTransient<SeePlayersUseCase>();
builder.Services.AddScoped<SearchUserUseCase>();
builder.Services.AddScoped<SeeUserUseCase>();
builder.Services.AddTransient<AnswerInviteUseCase>();
builder.Services.AddTransient<CreateRoomUseCase>();
builder.Services.AddTransient<CreateUserUseCase>();
builder.Services.AddTransient<DeleteAccountUseCase>();
builder.Services.AddTransient<EditAccountUseCase>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<LogoutUseCase>();
builder.Services.AddScoped<SeeCreatedRoomsUseCase>();
builder.Services.AddScoped<SeeInviteUseCase>();
builder.Services.AddScoped<SeePlansUseCase>();
builder.Services.AddTransient<UpdatePlanUseCase>();



builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.Run();