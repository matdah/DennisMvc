var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Activate MVC

var app = builder.Build();

app.UseStaticFiles(); // use of static files
app.UseRouting(); // use routing 

// Create routing, set name & pattern
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
