using FastEndpoints;
using FastEndpoints.Swagger;
using Order.Api.Repositories;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSwaggerDoc();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints(s => s.SerializerOptions = o =>
{
    o.PropertyNamingPolicy = null;
    o.PropertyNameCaseInsensitive = false;
});

app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());

app.Run();
