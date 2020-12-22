using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString() => "B";


        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            mat = Movimentos.Diagonais(tab, cor, mat, posicao.Linha, posicao.Coluna);

            return mat;
        }
    }
}
