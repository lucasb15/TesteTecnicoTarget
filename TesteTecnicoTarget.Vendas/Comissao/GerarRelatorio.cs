using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Utilidades;
using TesteTecnicoTarget.Vendas.Modelos;

namespace TesteTecnicoTarget.Vendas.Comissao;

internal class GerarRelatorio
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1. Relatório de Comissão por Vendedor (Resumido)");
        Console.WriteLine("2. Relatório de Comissão por Vendedor (Detalhado)");
        var opcao = MenuHelper.LerOpcao();

        switch (opcao)
        {
            case 1:
                RelatorioComissaoVendedor();
                break;
            case 2:
                RelatorioComissaoVendedor(false);
                break;
            default:
                Console.WriteLine("Opção inválida. Retornando ao menu principal.");
                break;
        }
    }

    public static void RelatorioComissaoVendedor(bool resumido = true)
    {
        Console.Clear();

        var vendedores = VendedorRepositorio.Vendedores;

        if (vendedores == null || vendedores.Count == 0)
        {
            Console.WriteLine("Nenhum vendedor encontrado. Importe vendas antes de gerar o relatório.");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            return;
        }

        if (!resumido)
        {
            Console.WriteLine("Relatório de Comissão por Vendedor (Detalhado)");
            Console.WriteLine(new string('-', 80));

            foreach (var v in vendedores)
            {
                Console.WriteLine($"Vendedor: {v.Nome}");
                Console.WriteLine($"Total Vendas: {v.TotalVendas:C}    Total Comissão: {v.TotalComissao:C}");

                if (v.Vendas.Count == 0)
                {
                    Console.WriteLine("  (sem vendas)");
                }
                else
                {
                    Console.WriteLine($"  {"Índice",6} {"Valor Venda",15} {"Comissão",15}");
                    Console.WriteLine(new string('-', 80));
                    int i = 1;
                    foreach (var venda in v.Vendas)
                    {
                        Console.WriteLine($"  {i,6} {venda.ValorVenda,15:C} {venda.Comissao,15:C}");
                        i++;
                    }
                }

                Console.WriteLine(new string('-', 80));
            }
        }

        Console.WriteLine("Relatório de Comissão por Vendedor (Resumido)");
        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"{"Vendedor",-30} {"Total Vendas",15} {"Total Comissão",15}");
        Console.WriteLine(new string('-', 60));

        foreach (var v in vendedores)
        {
            Console.WriteLine($"{v.Nome,-30} {v.TotalVendas,15:C} {v.TotalComissao,15:C}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}
