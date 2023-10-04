using Sales.Domain;
using Microsoft.EntityFrameworkCore;
using Sales.Service.Customers;
using Sales.Repository.Commands.Customers;
using Sales.Service.Mapper;
using Sales.Repository.Queries.Customers;

var builder = WebApplication.CreateBuilder(args);

//Add Db Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext") 
    ?? throw new InvalidOperationException("Connection string 'DBContext' not found.")));

// Add services to the container.
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomersCommandsRepository, CustomersCommandsRepository>();
builder.Services.AddScoped<ICustomerUniqueQueriesRepository, CustomerUniqueQueriesRepository>();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(CustomerMapper));

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
