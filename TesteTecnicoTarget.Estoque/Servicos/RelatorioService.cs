using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Estoque.Modelos;
using TesteTecnicoTarget.Estoque.Modelos.Enum;

namespace TesteTecnicoTarget.Estoque.Servicos;

internal class RelatorioService
{
    private readonly ProdutoService produtoService;

    public RelatorioService(ProdutoService produtoService)
    {
        this.produtoService = produtoService;
    }

    public void RelatorioSimples()
    {
        var produtos = produtoService.ConsultarEstoque();
        var movimentos = produtoService.Movimentacoes;

        int totalEstoque = produtos.Sum(p => p.QuantidadeEstoque);
        Produto? menorEstoque = produtos.Count > 0 ? produtos.MinBy(p => p.QuantidadeEstoque) : null;
        Produto? maiorEstoque = produtos.Count > 0 ? produtos.MaxBy(p => p.QuantidadeEstoque) : null;


        int totalEntradas = movimentos
            .Where(m => m.Tipo == TipoMovimentacao.ENTRADA)
            .Sum(m => m.Quantidade);

        int totalSaidas = movimentos
            .Where(m => m.Tipo == TipoMovimentacao.SAIDA)
            .Sum(m => m.Quantidade);

        Console.WriteLine("=== RELATÓRIO SIMPLES ===");

        foreach (var p in produtos)
        {
            int entradas = movimentos
                .Where(m => m.CodigoProduto == p.Codigo && m.Tipo == TipoMovimentacao.ENTRADA)
                .Sum(m => m.Quantidade);

            int saídas = movimentos
                .Where(m => m.CodigoProduto == p.Codigo && m.Tipo == TipoMovimentacao.SAIDA)
                .Sum(m => m.Quantidade);

            Console.WriteLine($"Produto: {p.Nome} (Código {p.Codigo})");
            Console.WriteLine($"  Entradas: {entradas}");
            Console.WriteLine($"  Saídas: {saídas}");
            Console.WriteLine($"  Estoque atual: {p.QuantidadeEstoque}");
            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine($"Total de produtos: {produtos.Count}");
        Console.WriteLine($"Total em estoque: {totalEstoque}");
        Console.WriteLine($"Produto menor estoque: {menorEstoque?.Nome} ({menorEstoque?.QuantidadeEstoque})");
        Console.WriteLine($"Produto maior estoque: {maiorEstoque?.Nome} ({maiorEstoque?.QuantidadeEstoque})");
        Console.WriteLine($"Total de entradas: {totalEntradas}");
        Console.WriteLine($"Total de saídas: {totalSaidas}");
        Console.WriteLine("Digite qualquer tecla para ir ao menu");
        Console.ReadKey();
    }

    public void RelatorioDetalhado()
    {
        var produtos = produtoService.ConsultarEstoque();
        var movimentos = produtoService.Movimentacoes;

        Console.WriteLine("=== RELATÓRIO DETALHADO ===");

        foreach (var p in produtos)
        {
            Console.WriteLine($"Produto: {p.Nome} (Código {p.Codigo})");

            // Lista apenas as movimentações deste produto
            var movsProduto = movimentos
                .Where(m => m.CodigoProduto == p.Codigo)
                .OrderBy(m => m.IdMovimentacao) // <-- Ordena pelo ID da movimentação
                .ToList();

            int saldo = 0;

            foreach (var mov in movsProduto)
            {
                int quantidade = mov.Quantidade * (mov.Tipo == TipoMovimentacao.ENTRADA ? 1 : -1);
                saldo += quantidade;

                string sinal = quantidade > 0 ? "+" : "";
                Console.WriteLine($"  [ID {mov.IdMovimentacao}] {mov.Tipo}  {sinal}{quantidade}  (Saldo: {saldo})");
            }

            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine("Digite qualquer tecla para ir ao menu");
        Console.ReadKey();
    }
}
