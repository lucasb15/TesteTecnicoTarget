using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTarget.Estoque.Modelos.Enum;

namespace TesteTecnicoTarget.Estoque.Modelos;

internal class Movimentacao
{
    public int IdMovimentacao { get; set; }
    public int CodigoProduto { get; set; }
    public TipoMovimentacao Tipo { get; set; }
    public int Quantidade { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
}
