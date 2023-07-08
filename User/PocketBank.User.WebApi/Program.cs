using PocketBank.User.WebApi.Common.DependencyInjection;
using PocketBank.User.WebApi.DependencyInjection;
using PocketBank.User.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Logging.AddLogging(builder.Configuration);
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusiness();
builder.Services.AddWebApi(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
