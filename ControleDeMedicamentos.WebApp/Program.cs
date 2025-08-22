using ControleDeMedicamentos.Infraestrutura.Arquivos.Compartilhado;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloFornecedor;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloFuncionario;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloMedicamento;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloPaciente;
using Serilog;
using Serilog.Events;

namespace ControleDeMedicamentos.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Injeção de dependências criadas por nós
        builder.Services.AddScoped((_) => new ContextoDados(true));
        builder.Services.AddScoped<RepositorioFornecedorEmArquivo>();
        builder.Services.AddScoped<RepositorioFuncionarioEmArquivo>();
        builder.Services.AddScoped<RepositorioMedicamentoEmArquivo>();
        builder.Services.AddScoped<RepositorioPacienteEmArquivo>();

        var caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        // Variáveis de Ambiente
        var licenseKey = builder.Configuration["NEWRELIC_LICENSE_KEY"];

        var caminhoArquivoLogs = Path.Combine(caminhoAppData, "ControleDeMedicamentos", "erro.log");

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(caminhoArquivoLogs, LogEventLevel.Error)
            .WriteTo.NewRelicLogs(
                endpointUrl: "https://log-api.newrelic.com/log/v1",
                applicationName: "controle-de-medicamentos",
                licenseKey: licenseKey
            )
            .CreateLogger();

        builder.Logging.ClearProviders();

        builder.Services.AddSerilog();

        // Injeção de dependências da Microsoft.
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
}