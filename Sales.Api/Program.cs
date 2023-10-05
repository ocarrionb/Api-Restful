using Sales.Domain;
using Microsoft.EntityFrameworkCore;
using Sales.Service.Customers;
using Sales.Repository.Commands.Customers;
using Sales.Service.Mapper;
using Sales.Repository.Queries.Customers;
using Sales.Repository.Commands.Products;
using Sales.Service.Products;
using Sales.Repository.Queries.Products;
using Sales.Repository.Commands.Sales;
using Sales.Service.Sales;

var builder = WebApplication.CreateBuilder(args);

//Add Db Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext") 
    ?? throw new InvalidOperationException("Connection string 'DBContext' not found.")));

// Add services to the container.
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ICustomerCommandsRepository, CustomerCommandsRepository>();
builder.Services.AddScoped<ICustomerUniqueQueriesRepository, CustomerUniqueQueriesRepository>();
builder.Services.AddScoped<IAllCustomersQueriesRepository, AllCustomersQueriesRepository>();
builder.Services.AddScoped<ICustomerByIdQueriesRepository, CustomerByIdQueriesRepository>();
builder.Services.AddScoped<IProductCommandsRepository, ProductCommandsRepository>();
builder.Services.AddScoped<IAllProductsQueriesRepository, AllProductsQueriesRepository>();
builder.Services.AddScoped<IProductByIdQueriesRepository, ProductByIdQueriesRepository>();
builder.Services.AddScoped<ISaleCommandsRepository, SaleCommandsRepository>();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(CustomerMapper));
builder.Services.AddAutoMapper(typeof(ProductMapper));

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
