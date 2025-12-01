using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoTarget.Vendas.Modelos;

internal class Venda
{
    public Vendedor Vendedor { get; set; }
    public decimal ValorVenda { get; set; }
    public decimal Comissao { get; set; }
    public Venda(Vendedor vendedor, decimal valorVenda, decimal comissao)
    {
        Vendedor = vendedor;
        ValorVenda = valorVenda;
        Comissao = comissao;
    }
}
