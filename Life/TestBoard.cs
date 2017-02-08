using System;
using NUnit.Framework;
namespace Life
{
	[TestFixture]
	public class TestBoard
	{

		[Test]
		public void TestDimensions(){
			Board b = new Board(5, 10);
			Assert.AreEqual(b.Height, 5);
			Assert.AreEqual(b.Width, 10);
		}

		[Test]
		public void testMoveGenerator(){
			Tuple<int, int> m = MoveGenerator.DoMove(5, 5, MoveGenerator.DownLeft());
			Assert.AreEqual(6, m.Item1);
			Assert.AreEqual(4, m.Item2);
		}
	}
}

