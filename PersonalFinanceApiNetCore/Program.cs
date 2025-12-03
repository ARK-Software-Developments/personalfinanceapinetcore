using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS services

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "CorsPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost", "http://localhost:3000", "https://localhost", "https://localhost:3000")
                   .WithMethods("GET", "POST", "PUT")
                   .AllowAnyHeader()
                   .AllowCredentials(); // Allow sending credentials
        });
});

var config = builder.Configuration.GetConnectionString("Default");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

//app.MapControllers();

app.Run();
