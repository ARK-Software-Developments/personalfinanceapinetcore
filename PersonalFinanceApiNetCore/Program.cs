using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PersonalFinance API",
        Version = "v1",
        Summary = "API para la gestión de finanzas personales",
        Contact = new OpenApiContact
        {
            Name = "Andrés Kamycki",
            Email = "andres.kamycki@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/andres-kamycki/"),
        },
        Description = "Esta API permite gestionar finanzas personales, incluyendo ingresos, gastos y presupuestos.",
    });

    // Incluir comentarios XML si existen
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }

    // Soporte para Bearer JWT(si usas autenticación)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Escriba 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });
});

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "CorsPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost", "http://localhost:3000", "https://localhost", "https://localhost:3000", "https://localhost:5000")
                   .WithMethods("GET", "POST", "PUT")
                   .AllowAnyHeader()
                   .AllowCredentials(); // Allow sending credentials
        });
});

var config = builder.Configuration.GetConnectionString("Default");

var app = builder.Build();

// Si la app se publica en un path base (virtual directory), configúralo mediante variable de entorno PATH_BASE
var pathBase = Environment.GetEnvironmentVariable("PATH_BASE") ?? string.Empty;
if (!string.IsNullOrEmpty(pathBase))
{
    app.UsePathBase(pathBase); // Ej: "/miApp"
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // muestra stacktraces detallados
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        var swaggerJson = string.IsNullOrEmpty(pathBase) ? "/swagger/v1/swagger.json" : $"{pathBase}/swagger/v1/swagger.json";
        c.SwaggerEndpoint(swaggerJson, "PersonalFinance API v1");
        c.RoutePrefix = "swagger"; // sirve en /swagger
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("CorsPolicy");

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints
    .MapControllers()
    );

app.MapControllers();

app.Run();
