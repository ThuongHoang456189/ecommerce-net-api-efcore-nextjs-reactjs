using AmazonaAPI.Services;
using EFDataAccessLibary.DataAccess;
using EFDataAccessLibrary.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddDbContext<AmazonaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IdentityModelEventSource.ShowPII = true;
builder.Services.AddAuthentication(
    configureOptions =>
    {
        configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    )
    .AddJwtBearer(options =>
    {
        options.Audience = "http://localhost:5215/";
        options.Authority = "https://localhost:7215/";
        options.Configuration = new OpenIdConnectConfiguration();
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                // context.Token = context.Request.Cookies["jwt"];

                string authHeader = context.Request.Headers["authorization"];

                if(authHeader != null && authHeader.StartsWith("Bearer "))
                {
                    string encodedToken = authHeader.Substring("Bearer ".Length);
                    // Encoding encoding = Encoding.UTF8;
                    // context.Token = encoding.GetString(Convert.FromBase64String(encodedToken));
                    context.Token = encodedToken;
                }
                else
                {
                    context.Token = null;
                }

                return Task.CompletedTask;
            }
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

app.UseRouting();

app.UseCors(options => options
    .WithOrigins(new[] { "http://localhost:3000", "http://localhost:8000", "http://localhost:4200" })
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
