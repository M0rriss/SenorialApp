using App_Senorial.Middleware;
using DBSenorialModels.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Gmail;
using System.Reflection;
using System.Text;
using UtilityAutoMapper;
using UtilitySecurity.OneTimePassword;

var builder = WebApplication.CreateBuilder(args);

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "origins",
                      builder =>
                      {
                          //builder.WithOrigins("http://127.0.0.1:5500");
                          builder.AllowAnyOrigin();
                          builder.AllowAnyMethod();//get post put delete patch 
                          builder.AllowAnyHeader();//
                      });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//JWT 
builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            //ClockSkew = TimeSpan.FromMinutes(3),
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
//SMTP CONFIG
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<SendEmailWithGoogleSMTP>();

// Configure Swagger for API documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Señorial Web Services",
        Version = "v1",
        Description = "Documentación de los servicios para el sistema de Señorial",
        Contact = new OpenApiContact
        {
            Name = "Mauricio Contreras",
            Email = "i2026200@continental.edu.pe",
        },
    });

    // Include XML comments for better documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});
//Add DbContext
builder.Services.AddDbContext<DBSenorialContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DBSenorial")));

//AutoMapper
builder.Services.AddAutoMapper(typeof(IStartup).Assembly, typeof(AutoMapperProfiles).Assembly);



//Migraciones
var app = builder.Build();
using( var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<DBSenorialContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseMiddleware(typeof(ApiMiddleware));

app.MapControllers();

app.UseCors("origins");

app.Run();
