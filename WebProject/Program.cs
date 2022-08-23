using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, MyRepository>();
builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlite("Data Source=exercise2.db"));
builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
   var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
   ctx.Database.EnsureDeleted();
   ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
   endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}");
});

app.Run();
