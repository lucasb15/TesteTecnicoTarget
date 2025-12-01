using TesteTecnicoTarget.Financeiro.CalculoJuros;
using TesteTecnicoTarget.Utilidades;

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
            MenuHelper.ExibirTitulo("Financeiro");

            Console.WriteLine("1. Calcular Juros padrão");
            Console.WriteLine("2. Calcular Juros personalizados");
            Console.WriteLine("0. Sair");

            var opcao = MenuHelper.LerOpcao();

            switch(opcao)
            {
                case 0:
                    return;
                case 1:
                    CalcularJuros.Executar();
                    break;
                case 2:
                    CalcularJuros.Executar(false);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

    }

}