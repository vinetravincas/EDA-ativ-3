using System;
using eda.arvb;

namespace eda
{
	class Programa
	{
		static void Main(string[] args)
		{
			Console.WriteLine("\n\n\t\tARVORES");

			ArvoreB arvoreBinaria = new ArvoreB();
			ArvoreAVL arvoreAVL= new ArvoreAVL(); 
			
			int op, a,b;
			
			while (true)
			{
				Console.WriteLine("\n1 - Inserir na Arvore BINARIA");
				Console.WriteLine("2 - Exibir Arvore BINARIA");
				Console.WriteLine("3 - Remover um no Arvore BiNARIA");
				Console.WriteLine("4 - Buscar no Arvore BiNARIA");
				Console.WriteLine("5 - Inserir na Arvore AVL");
				Console.WriteLine("6 - Exibir Arvore AVL");
				Console.WriteLine("7 - Remover um no Arvore AVL");
				Console.WriteLine("8 - Buscar no Arvore AVL");
				Console.WriteLine("9 - Sair");
				Console.Write("escolha uma op: ");
				op = Convert.ToInt32(Console.ReadLine());

				if (op == 9)
					break;

				switch (op)
				{
					case 1:
						Console.Write("\n\tBINARIA\n\nDigite o valor: ");
						a = Convert.ToInt32(Console.ReadLine());
						arvoreBinaria.Inserir(a);
						
						
						break;

					case 2:
						Console.Write("\n\tARVORE BINARIA\n\n");
						arvoreBinaria.Exibir();
						break;

					case 3:
						Console.Write("\n\tBINARIA\n\nNo a ser removido: ");
						b = Convert.ToInt32(Console.ReadLine());
						arvoreBinaria.Remover(b);
						break;

					case 4:
						Console.Write("\n\tBINARIA\n\nDigite o valor: ");
						a = Convert.ToInt32(Console.ReadLine());
						if(arvoreBinaria.Buscar(a)==1){
							Console.WriteLine("\n\tVALOR PRESENTE NA ARVORE!\n");
						}else{
							Console.WriteLine("\n\tVALOR NAO ENCONTRADO!\n");
						}
						
						break;
					case 5:
					    Console.Write("\n\tAVL\n\nDigite o valor: ");
						a = Convert.ToInt32(Console.ReadLine());
						arvoreAVL.InserirAVL(a);						
						break;
					case 6:
					    Console.Write("\n\tARVORE AVL\n\n");
						arvoreAVL.Exibir();
						break;
					case 7:
					    Console.Write("\n\tAVL\n\nNo a ser removido: ");
						a = Convert.ToInt32(Console.ReadLine());
						arvoreAVL.Removeravl(a);
						
						break;	
					case 8:
						Console.Write("\n\tAVL\n\nDigite o valor: ");
						a = Convert.ToInt32(Console.ReadLine());
						if(arvoreAVL.Buscar(a)==1){
							Console.WriteLine("\n\tVALOR PRESENTE NA ARVORE!\n");
						}else{
							Console.WriteLine("\n\tVALOR NAO ENCONTRADO!\n");
						}
						break;
				}
			}
			
			

		}
	}
}