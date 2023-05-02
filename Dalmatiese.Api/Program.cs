using Dalmatiese.Api.Middleware;
using Dalmatiese.Application;
using Dalmatiese.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
