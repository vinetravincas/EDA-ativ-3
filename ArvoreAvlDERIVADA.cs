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

        public ArvoreAVL()
        {
            this.raiz=null;
        }
        
        public void InserirAVL(int x)
		{
			raiz = InserirAVL(raiz, x);
		}
		
		private No InserirAVL(No no, int x)
		{
			if (no == null)
			{
				no = new No(x);
				alto = true;
			}
			else if (x < no.info)
			{
				no.noEsquerdo = InserirAVL(no.noEsquerdo, x);

				if (alto == true)
					no = ver_subesq_in(no);

			}
			else if (x > no.info)
			{
				no.noDireito = InserirAVL(no.noDireito, x);

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
		
		
		
		private No ver_subesq_in(No no)
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

		private No ver_subdir_in(No no)
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
		private No bal_esq_in(No no)
		{
			No a, b;

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

		private No bal_dir_in(No no)
		{
			No a, b;

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

		private No RD(No no)
		{
			No noEsquerdo = no.noEsquerdo;
			no.noEsquerdo = noEsquerdo.noDireito;
			noEsquerdo.noDireito = no;

			return noEsquerdo;
		}

		private No RE(No no)
		{
			No noDireito = no.noDireito;
			no.noDireito = noDireito.noEsquerdo;
			noDireito.noEsquerdo = no;

			return noDireito;
		}

		public void Removeravl(int x)
		{
			raiz = Removeravl(raiz, x);
		}

		private No Removeravl(No no, int x)
		{
			No ch, s;

			if (no == null)
			{
				Console.WriteLine(x + " nao encontrado");
				baixo = false;
				
				return no;
			}
			
			if (x < no.info) 
			{
				no.noEsquerdo = Removeravl(no.noEsquerdo, x);
				
				if (baixo == true)
					no = ver_subesq_rem(no);

			} 
			else if (x > no.info) 
			{
				no.noDireito = Removeravl(no.noDireito, x);
				
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
					no.noDireito = Removeravl(no.noDireito, s.info);

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

		private No ver_subesq_rem(No no)
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

		private No ver_subdir_rem(No no)
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

		private No bal_dir_rem(No no)
		{
			No a, b;

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

		private No bal_esq_rem(No no)
		{
			No a, b;

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
	}
}