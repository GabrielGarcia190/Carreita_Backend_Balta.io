using Microsoft.Data.SqlClient;
using Parte1.Extensions;
using Parte1.Repositories;
using Parte1.Repositories.Contracts;
using Parte1.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlConnection(connStr);
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

app.MapControllers();

app.Run();