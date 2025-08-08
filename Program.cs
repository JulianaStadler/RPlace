using System.Data;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<FofoquinhaDbContext>(options => {
//     var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
//     options.UseSqlServer(sqlConn);
// });

var app = builder.Build();

app.Run();