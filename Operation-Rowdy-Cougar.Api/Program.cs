using Operation.Rowdy.Cougar.Data;
using Microsoft.EntityFrameworkCore;
using Operation.Rowdy.Cougar.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Auth0 config
string authority = builder.Configuration["Auth0:Authority"]
    ?? throw new ArgumentNullException("Auth0:Authority");

string audience = builder.Configuration["Auth0:Audience"]
    ?? throw new ArgumentNullException("Auth0:Audience");

builder.Services.AddControllers();

// 🔥 Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = authority;
    options.Audience = audience;
});

// 🔥 Authorization
builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("delete:catalog", policy =>
        policy.Requirements.Add(new HasScopeRequirements("delete:catalog", authority)));
});

// 🔥 Database
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite("Data Source=../Registrar.sqlite",
    b => b.MigrationsAssembly("Operation-Rowdy-Cougar.Api"))
);

// 🔥 CORS
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder =>{
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔥 Pipeline (VERY IMPORTANT ORDER)
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();