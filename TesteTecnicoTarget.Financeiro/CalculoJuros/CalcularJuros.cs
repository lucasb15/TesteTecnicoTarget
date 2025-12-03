using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Utilidades;

namespace TesteTecnicoTarget.Financeiro.CalculoJuros;

internal class CalcularJuros
{
    private const decimal TaxaJurosPadrao = 2.5m;
    public static void Executar(bool usarJurosPadrao = true)
    {
        Console.Clear();
        string titulo = usarJurosPadrao ? "Cálculo de Juros Padrão" : "Cálculo de Juros Personalizados";
        MenuHelper.ExibirTitulo(titulo);

        Console.Write("Digite o valor do titulo: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal valorInicial) || valorInicial < 0)
        {
            MensagemErro("Valor inicial inválido. Pressione qualquer tecla para voltar ao menu.");
            return;
        }

        Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataVencimento))
        {
            MensagemErro("Data de vencimento inválida. Pressione qualquer tecla para voltar ao menu.");
            return;
        }

        DateTime dataAtual = DateTime.Now;
        if (dataAtual <= dataVencimento)
        {
            MensagemErro("O título não está vencido. Pressione qualquer tecla para voltar ao menu.");
            return;
        }
        decimal taxaMensal = TaxaJurosPadrao;
        if (!usarJurosPadrao)
        {
            Console.Write("Percentual de juros ao mês (Exemplo 1,5%): ");
            string entrada = Console.ReadLine()?.Trim();

            // Se tiver ponto, troca por vírgula, tive que fazer isso pois se o usuário digitar com ponto, o parse falha e o 1.0 vira 10%, isso considerando que está tudo fixado para o BR (Idioma e Região)
            // Preciso mudar para aceitar de qualquer região
            entrada = entrada.Replace('.', ',');

            if (!decimal.TryParse(entrada, out decimal taxaInformada) || taxaInformada < 0)
            {
                MensagemErro("Percentual de juros inválido. Pressione qualquer tecla para voltar ao menu.");
                return;
            }

            taxaMensal = taxaInformada;
        }

        int diasAtraso = (dataAtual - dataVencimento).Days;

        Calcular(diasAtraso: diasAtraso, taxaJurosMensal: taxaMensal, valorInicial: valorInicial);
    }

    public static void MensagemErro(string msg)
    {
        Console.WriteLine($"\n{msg}");
        Console.ReadKey();
    }

    public static void Calcular(int diasAtraso, decimal taxaJurosMensal, decimal valorInicial)
    {
        decimal taxaDiaria = (taxaJurosMensal / 30m) / 100m;
        decimal juros = valorInicial * taxaDiaria * diasAtraso;
        decimal valorTotal = valorInicial + juros;

        Console.WriteLine($"\nValor Inicial: {valorInicial:C}");
        Console.WriteLine($"Dias em Atraso: {diasAtraso} dias");
        Console.WriteLine($"Juros Aplicados: {juros:C}");
        Console.WriteLine($"Valor Total a Pagar: {valorTotal:C}");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}
