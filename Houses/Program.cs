using Houses.Core;
using Houses.Enums;
using Houses.Requests;
using Houses.Services;

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IHouseService, HouseService>();

var app = builder.Build();

app.MapPost("/house", ([FromServices] IHouseService service, [FromBody] CreateHouseRequest request) =>
{
    var style = Enum.Parse<Style>(request.Style);
    var response = service.Create(style, request.Bedrooms);

    return Results.Ok(response);
});

app.Run();
