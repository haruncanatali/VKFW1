using VKFW1.Api.DataAccess.Abstract;
using VKFW1.Api.DataAccess.Concrete;
using VKFW1.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// DependencyInjection
builder.Services.AddTransient<ICustomerService, CustomerManager>();
builder.Services.AddTransient<IUserService, UserManager>();

// Add services to the container.
builder.Services.AddControllers();

// Konsola loglayacağım
builder.Services.AddLogging(config =>
{
    config.AddConsole();
});

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

// GlobalExceptionMiddleware için yazdım
app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();