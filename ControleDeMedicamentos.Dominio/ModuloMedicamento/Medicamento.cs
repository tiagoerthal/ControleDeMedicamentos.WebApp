using ControleDeMedicamentos.Dominio.Compartilhado;
using ControleDeMedicamentos.Dominio.ModuloFornecedor;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ControleDeMedicamentos.Dominio.ModuloMedicamento;

public class Medicamento : EntidadeBase<Medicamento>
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string QuantidadeEmEstoque { get; set; }
    public Fornecedor Fornecedor { get; set; }

    public Medicamento() { }

    public Medicamento(string nome, string descricao, string quantidadeEmEstoque, Fornecedor fornecedor) : this()
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        Fornecedor = fornecedor;
    }

    public override void AtualizarRegistro(Medicamento registroEditado)
    {
        Nome = registroEditado.Nome;
        Descricao = registroEditado.Descricao;
        QuantidadeEmEstoque = registroEditado.QuantidadeEmEstoque;
        Fornecedor = registroEditado.Fornecedor;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        else if (Nome.Length < 2 || Nome.Length > 100)
            erros += "O campo 'Nome' deve conter entre 3 e 100 caracteres.\n";

        if (Fornecedor == null)
            erros += "O campo \"Fornecedor\" é obrigatório.";

        if (string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo 'Descricao' é obrigatório.\n";

        else if (Descricao.Length < 5 || Descricao.Length > 255)
            erros += "O campo 'Descricao' deve conter entre 5 e 255 caracteres.\n";

        if (string.IsNullOrWhiteSpace(QuantidadeEmEstoque))
            erros += "O campo 'Quantidade em estoque' é obrigatório.\n";

        else if (QuantidadeEmEstoque.Length < 1)
            erros += "O campo 'Quantidade em estoque' deve conter um número positivo .\n";

        return erros;
    }
}