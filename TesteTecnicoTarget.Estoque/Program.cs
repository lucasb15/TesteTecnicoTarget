using TesteTecnicoTarget.Estoque.Operacoes;
using TesteTecnicoTarget.Estoque.Servicos;
using TesteTecnicoTarget.Utilidades;

class Program
{
    static void Main()
    {
        ExibirMenu();
    }

    static void ExibirMenu()
    {
        var produtoService = new ProdutoService();
        var relatorioService = new RelatorioService(produtoService);

        while (true)
        {
            Console.Clear();
            MenuHelper.ExibirTitulo("Estoque");
            Console.WriteLine("1. Entrada de Produtos");
            Console.WriteLine("2. Saída de Produtos");
            Console.WriteLine("3. Consultar Nível de Estoque");
            Console.WriteLine("0. Sair");
            var opcao = MenuHelper.LerOpcao();

            switch(opcao)
            {
                case 0:
                    return;
                case 1:
                    EntradaDeProdutos.Executar(produtoService);
                    break;
                case 2:
                    SaidaDeProdutos.Executar(produtoService);
                    break;
                case 3:
                    ConsultarNivelEstoque.Executar(relatorioService);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

    }
}