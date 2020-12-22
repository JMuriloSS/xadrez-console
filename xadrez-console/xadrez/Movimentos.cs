using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    class Movimentos
    {
        public static bool PodeMover(Tabuleiro tab, Cor cor, Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public static bool[,] Diagonais(Tabuleiro tab, Cor cor, bool[,] mat, int linha, int coluna)
        {
            Posicao pos = new Posicao(0, 0);

            // Movimentos diagonais Noroeste, Nordeste, Sudeste e Sudoeste
            int[,] coordernadas = new int[,] { { -1, -1 }, { -1, +1 }, { +1, +1 }, { +1, -1 } };
            for (int i = 0; i < coordernadas.Length / 2; i++)
            {
                for (int j = 0; j < coordernadas.Rank; j++)
                {
                    pos.DefinirValores(linha + coordernadas[i, 0], coluna + coordernadas[i, 1]);
                    while (tab.posicaoValida(pos) && PodeMover(tab, cor, pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                        if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                        {
                            break;
                        }
                        pos.DefinirValores(pos.Linha + coordernadas[i, 0], pos.Coluna + coordernadas[i, 1]);
                    }
                }
            }

            return mat;
        }


        public static bool[,] Horizontais(Tabuleiro tab, Cor cor, bool[,] mat, int linha, int coluna)
        {
            Posicao pos = new Posicao(0, 0);

            // Movimentos Horizontais Norte, Este, Sul e Oeste
            int[,] coordernadas = new int[,] { { -1, 0 }, { +1, 0 }, { 0, +1 }, { 0, -1 } };
            for (int i = 0; i < coordernadas.Length / 2; i++)
            {
                for (int j = 0; j < coordernadas.Rank; j++)
                {
                    pos.DefinirValores(linha + coordernadas[i, 0], coluna + coordernadas[i, 1]);
                    while (tab.posicaoValida(pos) && PodeMover(tab, cor, pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                        if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                        {
                            break;
                        }
                        pos.DefinirValores(pos.Linha + coordernadas[i, 0], pos.Coluna + coordernadas[i, 1]);
                    }
                }
            }

            return mat;
        }
    }
}
