using ControleDeMedicamentos.Dominio.ModuloMedicamento;
using ControleDeMedicamentos.Infraestrutura.Arquivos.Compartilhado;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloMedicamento;
using ControleDeMedicamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.WebApp.Controllers;

public class MedicamentoController : Controller
{
    private readonly RepositorioMedicamentoEmArquivo repositorioModulov;
    private RepositorioMedicamentoEmArquivo repositorioModuloMedicamento;

    // Inversão de controle
    public MedicamentoController(RepositorioMedicamentoEmArquivo repositorioMedicamento)
    {
        this.repositorioModuloMedicamento = repositorioMedicamento;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var medicamentos = repositorioModuloMedicamento.SelecionarRegistros();

        var visualizarVm = new VisualizarMedicamentoViewModel(medicamentos);

        return View(visualizarVm);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        var cadastrarVm = new CadastrarMedicamentoViewModel();

        return View(cadastrarVm);
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastrarMedicamentoViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        var entidade = new Medicamento(
            cadastrarVm.Nome,
            cadastrarVm.Descricao,
            cadastrarVm.QuantidadeEmEstoque
        //cadastrarVm.Fornecedor
        );

        repositorioModuloMedicamento.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var registro = repositorioModuloMedicamento.SelecionarRegistroPorId(id);

        var editarVm = new EditarMedicamentoViewModel(
            registro.Id,
            registro.Nome,
            registro.Descricao,
            registro.QuantidadeEmEstoque
        //registro.Fornecedor
        );

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarMedicamentoViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        var medicamentoEditado = new Medicamento(
            editarVm.Nome,
            editarVm.Descricao,
            editarVm.QuantidadeEmEstoque
        //registro.Fornecedor

        );

        repositorioModuloMedicamento.EditarRegistro(editarVm.Id, medicamentoEditado);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var registro = repositorioModuloMedicamento.SelecionarRegistroPorId(id);

        var excluirVm = new ExcluirMedicamentoViewModel(
            registro.Id,
            registro.Nome
        );

        return View(excluirVm);
    }

    [HttpPost]
    public IActionResult Excluir(ExcluirMedicamentoViewModel excluirVm)
    {
        repositorioModuloMedicamento.ExcluirRegistro(excluirVm.Id);

        return RedirectToAction(nameof(Index));
    }
}