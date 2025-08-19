using ControleDeMedicamentos.Dominio.ModuloPaciente;
using ControleDeMedicamentos.Infraestrutura.Arquivos.Compartilhado;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloPaciente;
using ControleDeMedicamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.WebApp.Controllers;

public class PacienteController : Controller
{
    private readonly RepositorioPacienteEmArquivo repositorioModuloPaciente;

    // Inversão de controle
    public PacienteController(RepositorioPacienteEmArquivo repositorioPaciente)
    {
        this.repositorioModuloPaciente = repositorioPaciente;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var pacientes = repositorioModuloPaciente.SelecionarRegistros();

        var visualizarVm = new VisualizarPacienteViewModel(pacientes);

        return View(visualizarVm);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        var cadastrarVm = new CadastrarPacienteViewModel();

        return View(cadastrarVm);
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastrarPacienteViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        var entidade = new Paciente(
            cadastrarVm.Nome,
            cadastrarVm.Telefone,
            cadastrarVm.CartaoDoSus,
            cadastrarVm.Cpf
        );

        repositorioModuloPaciente.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var registro = repositorioModuloPaciente.SelecionarRegistroPorId(id);

        var editarVm = new EditarPacienteViewModel(
            registro.Id,
            registro.Nome,
            registro.Telefone,
            registro.CartaoDoSus,
            registro.Cpf
        );

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarPacienteViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        var pacienteEditado = new Paciente(
            editarVm.Nome,
            editarVm.Telefone,
            editarVm.CartaoDoSus,
            editarVm.Cpf
        );

        repositorioModuloPaciente.EditarRegistro(editarVm.Id, pacienteEditado);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var registro = repositorioModuloPaciente.SelecionarRegistroPorId(id);

        var excluirVm = new ExcluirPacienteViewModel(
            registro.Id,
            registro.Nome
        );

        return View(excluirVm);
    }

    [HttpPost]
    public IActionResult Excluir(ExcluirPacienteViewModel excluirVm)
    {
        repositorioModuloPaciente.ExcluirRegistro(excluirVm.Id);

        return RedirectToAction(nameof(Index));
    }
}
