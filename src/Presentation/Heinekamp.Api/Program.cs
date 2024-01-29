using Heinekamp.Application;
using Heinekamp.Persistence.EntityFramework;
using Heinekamp.Shared;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHttpContextAccessor()
    .AddHttpClient()
    .AddControllers();

builder.Services
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddSharedServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowHeinekampOrigins",
        policyBuilder =>
        {
            policyBuilder
                .WithOrigins(Environment.GetEnvironmentVariable("FrontEndApplication") ?? throw new ArgumentNullException($"FrontEndApplication"));
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(configuration =>
{
    configuration.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Heinekamp - API!",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseCors("AllowHeinekampOrigins");

app.SeedDatabase();
app.UseSwagger();
app.UseSwaggerUI(configure =>
{
    configure.SwaggerEndpoint("/swagger/v1/swagger.json", "Heinekamp API - v1");
    configure.RoutePrefix = string.Empty;

    configure.InjectStylesheet("../swagger-ui/swagger.css");
    configure.InjectJavascript("../swagger-ui/swaggerinit.js");

    configure.DocumentTitle = "Heinekamp API";

});
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();