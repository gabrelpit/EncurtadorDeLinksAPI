using LinkShortenerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários para os controladores
builder.Services.AddControllers();

// Adiciona o serviço LinkShortenerService
builder.Services.AddSingleton<LinkShortenerService>();

var app = builder.Build();

// Configura o pipeline de requisição HTTP
app.UseHttpsRedirection();

// Mapeia os controladores da aplicação
app.MapControllers();

app.Run();
