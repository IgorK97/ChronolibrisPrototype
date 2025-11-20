using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chronolibris.Application.Extensions;
using Chronolibris.Application.Handlers;
using Chronolibris.Infrastructure.DatabaseChecker;
using Chronolibris.Infrastructure.DependencyInjection;
using ChronolibrisPrototype.DependencyInjection;
using ChronolibrisPrototype.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var allowAVDCORSPolicy = "_allowAVDCORSPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowAVDCORSPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173").WithOrigins("http://localhost:45457")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});

//Настройка логирования и уровней
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Logging.AddFilter("Microsoft", LogLevel.Warning)
    .AddFilter("System", LogLevel.Warning)
    .AddFilter("ChronolibrisPrototype", LogLevel.Information);
builder.Services.AddDatabaseInfrastructure(builder.Configuration);
builder.Services.AddIdentityRealization(builder.Configuration);
builder.Services.AddFileProviderInfrastructure(builder.Configuration);
builder.Services.AddCdnService(builder.Configuration);
//Конфигурация аутентификации с использованием JWT-токенов
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
                                            {
                                                ValidateIssuer = true,
                                                ValidateAudience = true,
                                                ValidateLifetime = true,
                                                ValidateIssuerSigningKey = true,
                                                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                                                ValidAudience = builder.Configuration["Jwt:Audience"],
                                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.
            GetBytes(builder.Configuration["Jwt:Key"])),
                                                RoleClaimType = ClaimsIdentity.DefaultRoleClaimType
                                            };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("admin"));
});

// Add services to the container.
//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly(typeof(GetBookFileHandler).Assembly)
//    );
builder.Services.AddApplicationServices();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "My API";
});

var app = builder.Build();

var configuration = app.Configuration;
//app.UseMiddleware<ExceptionHandlingMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    //app.UseSwagger();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chronolibris Prototype V1");
    //});
}

app.UseHttpsRedirection();
app.UseHttpLogging();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
app.UseCors(allowAVDCORSPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseOpenApi();
app.UseSwaggerUI();
app.MapControllers();

//await InitialDatabaseSeeder.InitialSeedDatabase(app.Services, configuration);


app.Lifetime.ApplicationStarted.Register(async () =>
{
    try
    {
        await DatabaseChecker.CheckDatabase(app.Services, configuration);
    }
    catch (Exception ex)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Database seeding failed");
    }
});

app.Run();
