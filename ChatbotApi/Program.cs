using ChatbotApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ChatService>();

var app = builder.Build();

app.MapControllers();

app.Run();
