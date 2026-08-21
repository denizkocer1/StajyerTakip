using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using StajyerTakip.DAL;
using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Abstract.Base;
using StajyerTakip.DAL.Concrete;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Services.Authentication;
using StajyerTakip.Services.Authentication.Implementations;
using StajyerTakip.Services.Authentication.Interfaces;
using StajyerTakip.Services.InternalServices.Implementations;
using StajyerTakip.Services.InternalServices.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/system-log-.txt",
        rollingInterval: RollingInterval.Day
    )
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "StajyerTakip API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT token'ı 'Bearer {token}' formatında girin."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("Bearer", document),
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//AddScoped - Her HTTP isteği boyunca bir tane UnitOfWork oluştur ve aynı istek içinde hep onu kullan.

builder.Services.AddScoped<IStajyerRepository, StajyerRepository>();
builder.Services.AddScoped<IBeceriRepository, BeceriRepository>();
builder.Services.AddScoped<IBeceriKategoriRepository, BeceriKategoriRepository>();
builder.Services.AddScoped<IDegerlendirmeRepository, DegerlendirmeRepository>();
builder.Services.AddScoped<IDegerlendirmeKriteriRepository, DegerlendirmeKriteriRepository>();
builder.Services.AddScoped<IDepartmanRepository, DepartmanRepository>();
builder.Services.AddScoped<IDosyaRepository, DosyaRepository>();
builder.Services.AddScoped<IDosyaKategoriRepository, DosyaKategoriRepository>();
builder.Services.AddScoped<IKullaniciRepository, KullaniciRepository>();
builder.Services.AddScoped<ILinkRepository, LinkRepository>();
builder.Services.AddScoped<IModulRepository, ModulRepository>();
builder.Services.AddScoped<IProjeRepository, ProjeRepository>();
builder.Services.AddScoped<IReferansRepository, ReferansRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolModulYetkiRepository, RolModulYetkiRepository>();
builder.Services.AddScoped<IStajyerBeceriRepository, StajyerBeceriRepository>();
builder.Services.AddScoped<IYorumRepository, YorumRepository>();

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IStajyerService, StajyerService>();

builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();

builder.Services.AddScoped<IDegerlendirmeService, DegerlendirmeService>();

builder.Services.AddHttpContextAccessor();



var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>()
    ?? throw new InvalidOperationException("Jwt ayarları appsettings.json içinde bulunamadı.");

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler("/error");

app.MapControllers();

app.Run();
