using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoTarget.Vendas.Modelos;

internal class Vendedor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    private readonly List<Venda> vendas = new(); // Lista privada de vendas

    public IReadOnlyList<Venda> Vendas => vendas.AsReadOnly(); // Expor lista de vendas como somente leitura

    public decimal TotalVendas => vendas.Sum(v => v.ValorVenda); // Calcular total de vendas
    public decimal TotalComissao => vendas.Sum(v => v.Comissao); // Calcular total de comissão

    public Vendedor(string nome)
    {
        Nome = nome;
    }


    public void AdicionarVenda(decimal valorVenda)
    {
        if (valorVenda < 0) throw new ArgumentOutOfRangeException(nameof(valorVenda));

        decimal valorComissao = 0;
        if (valorVenda > 500)
            valorComissao = valorVenda * (5 / 100m); // Valor de comissão 5%
        else if (valorVenda > 100)
            valorComissao = valorVenda * (1 / 100m); // Valor de comissão 1%

        vendas.Add(new Venda(this, valorVenda, valorComissao));
    }
}
