using MyChat.Handlers;
using MyChat.Handlers.Implementations;
using MyChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IChatEventHandler, ChatEventHandler>();
builder.Services.AddHostedService<ChatHistoryConsumer>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapHub<ChatHub>("/hubs/chat");
});

app.Run();
