using ControleDeMedicamentos.Dominio.ModuloPaciente;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloPaciente;
using ControleDeMedicamentos.Infraestrutura.SqlServer.ModuloPaciente;
using ControleDeMedicamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.WebApp.Controllers;

public class PacienteController : Controller
{
    private readonly RepositorioPacienteEmSql repositorioPaciente;

    public PacienteController(RepositorioPacienteEmSql repositorioPaciente)
    {
        this.repositorioPaciente = repositorioPaciente;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var Pacientes = repositorioPaciente.SelecionarRegistros();

        var visualizarVm = new VisualizarPacienteViewModel(Pacientes);

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

        repositorioPaciente.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var registro = repositorioPaciente.SelecionarRegistroPorId(id);

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

        var PacienteEditado = new Paciente(
            editarVm.Nome,
            editarVm.Telefone,
            editarVm.CartaoDoSus,
            editarVm.Cpf
        );

        repositorioPaciente.EditarRegistro(editarVm.Id, PacienteEditado);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var registro = repositorioPaciente.SelecionarRegistroPorId(id);

        var excluirVm = new ExcluirPacienteViewModel(
            registro.Id,
            registro.Nome
        );

        return View(excluirVm);
    }

    [HttpPost]
    public IActionResult Excluir(ExcluirPacienteViewModel excluirVm)
    {
        repositorioPaciente.ExcluirRegistro(excluirVm.Id);

        return RedirectToAction(nameof(Index));
    }
}