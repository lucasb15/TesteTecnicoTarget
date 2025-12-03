using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoTarget.Estoque.Modelos;

internal class Produto
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public int QuantidadeEstoque { get; private set; } = 0;

    public Produto(int codigo, string nome)
    {
        Codigo = codigo;
        Nome = nome;
    }

    public void Adicionar(int quantidade) => QuantidadeEstoque += quantidade;
    public bool Remover(int quantidade)
    {
        if (QuantidadeEstoque < quantidade)
            return false;

        QuantidadeEstoque -= quantidade;
        return true;
    }
}
