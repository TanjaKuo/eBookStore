using eBookStore.Models;
using eBookStore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookConnectionString") ?? throw new InvalidOperationException("Connection string 'BookDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IReserveRepository, ReserveRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

