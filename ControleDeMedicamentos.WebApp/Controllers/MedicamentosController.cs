using ControleDeMedicamentos.Dominio.ModuloFornecedor;
using ControleDeMedicamentos.Dominio.ModuloMedicamento;
using ControleDeMedicamentos.Infraestrutura.Arquivos.Compartilhado;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloFornecedor;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloMedicamento;
using ControleDeMedicamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.WebApp.Controllers;

public class MedicamentoController : Controller
{
    private RepositorioMedicamentoEmArquivo repositorioModuloMedicamento;
    private RepositorioFornecedorEmArquivo repositorioModuloFornecedor;

    // Inversão de controle
    public MedicamentoController(RepositorioMedicamentoEmArquivo repositorioMedicamento,
        RepositorioFornecedorEmArquivo repositorioFornecedor)
    {
        ContextoDados contexto = new ContextoDados(true);
        repositorioModuloMedicamento = repositorioMedicamento;
        repositorioModuloFornecedor = repositorioFornecedor;
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
        List<Fornecedor> fornecedores = repositorioModuloFornecedor.SelecionarRegistros();

        CadastrarMedicamentoViewModel cadastrarVm = new CadastrarMedicamentoViewModel(fornecedores);
        //var cadastrarVm = new CadastrarMedicamentoViewModel(fornecedores);

        return View(cadastrarVm);
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastrarMedicamentoViewModel cadastrarVm)
    {
        Fornecedor fornecedorSelecionado = repositorioModuloFornecedor.SelecionarRegistroPorId(cadastrarVm.FornecedorId);

        if (fornecedorSelecionado == null)
            return RedirectToAction(nameof(Index));

        //if (!ModelState.IsValid)
        //    return View(cadastrarVm);

        //var fornecedor = repositorioModuloFornecedor.SelecionarRegistroPorId(cadastrarVm.FornecedorId);

        var entidade = new Medicamento(
            cadastrarVm.Nome,
            cadastrarVm.Descricao,
            cadastrarVm.QuantidadeEmEstoque,
            fornecedorSelecionado
        );

        repositorioModuloMedicamento.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var registro = repositorioModuloMedicamento.SelecionarRegistroPorId(id);
        List<Fornecedor> fornecedores = repositorioModuloFornecedor.SelecionarRegistros();

        var editarVm = new EditarMedicamentoViewModel(
            registro.Id,
            registro.Nome,
            registro.Descricao,
            registro.QuantidadeEmEstoque,
            registro.Fornecedor.Id,
            fornecedores
        );

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(Guid id, EditarMedicamentoViewModel editarVm)
    {
        Fornecedor fornecedorSelecionado = repositorioModuloFornecedor.SelecionarRegistroPorId(editarVm.FornecedorId);

        if (!ModelState.IsValid)
            return View(editarVm);

        var medicamentoEditado = new Medicamento(
            editarVm.Nome,
            editarVm.Descricao,
            editarVm.QuantidadeEmEstoque,
            fornecedorSelecionado

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