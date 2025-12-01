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
                if (string.IsNullOrWhiteSpace(v.Vendedor))
                {
                    Console.WriteLine("Venda com vendedor inválido ignorada.");
                    continue;
                }

                var vendedor = VendedorRepositorio.GetOrCreate(v.Vendedor);
                vendedor.AdicionarVenda(v.Valor);
            }

            Console.WriteLine($"Importação concluída. Vendedores: {VendedorRepositorio.Vendedores.Count}");
            foreach (var vend in VendedorRepositorio.Vendedores)
            {
                Console.WriteLine($"{vend.Nome} - Total vendas: {vend.TotalVendas:C} - Total comissão: {vend.TotalComissao:C}");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}
