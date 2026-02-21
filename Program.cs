using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using smart_notes_backend.Data;
using smart_notes_backend.Helpers.AI.Chunking;
using smart_notes_backend.Helpers.Authentication;
using smart_notes_backend.Repositories.Chunks;
using smart_notes_backend.Repositories.Notes;
using smart_notes_backend.Services.AI;
using smart_notes_backend.Services.Authentication;
using smart_notes_backend.Services.Chunking;
using smart_notes_backend.Services.Notes;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

// accessor needed for user context
builder.Services.AddHttpContextAccessor();

// IoC Components
// Repositories
builder.Services.AddScoped<INotesRepository, NotesRepository>();
builder.Services.AddScoped<INoteChunksRepository, NoteChunksRepository>();

// chunking strategy, defaut using word chunking
builder.Services.AddScoped<IChunkingStrategy>(_ => new WordChunkingStrategy(chunkSize: 500, overlap: 100));

// Services
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
// user context registration
builder.Services.AddScoped<IUserContext, UserContext>();

// http client for ai service
builder.Services.AddHttpClient<IAIService, AIService>();

builder.Services.AddScoped<IAIService, AIService>();
builder.Services.AddScoped<IChunkingService, ChunkingService>();
builder.Services.AddScoped<INotesService, NotesService>();



builder.Services.AddDbContext<SqlServerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDatabase"))
);


// Authentication Scheme
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)
            ),
            ValidateIssuerSigningKey = true,
            RoleClaimType = ClaimTypes.Role
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
