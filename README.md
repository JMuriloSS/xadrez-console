# XADREZ-CONSOLE

Projeto para fixação dos conceitos do Curso C# Completo 2020 Programação Orientada a Obejtos + Projetos.
Desenvolvido no ambiente com Win 10 x86, Visual Studio 2019 v16.8.3 Communit.

Efetuei alguns ajustes para exercício:

1) Criei a classe Movimentos.cs com os métodos Diagonais e Horizontais, para reaproveitamento de código e otimização das coordenadas em array;
	a) A classe Torre.cs acessa o método Horizontais;
	b) A classe Bispo.cs acessa o método Diagonais;
	c) A classe Dama acessa os métodos Horizontais e Diagonais;
	d) O método PodeMover foi removido das classes acima, foi concentrado na classe Movimentos.cs.

2) Otimizada classe Peao.cs com array de coordenadas para peças brancas e pretas e reproveitamento de código;

3) Otimizada classe Cavalo.cs com array de coordenadas para peças brancas e pretas e reproveitamento de código;

4) Otimização da montagem do tabuleiro com array de coordenadas para peças brancas e pretas, redução e reproveitamento de código.

Meus agradecimentos ao Prof. Nélio pelo excelente Curso.
