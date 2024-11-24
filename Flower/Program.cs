using Flower;
using Flower.DAL.Interfaces;
using Flower.DAL.Repositorys;
using Flower.MappingProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//ConnectDB
builder.Services.AddDbContext<FlowerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Flower")));
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(builder.Configuration["Redis:ConnectionString"]));
// Repository

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenBlacklistRepository, RedisTokenBlacklistRepository>();
builder.Services.AddScoped<IOccasionRepository, OccasionRepository>();
builder.Services.AddScoped<IFlowerRepository, FlowerRepository>();
builder.Services.AddScoped<IViewOrderRepository, ViewOrderRepository>(); // QA
builder.Services.AddScoped<IViewOrderService, ViewOrderService>(); //QA




// Mapping
builder.Services.AddAutoMapper(typeof(Regiter_User_Profile));
builder.Services.AddAutoMapper(typeof(OccasionDto_Occasion));
builder.Services.AddAutoMapper(typeof(Create_FlowerDto_Profile));

// Phan quyen

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ManagerPolicy", policy => policy.RequireRole("Manager", "Admin"));
});


// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                var tokenBlacklistRepository = context.HttpContext.RequestServices.GetRequiredService<ITokenBlacklistRepository>();
                var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                if (await tokenBlacklistRepository.IsTokenBlacklistedAsync(token))
                {
                    context.Fail("This token has been blacklisted");
                }
            }
        };
    });



builder.Services.AddAuthorization();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
