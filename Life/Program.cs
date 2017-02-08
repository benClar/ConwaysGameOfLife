using System;

namespace Life
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Board b = new Board(55,65, 1000000000);
			b.Run();
		}
	}
}
