var builder = WebApplication.CreateBuilder(args);
ILoggerFactory loggerFactory;

builder.Services.AddDbContext<ClienteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<ClienteValidador>();
builder.Services.AddScoped<ClienteServico>();


builder.Services.AddControllers();

builder.Services.AdicionarTratamentoDeExcecaoGlobalMiddleware();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseTratamentoDeExcecaoGlobalMiddleware();
app.UseDetalhesDoProblemaExcecao(loggerFactory);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();