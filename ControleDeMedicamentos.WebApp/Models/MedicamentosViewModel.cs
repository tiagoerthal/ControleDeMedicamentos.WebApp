using ControleDeMedicamentos.Dominio.ModuloFornecedor;
using ControleDeMedicamentos.Dominio.ModuloMedicamento;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.Models;

public class CadastrarMedicamentoViewModel
{
    [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage =
        "O campo 'Nome' deve conter entre 2 e 100 caracteres.")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "O campo 'Descrição' é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage =
        "O campo 'Descrição' deve conter entre 5 e 255 caracteres.")]

    public string Descricao { get; set; }

    [Required(ErrorMessage = "O campo 'Quantidade em estoque' é obrigatório.")]
    [StringLength(100000, MinimumLength = 1, ErrorMessage =
        "O campo 'Quantidade em estoque' deve conter um número positivo.")]

    public string QuantidadeEmEstoque { get; set; }



    [Required(ErrorMessage = "O campo \"Fornecedores\" é obrigatório.")]
    public Guid FornecedorId { get; set; }
    public List<SelecionarFornecedorViewModel> FornecedorDisponiveis { get; set; }

    public CadastrarMedicamentoViewModel()
    {
        FornecedorDisponiveis = new List<SelecionarFornecedorViewModel>();
    }
    public CadastrarMedicamentoViewModel(List<Fornecedor> fornecedores) : this()
    {
        //if (fornecedores == null) return;

        //foreach (var f in fornecedores)
        //    FornecedoresDisponiveis.Add(new SelecionarFornecedorViewModel(f.Id, f.Nome));
        foreach (Fornecedor f in fornecedores)
        {
            SelecionarFornecedorViewModel selecionarVm =
                new SelecionarFornecedorViewModel(f.Id, f.Nome);

            FornecedorDisponiveis.Add(selecionarVm);
        }
    }
}



public class EditarMedicamentoViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage =
        "O campo 'Nome' deve conter entre 2 e 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo 'Descrição' é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage =
        "O campo 'Descrição' deve conter entre 5 e 255 caracteres.")]

    public string Descricao { get; set; }

    [Required(ErrorMessage = "O campo 'Quantidade em estoque' é obrigatório.")]
    [StringLength(100000, MinimumLength = 1, ErrorMessage =
        "O campo 'Quantidade em estoque' deve conter um número positivo.")]

    public string QuantidadeEmEstoque { get; set; }

    public Guid FornecedorId { get; set; }
    public List<SelecionarFornecedorViewModel> FornecedorDisponiveis { get; set; }

    public EditarMedicamentoViewModel()
    {
        FornecedorDisponiveis = new List<SelecionarFornecedorViewModel>();
    }

    public EditarMedicamentoViewModel(Guid id, string nome, string descricao, string quantidadeEmEstoque,
        Guid fornecedorId, List<Fornecedor> fornecedores) : this()//string cpf
    {
        foreach (Fornecedor f in fornecedores)
        {
            SelecionarFornecedorViewModel selecionarVm =
                new SelecionarFornecedorViewModel(f.Id, f.Nome);

            FornecedorDisponiveis.Add(selecionarVm);
        }

        Id = id;
        Nome = nome;
        Descricao = descricao;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        fornecedorId = fornecedorId;
    }
}

public class ExcluirMedicamentoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ExcluirMedicamentoViewModel() { }

    public ExcluirMedicamentoViewModel(Guid id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}


public class SelecionarFornecedorViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFornecedorViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}



public class VisualizarMedicamentoViewModel
{
    public List<DetalhesMedicamentoViewModel> Registros { get; }

    public VisualizarMedicamentoViewModel(List<Medicamento> medicamentos)
    {
        Registros = [];

        foreach (var m in medicamentos)
        {
            var detalhesVM = new DetalhesMedicamentoViewModel(
                m.Id,
                m.Nome,
                m.Descricao,
                m.QuantidadeEmEstoque,
            //m.Nome.Fornecedor
            m.Fornecedor?.Nome ?? "Fornecedor não informado" // Correção necessaria
            );

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesMedicamentoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string QuantidadeEmEstoque { get; set; }
    public string NomeFornecedor { get; set; }

    public DetalhesMedicamentoViewModel(Guid id, string nome, string descricao, string quantidadeEmEstoque, string nomeFornecedor)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        NomeFornecedor = nomeFornecedor;
    }
}