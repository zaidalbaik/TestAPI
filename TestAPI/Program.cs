using CQRS_lib;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CQRS_lib.Data;
using CQRS_lib.Data.Interceptors;

var builder = WebApplication.CreateBuilder(args);

//Add DbContext 
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr"))
//      .AddInterceptors(new SoftDeleteInterceptor()));

//Add DbContext CQRS Proj
builder.Services.AddDbContext<APIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr"))
      .AddInterceptors(new SoftDeleteInterceptor()));

builder.Services.AddMediatR(typeof(MyLib).Assembly);
// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
