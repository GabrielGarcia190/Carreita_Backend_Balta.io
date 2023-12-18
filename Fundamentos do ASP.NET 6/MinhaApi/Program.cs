var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Ok("Hello Word");
});

app.MapGet("/banana/{nome}", (string nome) =>
{
    return Results.Ok($"Hello {nome}");
});

app.MapPost("/", () =>
{

});


app.Run();
