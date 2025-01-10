using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Transaction_api;
using Transaction_api.Repositories;
using Transaction_api.Context;
using Transaction_api.NewFolder;
using Microsoft.Extensions.DependencyInjection;

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

var optionsbuilder = new DbContextOptionsBuilder<TransactionContext>();
optionsbuilder.UseSqlServer(Secret.secret);
TransactionContext transcontext= new(optionsbuilder.Options);
builder.Services.AddSingleton<TransactionRepo>(new TransactionRepo(transcontext));

var Categorybuilder = new DbContextOptionsBuilder<CategoryContext>();
Categorybuilder.UseSqlServer(Secret.secret);
CategoryContext Categorycontext = new(Categorybuilder.Options);
builder.Services.AddSingleton<CategoryRepo>(new CategoryRepo(Categorycontext));

var Productbuilder = new DbContextOptionsBuilder<ProductContext>();
Productbuilder.UseSqlServer(Secret.secret);
ProductContext Productcontext = new(Productbuilder.Options);
builder.Services.AddSingleton<ProductRepo>(new ProductRepo(Productcontext));

var Storebuilder = new DbContextOptionsBuilder<StoreContext>();
Storebuilder.UseSqlServer(Secret.secret);
StoreContext Storecontext = new(Storebuilder.Options);
builder.Services.AddSingleton<StoreRepo>(new StoreRepo(Storecontext));

var ProductClusterbuilder = new DbContextOptionsBuilder<ProductClusterContext>();
ProductClusterbuilder.UseSqlServer(Secret.secret);
ProductClusterContext ProductClustercontext = new(ProductClusterbuilder.Options);
builder.Services.AddSingleton<ProductClusterRepo>(new ProductClusterRepo(ProductClustercontext));

var StoreClusterbuilder = new DbContextOptionsBuilder<StoreClusterContext>();
StoreClusterbuilder.UseSqlServer(Secret.secret);
StoreClusterContext StoreClustercontext = new(StoreClusterbuilder.Options);
builder.Services.AddSingleton<StoreClusterRepo>(new StoreClusterRepo(StoreClustercontext));


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
