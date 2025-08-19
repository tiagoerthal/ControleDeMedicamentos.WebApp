using ControleDeMedicamentos.Dominio.ModuloFuncionario;
using ControleDeMedicamentos.Dominio.ModuloMedicamento;
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

    //[Required(ErrorMessage = "O campo 'CPF' é obrigatório.")]
    //[RegularExpression(
    //    @"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
    //    ErrorMessage = "O campo 'CPF' deve seguir o formato 000.000.000-00."
    //)]
    //public string Cpf { get; set; }

    public CadastrarMedicamentoViewModel() { }

    public CadastrarMedicamentoViewModel(string nome, string descricao, string quantidadeEmEstoque) : this()//string cpf
    {
        Nome = nome;
        Descricao = descricao;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        //Cpf = cpf;
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

    //[Required(ErrorMessage = "O campo 'CPF' é obrigatório.")]
    //[RegularExpression(
    //    @"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
    //    ErrorMessage = "O campo 'CPF' deve seguir o formato 000.000.000-00."
    //)]
    //public string Cpf { get; set; }

    public EditarMedicamentoViewModel() { }

    public EditarMedicamentoViewModel(Guid id, string nome, string descricao, string quantidadeEmEstoque) : this()//string cpf
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        //Cpf = cpf;
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
                m.QuantidadeEmEstoque
            // m.Cpf
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
    //Forncedor Forncedor

    public DetalhesMedicamentoViewModel(Guid id, string nome, string descricao, string quantidadeEmEstoque)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        //Cpf = cpf;
    }
}