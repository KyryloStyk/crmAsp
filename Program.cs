var builder = WebApplication.CreateBuilder(args);

// Регистрируем сервисы
builder.Services.AddControllers();
builder.Services.AddSingleton<ClientService>();

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();

// 👇 ВАЖНО — подключаем контроллеры
app.MapControllers();

app.Run();