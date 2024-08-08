using Crayon.CloudSales.Api.ExceptionHandler;
using Crayon.CloudSales.Core.Extensions;
using Crayon.CloudSales.Infrastructure.Database;
using Crayon.CloudSales.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<CrayonCloudSalesExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCrayonCloudSalesCore();
builder.Services.AddCrayonCloudSalesInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<CrayonCloudSalesDbContext>();
        CrayonCloudSalsesDbInitializer.Initialize(context);
    }
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
