using System;
using NUnit.Framework;
namespace Life
{
	[TestFixture]
	public class TestBoard
	{

		[Test]
		public void TestDimensions(){
			Board b = new Board(5, 10, 100);
			Assert.AreEqual(b.Height, 5);
			Assert.AreEqual(b.Width, 10);
		}

		[Test]
		public void testMoveGenerator(){
			MoveGenerator mg = new MoveGenerator();
			int col, row;
			row = col = 5;
			int i=0;
			Tuple<int, int>[] exp = new Tuple<int, int>[8]{
				Tuple.Create(4, 5), 
				Tuple.Create(4, 4), 
				Tuple.Create(4, 6), 
				Tuple.Create(5, 6),
				Tuple.Create(5, 4),
				Tuple.Create(6, 4),
				Tuple.Create(6, 5),
				Tuple.Create(6, 6),
			};
			foreach(Tuple<int, int> m in mg.GetNeighbour(col, row)){
				Assert.AreEqual(m, exp[i]);
				i++;
			}
		}
	}
}
	