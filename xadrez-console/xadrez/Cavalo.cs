using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString() => "C";

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // coordernadas possiveis do Cavalo
            int[,] coordernadas = new int[,] { { -1, -2 }, { -1, +2 }, { +1, -2 }, { +1, +2 }, { -2, -1 }, { -2, +1 }, { +2, -1 }, { +2, +1 } };
            for (int i = 0; i < coordernadas.Length / 2; i++)
            {
                for (int j = 0; j < coordernadas.Rank; j++)
                {
                    pos.DefinirValores(posicao.Linha + coordernadas[i, 0], posicao.Coluna + coordernadas[i, 1]);
                    if (tab.posicaoValida(pos) && PodeMover(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
