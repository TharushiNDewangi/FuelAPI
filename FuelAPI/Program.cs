using FuelAPI.models;
using FuelAPI.services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<FuelDatabaseSettings>(builder.Configuration.GetSection("FuelDatabaseSettings"));
builder.Services.AddSingleton<FuelUserServices>();
builder.Services.AddSingleton<VehicleOwnerServices>();
var app = builder.Build();

app.MapGet("/", () => "HEY API!");


// Get all data
app.MapGet("/api/stationowners", async (FuelUserServices fueluserService) => await fueluserService.Get());
app.MapGet("/api/vehicleowners", async (VehicleOwnerServices vehicleOwnerService) => await vehicleOwnerService.Get());



/// Get by id
app.MapGet("/api/stationowner/{id}", async (FuelUserServices fueluserService, string id) =>
{
    var fueluser = await fueluserService.Get(id);
    return fueluser is null ? Results.NotFound() : Results.Ok(fueluser);
});
app.MapGet("/api/vehicleowner/{id}", async (VehicleOwnerServices vehicleOwnerService, string id) =>
{
    var fueluser = await vehicleOwnerService.Get(id);
    return fueluser is null ? Results.NotFound() : Results.Ok(fueluser);
});

app.MapGet("/api/bynerestloc/{nerestlocation}", async (FuelUserServices fueluserService, string nerestlocation) =>
{
    var fueluser = await fueluserService.Getbylocation(nerestlocation);
    return fueluser is null ? Results.NotFound() : Results.Ok(fueluser);
});

app.MapPost("/api/stationowners", async (FuelUserServices fueluserService, FuelUser fueluser) =>
{
    await fueluserService.Create(fueluser);
    return Results.Ok();
});

app.MapPost("/api/vehicleowners", async (VehicleOwnerServices vehicleOwnerService, VehicleOwner vehicleOwner) =>
{
    await vehicleOwnerService.Create(vehicleOwner);
    return Results.Ok();
});


app.MapPut("/api/upstationowner/{id}", async (FuelUserServices fueluserService, string id, FuelUser updatedfueluser) =>
{
    var fueluser = await fueluserService.Get(id);
    if (fueluser is null) return Results.NotFound();

    updatedfueluser.Id = fueluser.Id;
    await fueluserService.Update(id, updatedfueluser);

    return Results.NoContent();
});
app.MapPut("/api/upvehicleowner/{id}", async (VehicleOwnerServices vehicleOwnerService, string id, VehicleOwner updateduser) =>
{
    var vehicleOwner = await vehicleOwnerService.Get(id);
    if (vehicleOwner is null) return Results.NotFound();

    updateduser.Id = vehicleOwner.Id;
    await vehicleOwnerService.Update(id, updateduser);

    return Results.NoContent();
});


app.MapDelete("/api/fuelusers/{id}", async (FuelUserServices fueluserService, string id) =>
{
    var fueluser = await fueluserService.Get(id);
    if (fueluser is null) return Results.NotFound();

    await fueluserService.Remove(fueluser.Id);

    return Results.NoContent();
});





app.Run();
