namespace eda.arvb 
{
	class No
	{
		public No noEsquerdo;
		public int info;
		public No noDireito;
		public int fatorb;

		public No(int info)
		{
			this.noEsquerdo = null;
			this.info = info;
			this.noDireito = null;
			this.fatorb=0;
		}
	}
}