using FuelAPI.models;
using FuelAPI.services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<FuelDatabaseSettings>(builder.Configuration.GetSection("FuelDatabaseSettings"));
builder.Services.AddSingleton<FuelUserServices>();
builder.Services.AddSingleton<VehicleOwnerServices>();
var app = builder.Build();

app.MapGet("/", () => "Movies API!");

/// <summary>
/// Get all movies
/// </summary>
app.MapGet("/api/fuelusers", async (FuelUserServices fueluserService) => await fueluserService.Get());
app.MapGet("/api/vehicleowners", async (VehicleOwnerServices vehicleOwnerService) => await vehicleOwnerService.Get());

/// <summary>
/// Get a movie by id
/// </summary>
app.MapGet("/api/fuelusers/{id}", async (FuelUserServices fueluserService, string id) =>
{
    var fueluser = await fueluserService.Get(id);
    return fueluser is null ? Results.NotFound() : Results.Ok(fueluser);
});

/// <summary>
/// Create a new movie
/// </summary>
app.MapPost("/api/fuelusers", async (FuelUserServices fueluserService, FuelUser fueluser) =>
{
    await fueluserService.Create(fueluser);
    return Results.Ok();
});

app.MapPost("/api/vehicleowner", async (VehicleOwnerServices vehicleOwnerService, VehicleOwner vehicleOwner) =>
{
    await vehicleOwnerService.Create(vehicleOwner);
    return Results.Ok();
});

/// <summary>
/// Update a movie
/// </summary>
app.MapPut("/api/fuelusers/{id}", async (FuelUserServices fueluserService, string id, FuelUser updatedfueluser) =>
{
    var fueluser = await fueluserService.Get(id);
    if (fueluser is null) return Results.NotFound();

    updatedfueluser.Id = fueluser.Id;
    await fueluserService.Update(id, updatedfueluser);

    return Results.NoContent();
});

/// <summary>
/// Delete a movie
/// </summary>
app.MapDelete("/api/fuelusers/{id}", async (FuelUserServices fueluserService, string id) =>
{
    var fueluser = await fueluserService.Get(id);
    if (fueluser is null) return Results.NotFound();

    await fueluserService.Remove(fueluser.Id);

    return Results.NoContent();
});





app.Run();
