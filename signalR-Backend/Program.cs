using signalR_Backend.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("https://localhost:57493") // Vue dev server //http://localhost:5173
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

var app = builder.Build();
app.UseCors("AllowFrontend");
app.MapHub<ChatHub>("/Hub/notifications");
app.Run();