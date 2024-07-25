using Notification.Hubs;
using Notification.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

//app.UseCors();

app.MapHub<NotificationHub>("/notification");

app.Run();