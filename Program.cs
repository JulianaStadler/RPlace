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





var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RPlaceDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var app = builder.Build();

app.Run();