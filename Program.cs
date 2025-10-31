using Microsoft.EntityFrameworkCore;
using OrderEvent.Controllers;
using OrderEvent.Data;
using OrderEvent.Services;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<DeliveryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

var orderService = app.Services.GetRequiredService<OrderService>();
var emailService = app.Services.GetRequiredService<EmailService>();
var stockService = app.Services.GetRequiredService<StockService>();
var deliveryService = app.Services.GetRequiredService<DeliveryService>();

orderService.OnEventValidation += stockService.StockValidation;
orderService.OnEventCreation += stockService.StockUpdate;
orderService.OnEventCreation += emailService.SendEmail;
orderService.OnEventCreation += deliveryService.SendProduct;


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
