using System.Text.Json;

namespace TesteTecnicoTarget.Utilidades;

public class ImportarJson
{
    public static T? Importar<T>()
    {
        Console.WriteLine("Qual o caminho do arquivo?");
        string caminho = Console.ReadLine();
        var json = File.ReadAllText(caminho);

        var opcoes = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<T>(json,opcoes);
    }
}
