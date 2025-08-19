//using ControleDeMedicamentos.Dominio.Compartilhado;
//using System.Diagnostics.CodeAnalysis;
//using System.Text.RegularExpressions;

//namespace ControleDeMedicamentos.Dominio.ModuloFuncionario;

//public class Fornecedor : EntidadeBase<Fornecedor>
//{
//    public string Nome { get; set; }
//    public string Descricao { get; set; }
//    public string QuantidadeEmEstoque { get; set; }
//   //Forncedor Forncedor

//    protected Fornecedor() { }

//    public Fornecedor(string nome, string descricao, string quantidadeEmEstoque) : this()
//    {
//        Id = Guid.NewGuid();
//        Nome = nome;
//        Descricao = descricao;
//        QuantidadeEmEstoque = quantidadeEmEstoque;
//    }

//    public override void AtualizarRegistro(Fornecedor registroEditado)
//    {
//        Nome = registroEditado.Nome;
//        Descricao = registroEditado.Descricao;
//        QuantidadeEmEstoque = registroEditado.QuantidadeEmEstoque;
//    }

//    public override string Validar()
//    {
//        string erros = "";

//        if (string.IsNullOrWhiteSpace(Nome))
//            erros += "O campo 'Nome' é obrigatório.\n";

//        else if (Nome.Length < 2 || Nome.Length > 100)
//            erros += "O campo 'Nome' deve conter entre 2 e 100 caracteres.\n";

//        if (string.IsNullOrWhiteSpace(Descricao))
//            erros += "O campo 'Descricao' é obrigatório.\n";

//        else if (Descricao.Length < 2 || Descricao.Length > 100)
//            erros += "O campo 'Descricao' deve conter entre 2 e 100 caracteres.\n";

//        if (string.IsNullOrWhiteSpace(QuantidadeEmEstoque))
//            erros += "O campo 'Quantidade em estoque' é obrigatório.\n";

//        else if (!Regex.IsMatch(QuantidadeEmEstoque, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
//            erros += "O campo 'Quantidade em estoque' deve .\n";

//        return erros;
//    }
//}