using UserApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Bind settings
builder.Services.Configure<UserDatabaseSettings>(
    builder.Configuration.GetSection("UserDatabaseSettings"));

// Inject as singleton
builder.Services.AddSingleton<UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
