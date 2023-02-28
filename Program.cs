using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/todoResponse", () => new Todo { Id = 1, Title = "Cook lunch", IsCompleted = true });
app.MapGet("/todoIResult", () => TypedResults.Created("/", new Todo { Id = 1, Title = "Cook lunch", IsCompleted = true }));

app.MapGet("/fromQueryExplicit", ([FromQuery] string p) => p);
app.MapGet("/fromHeaderExplicit", ([FromHeader] string h) => h);
app.MapGet("/fromRouteExplicit/{r}", ([FromRoute] string r) => r);
app.MapGet("/fromRouteImplicit/{r}", (string r) => r);

app.MapPost("/fromBodyExplicit", ([FromBody] Todo todo) => "Received a JSON body.");
app.MapGet("/fromServiceExplicit", ([FromServices] Todo todo) => "Received element from DI.");

app.Run();

class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}