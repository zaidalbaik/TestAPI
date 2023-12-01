using CQRS_lib;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CQRS_lib.Data;
using CQRS_lib.Data.Interceptors;
using Microsoft.AspNetCore.Identity;
using CQRS_lib.Data.Models;
using TestAPI.Extentions;

var builder = WebApplication.CreateBuilder(args);

//Add DbContext 
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr"))
//      .AddInterceptors(new SoftDeleteInterceptor()));

//Add DbContext CQRS Proj
builder.Services.AddDbContext<APIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr"))
      .AddInterceptors(new SoftDeleteInterceptor()));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<APIDbContext>();

builder.Services.AddMediatR(typeof(MyLib).Assembly);
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenJwtAuth(); //Custom

//TestAPI.Extentions.AddCustomJwtAuth  'ext.. method'
builder.Services.AddCustomJwtAuth(builder.Configuration);//Custom

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
