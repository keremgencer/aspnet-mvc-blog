using Blog.Web.Mvc.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o => {
        o.Cookie.Name = "AuthenticationName";
        o.LoginPath = "/Auth/Login";
        o.AccessDeniedPath = "/Auth/AccessDenied";
    });

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    // Veritaban� servisine eri�im sa�lar.
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Veritaban�n� sil
    context.Database.EnsureDeleted();
    // Veritaban�n� olu�turur
    context.Database.EnsureCreated();

    DbSeeder.Seed(context);
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
