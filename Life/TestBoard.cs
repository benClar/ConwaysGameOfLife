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
	}
}

