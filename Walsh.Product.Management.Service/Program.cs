using Microsoft.EntityFrameworkCore;
using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Bll.Implimentations;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Dal.Implimentations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Configuration.AddJsonFile("appsettings.json");

// Database connection
builder.Services.AddDbContext<WalshDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WalshConnection"),
        sql =>
        {
            sql.EnableRetryOnFailure();
            sql.UseRelationalNulls();
            sql.CommandTimeout(1000);
        });

    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
}, ServiceLifetime.Scoped);




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service registrations
builder.Services.AddScoped<IProductCategoryDataAccess, ProductCategoryDataAccess>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

builder.Services.AddScoped<IProductDataAccess, ProductDataAccess>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProductLocationDataAccess, ProductLocationDataAccess>();
builder.Services.AddScoped<IProductLocationService, ProductLocationService>();

builder.Services.AddScoped<IProductReviewDataAccess, ProductReviewDataAccess>();
builder.Services.AddScoped<IProductReviewService, ProductReviewService>();

builder.Services.AddScoped<IProductStockDataAccess, ProductStockDataAccess>();
builder.Services.AddScoped<IProductStockService, ProductStockService>();

builder.Services.AddScoped<IProductTrashDataAccess, ProductTrashDataAccess>();
builder.Services.AddScoped<IProductTrashService, ProductTrashService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("corsapp");
app.MapControllers();

app.Run();
