using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Transaction_api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowall", policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}
);

var optionsbuilder = new DbContextOptionsBuilder<Transactionsclass.TransactionDbContext>();
optionsbuilder.UseSqlServer(Secret.secret);
Transactionsclass.TransactionDbContext transcontext= new(optionsbuilder.Options);

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
