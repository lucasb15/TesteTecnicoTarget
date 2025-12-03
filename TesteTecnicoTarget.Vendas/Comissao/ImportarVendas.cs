using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Utilidades;
using TesteTecnicoTarget.Vendas.Modelos;

namespace TesteTecnicoTarget.Vendas.Comissao;

internal class ImportarVendas
{
    public static void Executar()
    {
        while(true)
        {
            Console.Clear();
            MenuHelper.ExibirTitulo("Importar Vendas");
            Console.WriteLine("1 - Lançamento manual");
            Console.WriteLine("2 - Importar de arquivo JSON");
            Console.WriteLine("0 - Voltar ao menu principal");
            var opcao = MenuHelper.LerOpcao();
            switch (opcao)
            {
                case 1:
                    LancamentoManual();
                    break;
                case 2:
                    ImportarDados();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    public static void LancamentoManual()
    {
        while (true)
        {
            Console.Clear();

            // Solicitar nome do vendedor
            Console.Write("Nome do vendedor: ");
            var nomeVendedor = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nomeVendedor))
            {
                Console.WriteLine("Nome do vendedor inválido!");
                Console.ReadKey();
                return;
            }
            var vendedor = VendedorRepositorio.GetOrCreate(nomeVendedor);

            // Solicitar valor da venda
            Console.Write("Valor da venda: ");
            var valorInput = Console.ReadLine();
            if (!decimal.TryParse(valorInput, out var valorVenda) || valorVenda <= 0)
            {
                Console.WriteLine("Valor da venda inválido!");
                Console.ReadKey();
                return;
            }
            vendedor.AdicionarVenda(valorVenda);
            Console.WriteLine($"Venda de {valorVenda:C} registrada para {vendedor.Nome}.");

            // Perguntar se deseja lançar outra venda
            // Caso a resposta seja diferente de "S" ou "s", sair do loop
            Console.WriteLine("Deseja lançar outra venda? (S/N)");
            var resposta = Console.ReadLine();
            if (!string.Equals(resposta, "S", StringComparison.OrdinalIgnoreCase))
                break;
        }
    }

    public static void ImportarDados()
    {
        Console.Clear();
        var dados = ImportarJson.Importar<VendasJson>();

        if (dados?.vendas is null)
        {
            Console.WriteLine("JSON inválido!");
            Console.ReadKey();
        }
        else
        {
            foreach (var v in dados.vendas)
            {
                // Validar dados do vendedor e valor
                if (string.IsNullOrWhiteSpace(v.Vendedor))
                {
                    Console.WriteLine("Venda com vendedor inválido ignorada.");
                    continue;
                }

                if (v.Valor <= 0)
                {
                    Console.WriteLine($"Venda do vendedor {v.Vendedor} com valor inválido ignorada.");
                    continue;
                }

                // Adicionar venda ao vendedor
                var vendedor = VendedorRepositorio.GetOrCreate(v.Vendedor);
                vendedor.AdicionarVenda(v.Valor);
            }

            Console.WriteLine($"Importação concluída.");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}
