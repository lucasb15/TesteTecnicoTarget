using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Estoque.Servicos;
using TesteTecnicoTarget.Utilidades;

namespace TesteTecnicoTarget.Estoque.Operacoes;

internal class ConsultarNivelEstoque
{
    public static void Executar(RelatorioService relatorioService)
    {
        while (true)
        {
            Console.Clear();

            MenuHelper.ExibirTitulo("Relatórios");
            Console.WriteLine("1. Relatorio Simples.");
            Console.WriteLine("2. Relatorio Detalhado.");
            Console.WriteLine("0. Sair.");

            var opcao = MenuHelper.LerOpcao();

            switch (opcao)
            {
                case 0:
                    return;
                case 1:
                    Console.Clear();
                    relatorioService.RelatorioSimples();
                    break;
                case 2:
                    Console.Clear();
                    relatorioService.RelatorioDetalhado();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
