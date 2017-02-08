using System;
using System.Collections.Generic;

namespace Life
{

	public enum Movement {
		UP = -1,
		DOWN = 1,
		LEFT = -1,
		RIGHT = 1,
		NONE = 0

	}

	public static class MoveGenerator {
		
		public static Tuple<Movement, Movement> UpStraight(){ return Tuple.Create(Movement.UP, Movement.NONE);}

		public static Tuple<Movement, Movement> UpLeft(){ return Tuple.Create(Movement.UP, Movement.LEFT);}

		public static Tuple<Movement, Movement> UpRight(){ return Tuple.Create(Movement.UP, Movement.RIGHT);}

		public static Tuple<Movement, Movement> Right(){ return Tuple.Create(Movement.NONE, Movement.RIGHT);}

		public static Tuple<Movement, Movement> Left(){ return Tuple.Create(Movement.NONE, Movement.LEFT);}

		public static Tuple<Movement, Movement> DownLeft(){ return Tuple.Create(Movement.DOWN, Movement.LEFT);}

		public static Tuple<Movement, Movement> Down(){ return Tuple.Create(Movement.DOWN, Movement.NONE);}

		public static Tuple<Movement, Movement> DownRight(){ return Tuple.Create(Movement.DOWN, Movement.RIGHT);}

		public static Tuple<int, int> DoMove(int col, int row, Tuple<Movement, Movement> direction){
			return Tuple.Create(col + (int) direction.Item1, row + (int) direction.Item2);
		}

	}

	public class Board
	{

		public Board(int height, int width)
		{
			_board1 = new Square[height, width];
			_board2 = new Square[height, width];
			_currentBoard = _board1;
			Initialise(_board1);
			Initialise(_board2);
			Seed(_currentBoard);
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
			
		private Square[,] Initialise(Square[,] board){
			for(int row = 0; row < Height ; row++){
				for(int col = 0; col < Width; col++) {
					board[row, col] = new Square();
				};
			};
			return board;
		}

		private void Seed(Square[,] board){
			for(int row = 0; row < Height ; row++){
				for(int col = 0; col < Width; col++) {
					board[row, col].State = Square.RandState();
				};
			};
		}

		private void Copy(Square[,] fromBoard, Square[,] toBoard){
			for(int row = 0; row < Height ; row++){
				for(int col = 0; col < Width; col++) {
					toBoard[row, col].State = fromBoard[row, col].State;
				};
			};
		}

		private Boolean InBounds(int row, int col){
			if(row < 0 && row >= Height) {
				return false;
			}

			if(col < 0 && row >= Width) {
				return false;
			}

			return true;
		}

		private List<Tuple<int, int>> GetAllNeighbourCoordinates(int row, int col){
			List<Tuple<int, int>> coords = new List<Tuple<int, int>>();

			return coords;
		}

		private int NumberOfNeighbours(int row, int col){
			int nNeighbours = 0;

			return nNeighbours;
		}

		private void Tick(){

		}

	}
}

