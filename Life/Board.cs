using System;

namespace Life
{
	public class Board
	{

		public Board(int height, int width)
		{
			_board1 = new Square[height, width];
			_board2 = new Square[height, width];
			_currentBoard = _board1;
		}

		private Square[,] _board1;
		private Square[,] _board2;
		private Square[,] _currentBoard;

		public int Height {
			get{ return _currentBoard.GetLength(0);}
		}

		public int Width {
			get{ return _currentBoard.GetLength(1);}
		}
			
		private void Seed(Square[,] board){
			for(int row = 0; row < Height ; row++){
				for(int col = 0; col < Width; col++) {
					board[row, col].State = Square.RandState();
				};
			};
		}
	}
}

