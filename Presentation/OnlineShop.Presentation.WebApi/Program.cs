using Microsoft.EntityFrameworkCore;
using Microsoft.Rest.ClientRuntime.Azure.Authentication.Utilities;
using OnlineShop.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conntectionString = "Data Source=172.31.31.8;Initial Catalog=OnlineShop;Integrated Security=True;TrustServerCertificate=True;";

//var options = new DbContextOptionsBuilder<ApplicationDbContrext>().UseSqlServer(conntectionString).Options;
//using ApplicationDbContrext db = new(options);

//Check.NotNull(db, nameof(db));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conntectionString));

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
