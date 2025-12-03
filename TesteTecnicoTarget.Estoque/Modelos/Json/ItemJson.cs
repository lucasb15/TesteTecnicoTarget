using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TesteTecnicoTarget.Estoque.Modelos.Json;

public class ItemJson
{
    public int codigoProduto {  get; set; }
    public string descricaoProduto { get; set; }
    public int estoque { get; set; }
}