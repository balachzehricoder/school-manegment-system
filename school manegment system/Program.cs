using Microsoft.EntityFrameworkCore;
using school_manegment_system.datacontext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<database>(options => options.UseSqlServer(


    builder.Configuration.GetConnectionString("dbconnect")));


builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=parent}/{action=login}/{id?}");

app.Run();
