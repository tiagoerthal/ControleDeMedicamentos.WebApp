
using ControleDeMedicamentos.WebApp.DependencyInjection;


namespace ControleDeMedicamentos.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Inje��o de depend�ncias criadas por n�s
        builder.Services.AddCamadaInfraestrutura(builder.Configuration);

        builder.Services.AddSerilogConfig(builder.Logging, builder.Configuration);

        // Inje��o de depend�ncias da Microsoft.
        builder.Services.AddControllersWithViews();

        // Middleware - Fun��es que executam durante cada requisi��o e resposta HTTP

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
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