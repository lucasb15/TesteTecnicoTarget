using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Estoque.Modelos;
using TesteTecnicoTarget.Estoque.Modelos.Enum;

namespace TesteTecnicoTarget.Estoque.Servicos;

internal class ProdutoService
{
    private readonly List<Produto> produtos = new();
    private readonly List<Movimentacao> movimentacoes = new();
    public IReadOnlyList<Movimentacao> Movimentacoes => movimentacoes;

    private int sequenciaMovimentacao = 1;

    /// <summary>
    /// Altera a sequência da próxima movimentação.
    /// </summary>
    /// <returns></returns>
    public void ProximoId() => ++sequenciaMovimentacao;

    /// <summary>
    /// Retorna um produto pelo código, ou null se não existir.
    /// </summary>
    public Produto? BuscarProduto(int codigo)
    {
        return produtos.FirstOrDefault(p => p.Codigo == codigo);
    }

    /// <summary>
    /// Cria e adiciona um novo produto ao estoque.
    /// </summary>
    public Produto CriarProduto(int codigo, string nome)
    {
        var novo = new Produto(codigo, nome);

        produtos.Add(novo);
        return novo;
    }


    /// <summary>
    /// Adiciona quantidade ao estoque do produto.
    /// Retorna true se conseguiu.
    /// </summary>
    public bool AdicionarProduto(Produto produto, int quantidade)
    {
        if (produto == null || quantidade <= 0)
            return false;

        produto.Adicionar(quantidade);

        movimentacoes.Add(new Movimentacao
        {
            IdMovimentacao = sequenciaMovimentacao,
            CodigoProduto = produto.Codigo,
            Tipo = TipoMovimentacao.ENTRADA,
            Quantidade = quantidade
        });

        return true;
    }


    /// <summary>
    /// Remove quantidade do estoque, sem permitir negativo.
    /// Retorna true caso tenha conseguido remover.
    /// </summary>
    public bool RemoverProduto(Produto produto, int quantidade)
    {
        if (produto == null || quantidade <= 0)
            return false;

        if (produto.QuantidadeEstoque < quantidade)
            return false;

        produto.Remover(quantidade);

        movimentacoes.Add(new Movimentacao
        {
            IdMovimentacao = sequenciaMovimentacao,
            CodigoProduto = produto.Codigo,
            Tipo = TipoMovimentacao.SAIDA,
            Quantidade = quantidade
        });

        return true;
    }


    /// <summary>
    /// Retorna uma lista com todos os produtos.
    /// </summary>
    public List<Produto> ConsultarEstoque()
    {
        return produtos
            .OrderBy(p => p.Codigo)
            .ToList();
    }
}
