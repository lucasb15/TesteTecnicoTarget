using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Estoque.Modelos.Json;
using TesteTecnicoTarget.Estoque.Servicos;
using TesteTecnicoTarget.Utilidades;

namespace TesteTecnicoTarget.Estoque.Operacoes;

internal class Importado
{
    public static void Executar(ProdutoService service, string tipo)
    {
        Console.Clear();
        var dados = ImportarJson.Importar<ProdutoJson>();

        if (dados?.estoque is null)
        {
            Console.WriteLine("JSON inválido!");
            Console.ReadKey();
            return;
        }

        bool entrada = tipo == "entrada";
        bool saida = tipo == "saida";

        foreach (var p in dados.estoque)
        {
            // --- Validações Gerais ---
            if (p.codigoProduto <= 0)
            {
                Console.WriteLine("Produto com código inválido ignorado.");
                continue;
            }

            // Entrada: quantidade não pode ser negativa
            if (entrada && p.estoque < 0)
            {
                Console.WriteLine($"Quantidade inválida para {p.codigoProduto} (entrada). Ignorado.");
                continue;
            }

            // Entrada: descrição obrigatória
            if (entrada && string.IsNullOrWhiteSpace(p.descricaoProduto))
            {
                Console.WriteLine($"Produto {p.codigoProduto} ignorado (nome vazio).");
                continue;
            }

            // --- Busca ou cria ---
            var produto = service.BuscarProduto(p.codigoProduto)
                       ?? service.CriarProduto(p.codigoProduto, p.descricaoProduto);

            // --- Entrada ---
            if (entrada)
            {
                service.AdicionarProduto(produto, p.estoque);

                Console.WriteLine(
                    $"[ENTRADA] Código: {p.codigoProduto} | Produto: {p.descricaoProduto} | +" +
                    $"{p.estoque} (Novo estoque: {produto.QuantidadeEstoque})"
                );

                continue;
            }

            // --- Saída ---
            if (saida)
            {
                if (!service.RemoverProduto(produto, p.estoque))
                {
                    Console.WriteLine(
                        $"[FALHA SAÍDA] Código {p.codigoProduto} | Tentou remover: {p.estoque} | " +
                        $"Estoque atual: {produto.QuantidadeEstoque}"
                    );
                    continue;
                }

                Console.WriteLine(
                    $"[SAÍDA] Código: {p.codigoProduto} | Produto: {produto.Nome} | -" +
                    $"{p.estoque} (Restante: {produto.QuantidadeEstoque})"
                );
            }
        }
        Console.WriteLine("\nProcesso de importação concluído!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}