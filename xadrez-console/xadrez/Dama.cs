using System;
using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "D";
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            bool[,] aux = new bool[tab.linhas, tab.colunas];

            mat = Movimentos.Diagonais(tab, cor, mat, posicao.Linha, posicao.Coluna);
            aux = Movimentos.Horizontais(tab, cor, aux, posicao.Linha, posicao.Coluna);

            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (aux[i, j])
                    {
                        mat[i, j] = aux[i, j];
                    }
                }
            }
            return mat;
        }
    }
}
