using botanic.Data;
using botanic.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        builder => builder.WithOrigins("http://localhost:4200", "http://localhost:5229", "https://localhost:7210")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "V1",
        Title = "API Botanic",
        Description = "Mon API liée aux plantes : Apprenez la classification des plantes et comment en prendre soin !",
        TermsOfService = new Uri("https://google.com"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Lucas BALZA",
            Email = "mail@mail.com",
            Url = new Uri("https://google.com")
        }
    });

    // Ajout de la lecture des commentaires XML
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BotanicDbContext>(options => options.UseInMemoryDatabase("BotanicDb"));


var app = builder.Build();

// Seed data - Intégration des données au lancement
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BotanicDbContext>();
    
    // Vérifier si la base de données contient déjà des données
    if (!context.Plants.Any())
    {
        // Ajouter les plantes de test
        context.Plants.AddRange(Plants.plantsList);
        Console.WriteLine("Plantes ajoutées à la base de données");
    }
    
    if (!context.Users.Any())
    {
        // Ajouter les utilisateurs de test
        context.Users.AddRange(Users.usersList);
        Console.WriteLine("Utilisateurs ajoutés à la base de données");
    }
    
    context.SaveChanges();
    Console.WriteLine("Base de données initialisée avec succès !");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Désactivé temporairement pour le développement

app.UseCors("MyCorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
