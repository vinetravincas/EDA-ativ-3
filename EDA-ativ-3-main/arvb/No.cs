namespace eda.arvb 
{
	public class No
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

	public class NoAVL: No
	{
		public NoAVL noEsquerdo;
		public NoAVL noDireito;
		public int fatorb;

		public NoAVL(int info) : base(info)
		{
			this.info = info;
			this.fatorb=0;
		}
	}
		
}