using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteTecnicoTarget.Vendas.Modelos;

internal static class VendedorRepositorio
{
    private static readonly List<Vendedor> vendedores = new();

    public static IReadOnlyList<Vendedor> Vendedores => vendedores.AsReadOnly();

    public static Vendedor GetOrCreate(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do vendedor inválido.", nameof(nome));

        var vendedor = vendedores.FirstOrDefault(v => string.Equals(v.Nome, nome, StringComparison.OrdinalIgnoreCase));
        if (vendedor is null)
        {
            vendedor = new Vendedor(nome.Trim());
            vendedores.Add(vendedor);
        }

        return vendedor;
    }

    public static void Clear() => vendedores.Clear();
}
