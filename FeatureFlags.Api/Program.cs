using FeatureFlags.Application.Services;
using FeatureFlags.Infrastructure.DBContext;
using FeatureFlags.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FeatureFlagDbContext>(opt => opt.UseSqlite("Data Source=featureflags.db"));
builder.Services.AddScoped<IFeatureFlagRepository, FeatureFlagRepository>();
builder.Services.AddScoped<FeatureFlagService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapPost("/features", async (FeatureFlagService service, string name, bool defaultState, string? description) =>
{
    await service.CreateAsync(name, defaultState, description);
    return Results.Ok();
});
app.MapGet("/features/{name}/evaluate", async (FeatureFlagService service, string name, string? userId, string? groupId, string? region) =>
{
    var result = await service.EvaluateAsync(name, userId, groupId, region); return Results.Ok(result);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
