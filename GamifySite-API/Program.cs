using GamifySite_API.DBContext;
using GamifySite_API.Interfaces;
using GamifySite_API.Repository.UserRepo;
using GamifySite_API.Repository.VendorRepo;
using GamifySite_API.Repository.VoucherRepo;
using GamifySite_API.Repository.RatingRepo;
using Microsoft.EntityFrameworkCore;
using GamifySite_API.Repository.SpinRepo;
using GamifySite_API.Repository.SpinPrizeRepo;
using GamifySite_API.Repository.VoucherDetailRepo;
using GamifySite_API.Repository.VendorAddrRepo;
using GamifySite_API.Repository.VendorCategoryRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{

    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Allow requests from any IP or origin
              .AllowAnyMethod() // Allow any HTTP method (GET, POST, PUT, etc.)
              .AllowAnyHeader(); // Allow any headers
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddScoped<IUserRepository, UserRepo>();
builder.Services.AddScoped<IVendorRepository, VendorRepo>();
builder.Services.AddScoped<IVoucherRepository, VoucherRepo>();
builder.Services.AddScoped<IRatingRepository, RatingRepo>();
builder.Services.AddScoped<ISpinRepositry, SpinRepo>();
builder.Services.AddScoped<ISpinPrizeRepository, SpinPrizeRepo>();
builder.Services.AddScoped<IVoucherDetailRepository, VoucherDetailRepo>();

builder.Services.AddScoped<IVendorAddressRepository, VendorAddressRepo>();
builder.Services.AddScoped<IVendorCategoryRepository, VendorCategoryRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
