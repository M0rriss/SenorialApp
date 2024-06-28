using App_Senorial.Middleware;
using Business.Auth;
using DBSenorialModels.Data;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Gmail;
using System.Reflection;
using System.Security.Claims;
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
                          builder.WithOrigins("http://127.0.0.1:7283");
                          //builder.AllowAnyOrigin();
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

builder.Services.AddHttpContextAccessor();
//builder.Services.AddAuthorization();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
   // options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    //options.Authority = "https://localhost:7283";
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //ValidateIssuerSigningKey = true,
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false,

        //ValidateIssuer = true,
        //ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //ValidateAudience = true,
        //ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});

//=============================
//builder.Services.AddAuthorization(options =>
//{
//    // Definir una política que permita a cualquier usuario autenticado
//    options.AddPolicy("RequireLoggedIn", policy =>
//        policy.RequireAuthenticatedUser());
//});
//builder.Services.AddControllers();


//builder.Services.AddHttpContextAccessor()
//    .AddHttpContextAccessor()
//    .AddAuthorization()
//    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.Authority = "https://localhost:7283";
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//            ValidateAudience = false,
//            ValidAudience = builder.Configuration["JwtSettings:Audience"],
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ClockSkew = TimeSpan.Zero,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
//        };
//    });


// Configurar políticas de autorización
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminPolicy", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim(ClaimTypes.Role, "Administador");
//        policy.RequireClaim(ClaimTypes.Email, "admin@admin.com");
//    });

//    options.AddPolicy("UserPolicy", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim(ClaimTypes.Role, "Cliente");
//        policy.RequireClaim(ClaimTypes.Role, "Empleado");
//        policy.RequireClaim(ClaimTypes.Role, "Cajero");
//    });
//});

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
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
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

//app.UseAuthentication();


app.UseCors("origins");

app.UseAuthorization();

app.UseMiddleware(typeof(ApiMiddleware));

app.MapControllers();

app.Run();
