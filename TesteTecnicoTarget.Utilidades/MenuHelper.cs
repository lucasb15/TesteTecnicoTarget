namespace TesteTecnicoTarget.Utilidades;

public class MenuHelper
{
    public static void ExibirTitulo(string texto)
    {
        int largura = 50;
        int espacos = (largura - texto.Length) / 2;

        Console.WriteLine(new string('*', largura));
        Console.WriteLine("*" + new string(' ', espacos - 1) + texto + new string(' ', largura - texto.Length - espacos - 1) + "*");
        Console.WriteLine(new string('*', largura));
    }

    public static int LerOpcao()
    {
        Console.Write("\nDigite uma opção: ");
        string entrada = Console.ReadLine()!;

        if (int.TryParse(entrada, out int opcao))
            return opcao;

        return -1;
    }
}
