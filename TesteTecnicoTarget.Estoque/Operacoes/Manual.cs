using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Estoque.Servicos;
using TesteTecnicoTarget.Utilidades;

namespace TesteTecnicoTarget.Estoque.Operacoes;

internal class Manual
{
    public static void Executar(ProdutoService service, string tipo)
    {
        Console.Clear();

        bool entrada = tipo == "entrada";
        bool saida = tipo == "saida";

        MenuHelper.ExibirTitulo(entrada ? "Entrada Manual" : "Saída Manual");

        Console.Write("Digite o código do produto: ");
        if (!int.TryParse(Console.ReadLine(), out int codigo) || codigo <= 0)
        {
            Console.WriteLine("Código inválido!");
            Console.ReadKey();
            return;
        }

        var produto = service.BuscarProduto(codigo);

        // Produto não existe → perguntar se deseja criar
        if (produto == null)
        {
            while (true)
            {
                Console.Write("Produto não encontrado. Deseja criar? (s/n): ");
                var opcao = Console.ReadLine().Trim().ToLower();

                if (opcao == "s")
                {
                    Console.Write("Nome do Produto: ");
                    var nome = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        Console.WriteLine("Nome inválido!");
                        Console.ReadKey();
                        return;
                    }

                    produto = service.CriarProduto(codigo, nome);
                    Console.WriteLine("Produto criado com sucesso!");
                    break;
                }
                else if (opcao == "n")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }
        }

        Console.Write(entrada ? "Quantidade a adicionar: " : "Quantidade a remover: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida!");
            Console.ReadKey();
            return;
        }

        int novoEstoque = entrada
            ? produto.QuantidadeEstoque + quantidade
            : produto.QuantidadeEstoque - quantidade;

        Console.Clear();
        Console.WriteLine($"Código: {produto.Codigo}");
        Console.WriteLine($"Nome:  {produto.Nome}");
        Console.WriteLine($"Estoque Atual: {produto.QuantidadeEstoque}");
        Console.WriteLine($"Novo Estoque:  {novoEstoque}");

        Console.Write(entrada ? "Confirmar entrada? (s/n): " : "Confirmar saída? (s/n): ");
        var salvar = Console.ReadLine().Trim().ToLower();

        if (salvar == "s")
        {
            bool sucesso;

            if (entrada)
            {
                sucesso = service.AdicionarProduto(produto, quantidade);
                service.ProximoId();
            }
            else
            {
                sucesso = service.RemoverProduto(produto, quantidade);
                if (!sucesso)
                {
                    Console.WriteLine("Falha: estoque insuficiente para realizar a saída.");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Estoque atualizado com sucesso!");
        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
