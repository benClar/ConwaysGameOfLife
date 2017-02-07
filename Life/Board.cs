using System;

namespace Life
{
	public class Board
	{
		private Square[,] _board1;
		private Square[,] _board2;
		private Square[,] _currentBoard;

		public Board(int height, int width)
		{
			_board1 = new Square[height, width];
			_board2 = new Square[height, width];
			-_currentBoard = _board1;
		}
	}
}

