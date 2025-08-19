using ControleDeMedicamentos.Infraestrutura.Arquivos.Compartilhado;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloPaciente;

namespace ControleDeMedicamentos.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Inje��o de depend�ncias criadas por n�s
        builder.Services.AddScoped(ConfigurarContextoDados);
        builder.Services.AddScoped<RepositorioPacienteEmArquivo>();          // Injeta uma inst�ncia do servi�o por requisi��o (a��o) HTTP, essa inst�ncia acompanha a requisi��o do cliente
        //builder.Services.AddSingleton<RepositorioFuncionarioEmArquivo>();     // Injeta uma inst�ncia �nica do servi�o globalmente
        //builder.Services.AddTransient<RepositorioFuncionarioEmArquivo>();     // Injeta uma inst�ncia nova do servi�o toda vez que houver uma depend�ncia ao longo de uma requisi��o

        // Inje��o de depend�ncias da Microsoft.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static ContextoDados ConfigurarContextoDados(IServiceProvider serviceProvider)
    {
        return new ContextoDados(true);
    }
}
