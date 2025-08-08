using System.Data;
using System.Text.RegularExpressions;
using RPlace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RPlaceDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var app = builder.Build();

app.Run();