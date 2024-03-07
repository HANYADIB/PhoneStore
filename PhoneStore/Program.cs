using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Models;
using PhoneStore.Models.Resority;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDb>(optionBuilder =>
    optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=PhoneStore;Integrated Security=True"));
builder.Services.AddIdentity<ApplacationUser, IdentityRole>(
options => options.Password.RequireDigit = true).AddEntityFrameworkStores<ApplicationDb>();

builder.Services.AddScoped<IHomeRes, HomeRes>();
builder.Services.AddScoped<ICartRes, CartRes>();
builder.Services.AddScoped<ISupplierRes, SupplierRes>();
builder.Services.AddScoped<IProductRes, ProductRes>();
builder.Services.AddScoped<ICatagoryRes, CatagoryRes>();
builder.Services.AddScoped<ICountryRes, CountryRes>();
builder.Services.AddScoped<ICityRes, CityRes>();
builder.Services.AddScoped<IUserOrderRes, UserOrderRes>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
