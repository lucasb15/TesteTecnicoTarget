using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Estoque.Servicos;
using TesteTecnicoTarget.Utilidades;

namespace TesteTecnicoTarget.Estoque.Operacoes;

internal class SaidaDeProdutos
{
    public static void Executar(ProdutoService service)
    {
        while (true)
        {
            Console.Clear();

            MenuHelper.ExibirTitulo("Entrada Estoque");
            Console.WriteLine("1. Saida Manual.");
            Console.WriteLine("2. Saida Importação.");
            Console.WriteLine("0. Sair.");

            var opcao = MenuHelper.LerOpcao();

            switch (opcao)
            {
                case 0:
                    return;
                case 1:
                    SaidaManual(service);
                    break;
                case 2:
                    SaidaImportacao(service);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    public static void SaidaManual(ProdutoService service)
    {
        Manual.Executar(service, "saida");
    }

    public static void SaidaImportacao(ProdutoService service)
    {
        Importado.Executar(service, "saida");
    }
}
