using TesteTecnicoTarget.Utilidades;
using TesteTecnicoTarget.Vendas.Comissao;
using TesteTecnicoTarget.Vendas.Modelos;

class Program
{
    static void Main()
    {
        ExibirMenu();
    }

    static void ExibirMenu()
    {
        while (true)
        {
            Console.Clear();
            MenuHelper.ExibirTitulo("Vendas");
            Console.WriteLine("1. Importar Vendas");
            Console.WriteLine("2. Gerar Relatório de Vendas");
            Console.WriteLine("0. Sair");
            var opcao = MenuHelper.LerOpcao();
            switch (opcao)
            {
                case 0:
                    return;

                case 1:
                    ImportarVendas.Executar();
                    break;

                case 2:
                    GerarRelatorio.Executar();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}