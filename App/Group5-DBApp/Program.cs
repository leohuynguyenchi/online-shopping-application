using Group5_DBApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Register DataContext Service
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register ProductService
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddRazorPages();

// Add session services
builder.Services.AddDistributedMemoryCache(); // Required to use session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // You can set the session timeout here
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use session
app.UseSession();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("/Products"); // Redirect to the products page
        return Task.CompletedTask;
    });
});

app.Run();
