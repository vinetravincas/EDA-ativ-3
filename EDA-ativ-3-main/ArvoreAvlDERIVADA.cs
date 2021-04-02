using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using eda.arvb;

namespace eda
{
	class ArvoreAVL : ArvoreB
	{
		static bool alto;
		static bool baixo;

		private NoAVL raiz;
        public ArvoreAVL()
        {
            this.raiz=null;
        }
        
        public void Inserir(int x)
		{
			raiz = Inserir(raiz, x);
		}
		
		private NoAVL Inserir(NoAVL no, int x)
		{
			if (no == null)
			{
				no = new NoAVL(x);
				alto = true;
			}
			else if (x < no.info)
			{
				no.noEsquerdo = Inserir(no.noEsquerdo, x);

				if (alto == true)
					no = ver_subesq_in(no);

			}
			else if (x > no.info)
			{
				no.noDireito = Inserir(no.noDireito, x);

				if (alto == true)
					no = ver_subdir_in(no);

			}
			else
			{
				Console.WriteLine(x +  " ja esta presente na arvore");
				alto = false;
			}

			return no;
		}
		
		
		
		private NoAVL ver_subesq_in(NoAVL no)
		{
			switch (no.fatorb) 
			{
				
				case 0:
					no.fatorb = 1; 
					break;

				
				case -1:
					no.fatorb = 0; 
					alto = false;
					break;
				
				case 1:
					no = bal_esq_in(no); 
					alto = false;
					break;
			}

			return no;
		}

		private NoAVL ver_subdir_in(NoAVL no)
		{
			switch (no.fatorb) 
			{
				
				case 0:
					no.fatorb = -1; 
					break;
				
				case 1:
					no.fatorb = 0; 
					alto = false;
					break;
				
				case -1:
					no = bal_dir_in(no);  
					alto = false;
					break;
			}

			return no;
		}
		private NoAVL bal_esq_in(NoAVL no)
		{
			NoAVL a, b;

			a = no.noEsquerdo;
			
			if (a.fatorb == 1)
			{
				no.fatorb = 0;
				a.fatorb = 0;
				no = RD(no);
			}
			else 
			{
				b = a.noDireito;

				switch (b.fatorb)
				{
					
					case 1:
						no.fatorb = -1;
						a.fatorb = 0;
						break;
					
					case -1:
						no.fatorb = 0;
						a.fatorb = 1;
						break;
					
					case 0:
						no.fatorb = 0;
						a.fatorb = 0;
						break;
				}

				b.fatorb = 0;
				no.noEsquerdo = RE(a);
				no = RD(no);
			}

			return no;
		}

		private NoAVL bal_dir_in(NoAVL no)
		{
			NoAVL a, b;

			a = no.noDireito;

			if (a.fatorb == -1)
			{
				no.fatorb = 0;
				a.fatorb = 0;
				no = RE(no);
			}
			else 
			{
				b = a.noEsquerdo;

				switch (b.fatorb)
				{
					case -1:
						no.fatorb = 1;
						a.fatorb = 0;
						break;					
					case 1:
						no.fatorb = 0;
						a.fatorb = -1;
						break;
					case 0:
						no.fatorb = 0;
						a.fatorb = 0;
						break;
				}

				b.fatorb = 0;
				no.noDireito = RD(a);
				no = RE(no);
			}

			return no;			
		}		

		private NoAVL RD(NoAVL no)
		{
			NoAVL noEsquerdo = no.noEsquerdo;
			no.noEsquerdo = noEsquerdo.noDireito;
			noEsquerdo.noDireito = no;

			return noEsquerdo;
		}

		private NoAVL RE(NoAVL no)
		{
			NoAVL noDireito = no.noDireito;
			no.noDireito = noDireito.noEsquerdo;
			noDireito.noEsquerdo = no;

			return noDireito;
		}

		public void Remover(int x)
		{
			raiz = Remover(raiz, x);
		}

		private NoAVL Remover(NoAVL no, int x)
		{
			NoAVL ch, s;

			if (no == null)
			{
				Console.WriteLine(x + " nao encontrado");
				baixo = false;
				
				return no;
			}
			
			if (x < no.info) 
			{
				no.noEsquerdo = Remover(no.noEsquerdo, x);
				
				if (baixo == true)
					no = ver_subesq_rem(no);

			} 
			else if (x > no.info) 
			{
				no.noDireito = Remover(no.noDireito, x);
				
				if (baixo == true)
					no = ver_subdir_rem(no);
			}
			else
			{
				
				if ((no.noEsquerdo != null) && (no.noDireito != null)) 
				{
					s = no.noDireito;
					
					while (s.noEsquerdo != null)
						s = s.noEsquerdo;

					no.info = s.info;
					no.noDireito = Remover(no.noDireito, s.info);

					if (baixo == true)
						no = ver_subdir_rem(no);
				}
				else 
				{	
					if (no.noEsquerdo != null) 
						ch = no.noEsquerdo;
					else 
						ch = no.noDireito;

					no = ch;
					baixo = true;
				}
			}

			return no;
		}

		private NoAVL ver_subesq_rem(NoAVL no)
		{
			switch (no.fatorb)
			{
				case 0: 
					no.fatorb = -1; 
					baixo = false;
					break;
				case 1: 
					no.fatorb = 0; 
					break;
				case -1: 
					no = bal_dir_rem(no); 
					break;
			}

			return no;
		}

		private NoAVL ver_subdir_rem(NoAVL no)
		{
			switch (no.fatorb)
			{
				case 0: 
					no.fatorb = 1;
					baixo = false;
					break;
				case -1: 
					no.fatorb = 0; 
					break;
				case 1: 
					no = bal_esq_rem(no); 
					break;
			}

			return no;			
		}

		private NoAVL bal_dir_rem(NoAVL no)
		{
			NoAVL a, b;

			a = no.noDireito;

			if (a.fatorb == 0) 
			{
				a.fatorb = 1;
				baixo = false;
				no = RE(no);
			}
			else if (a.fatorb == -1) 
			{
				no.fatorb = 0;
				a.fatorb = 0;
				no = RE(no);
			}
			else
			{
				b = a.noEsquerdo;

				switch (b.fatorb)
				{
					case 0:
						no.fatorb = 0;
						a.fatorb = 0;
						
						break;

					case 1:
						no.fatorb = 0;
						a.fatorb = -1;
						
						break;

					case -1:
						no.fatorb = 1;
						a.fatorb = 0;

						break;
				}

				b.fatorb= 0;
				no.noDireito = RD(a);
				no = RE(no);
			}

			return no;
		}

		private NoAVL bal_esq_rem(NoAVL no)
		{
			NoAVL a, b;

			a = no.noEsquerdo;

			if (a.fatorb == 0)
			{
				a.fatorb = -1;
				baixo = false;
				no = RD(no);
			}
			else if (a.fatorb == 1)
			{
				no.fatorb = 0;
				a.fatorb = 0;
				no = RD(no);
			}
			else
			{
				b = a.noDireito;

				switch (b.fatorb)
				{
					case 0:
						no.fatorb = 0;
						a.fatorb = 0;
						
						break;

					case 1:
						no.fatorb = 0;
						a.fatorb = 1;
						
						break;

					case -1:
						no.fatorb = -1;
						a.fatorb = 0;

						break;
				}

				b.fatorb = 0;
				no.noEsquerdo = RE(a);
				no = RD(no);
			}

			return no;
		}
		public int Buscar(int info)
		{
			if (this.Buscar(info, this.raiz, 0) != null){
				return 1;
		    }else{
				return 0;
			}
		}
		private NoAVL Buscar(int info, NoAVL no, int cont)
		{
			if(no==null){
				
				return no;

			}else{
				if (info == no.info){
					cont++;
					Console.WriteLine("contador: "+cont);
				    return no;

				}else{
					if(info < no.info){
						cont++;
						return Buscar(info, no.noEsquerdo, cont);
					}else{
						cont++;
                        return Buscar(info, no.noDireito, cont);
					}
				}
			} 
			
		}
		public void Exibir()
		{
			this.Exibir(raiz, 0);
			Console.WriteLine();
		}
		private void Exibir(NoAVL no, int nivel)
		{
			int i;

			if (no == null)
				return;

			Exibir(no.noDireito, nivel + 1);
			Console.WriteLine();

			for (i = 0; i < nivel; i++)
				Console.Write("    ");

			Console.WriteLine(no.info);

			Exibir(no.noEsquerdo, nivel + 1);
		}		
	}
}