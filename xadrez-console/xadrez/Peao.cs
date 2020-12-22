using System;
using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private readonly PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "P";
        }

        private bool ExisteAdversario(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // Coordenadas possiveis do Peão
            int[,] coordernadas;
            int[,] coordEnPassan;
            if (cor == Cor.Branca)
            {
                coordernadas = new int[,] { { -1, 0 }, { -2, 0 }, { -1, 0 }, { +1, -1 }, { -1, +1 } };
                coordEnPassan = new int[,] { { +3, 0 }, { 0, -1 }, { -1, 0 }, { 0, +1 }, { -1, 0 } };
            }
            else
            {
                coordernadas = new int[,] { { +1, 0 }, { +2, 0 }, { +1, 0 }, { +1, -1 }, { +1, +1 } };
                coordEnPassan = new int[,] { { +4, 0 }, { 0, -1 }, { +1, 0 }, { 0, +1 }, { +1, 0 } };
            }

            pos.DefinirValores(posicao.Linha + coordernadas[0, 0], posicao.Coluna);
            if (tab.posicaoValida(pos) && Livre(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha + coordernadas[1, 0], posicao.Coluna);
            Posicao p2 = new Posicao(posicao.Linha + coordernadas[2, 0], posicao.Coluna);
            if (tab.posicaoValida(p2) && Livre(p2) && tab.posicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha + coordernadas[3, 0], posicao.Coluna + coordernadas[3, 1]);
            if (tab.posicaoValida(pos) && ExisteAdversario(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha + coordernadas[4, 0], posicao.Coluna + coordernadas[4, 1]);
            if (tab.posicaoValida(pos) && ExisteAdversario(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #jogadaespecial en passant
            if (posicao.Linha == coordEnPassan[0, 0])
            {
                Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna + coordEnPassan[1, 1]);
                if (tab.posicaoValida(esquerda) && ExisteAdversario(esquerda) && tab.peca(esquerda) == partida.VulneravelEnPassant)
                {
                    mat[esquerda.Linha + coordEnPassan[2, 0], esquerda.Coluna] = true;
                }
                Posicao direita = new Posicao(posicao.Linha, posicao.Coluna + coordEnPassan[3, 1]);
                if (tab.posicaoValida(direita) && ExisteAdversario(direita) && tab.peca(direita) == partida.VulneravelEnPassant)
                {
                    mat[direita.Linha + coordEnPassan[4, 0], direita.Coluna] = true;
                }
            }

            return mat;
        }

    }
}
