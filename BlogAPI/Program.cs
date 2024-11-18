using BlogAPI.Entity;
using BlogAPI.Interfaces;
using BlogAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IUserServices, UserServices>();
builder.Services.AddControllers();
builder.Services.AddDbContext<BlogAPIDbContext>(db => db.UseSqlite(builder.Configuration.GetConnectionString("BlogAPIConnectionString")), ServiceLifetime.Singleton);
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

app.UseAuthorization();

app.MapControllers();

app.Run();
