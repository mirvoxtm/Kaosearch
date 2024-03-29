using Kaosearch.Data;
using Kaosearch.Services;

namespace Kaosearch {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<KaosearchContext>();
            builder.Services.AddScoped<KaomojiService>();
            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.Use(async (ctx, next) =>
{
    await next();

    if(ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
    {
        //Re-execute the request so the user gets the error page
        string originalPath = ctx.Request.Path.Value;
        ctx.Items["originalPath"] = originalPath;
        ctx.Request.Path = "/404";
        await next();
    }
});

            // Configure the HTTP request pipeline.
              if (app.Environment.IsDevelopment()) {
                using (var scope = app.Services.CreateScope()) {
                    var services = scope.ServiceProvider;
                    var seedingService = services.GetRequiredService<SeedingService>();
                    seedingService.Seed();
                }
            }

            else {
                app.UseExceptionHandler("/Home/Error");
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
        }
    }
}