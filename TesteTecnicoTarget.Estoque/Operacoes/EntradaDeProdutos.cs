using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Estoque.Modelos.Json;
using TesteTecnicoTarget.Estoque.Servicos;
using TesteTecnicoTarget.Utilidades;

namespace TesteTecnicoTarget.Estoque.Operacoes;

internal class EntradaDeProdutos
{
    public static void Executar(ProdutoService service)
    {
        while (true)
        {
            Console.Clear();

            MenuHelper.ExibirTitulo("Entrada Estoque");
            Console.WriteLine("1. Entrada Manual.");
            Console.WriteLine("2. Entrada Importação.");
            Console.WriteLine("0. Sair.");

            var opcao = MenuHelper.LerOpcao();

            switch (opcao)
            {
                case 0:
                    return;
                case 1:
                    EntradaManual(service);
                    break;
                case 2:
                    EntradaImportacao(service);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    public static void EntradaManual(ProdutoService service)
    {
        Manual.Executar(service, "entrada");
    }

    public static void EntradaImportacao(ProdutoService service)
    {
        Importado.Executar(service, "entrada");
    }
}
