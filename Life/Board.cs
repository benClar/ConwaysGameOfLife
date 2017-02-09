using System;
using System.Collections.Generic;
using System.Threading;
namespace Life
{

	public enum Movement {
		UP = -1,
		DOWN = 1,
		LEFT = -1,
		RIGHT = 1,
		NONE = 0
	}
			
	public class MoveGenerator {
		
		public Tuple<Movement, Movement> UpStraight(){ return Tuple.Create(Movement.UP, Movement.NONE);}

		public Tuple<Movement, Movement> UpLeft(){ return Tuple.Create(Movement.UP, Movement.LEFT);}

		public Tuple<Movement, Movement> UpRight(){ return Tuple.Create(Movement.UP, Movement.RIGHT);}

		public Tuple<Movement, Movement> Right(){ return Tuple.Create(Movement.NONE, Movement.RIGHT);}

		public Tuple<Movement, Movement> Left(){ return Tuple.Create(Movement.NONE, Movement.LEFT);}

		public Tuple<Movement, Movement> DownLeft(){ return Tuple.Create(Movement.DOWN, Movement.LEFT);}

		public Tuple<Movement, Movement> Down(){ return Tuple.Create(Movement.DOWN, Movement.NONE);}

		public Tuple<Movement, Movement> DownRight(){ return Tuple.Create(Movement.DOWN, Movement.RIGHT);}

		private Tuple<int, int> DoMove(int col, int row, Tuple<Movement, Movement> direction){
			return Tuple.Create(col + (int) direction.Item1, row + (int) direction.Item2);
		}

		public IEnumerable<Tuple<int, int>> GetNeighbour(int col, int row)
		{
			yield return DoMove(col, row, UpStraight());
			yield return DoMove(col, row, UpLeft());
			yield return DoMove(col, row, UpRight());
			yield return DoMove(col, row, Right());
			yield return DoMove(col, row, Left());
			yield return DoMove(col, row, DownLeft());
			yield return DoMove(col, row, Down());
			yield return DoMove(col, row, DownRight());
		}

	}

	public class Board
	{

		public Board(int height, int width, int iterations)
		{
			_mg = new MoveGenerator();
			_board1 = new Square[height, width];
			_board2 = new Square[height, width];
			_currentBoard = _board1;
			Initialise(_board1);
			Initialise(_board2);
			Seed(_currentBoard);
			_maximumIterations = iterations;
			Tf = Print;
			Tf += IncreaseGeneration;
		}

		private int _REFRESH_RATE_MS = 50; 
		private int _maximumIterations;
		private MoveGenerator _mg;
		private Square[,] _board1;
		private Square[,] _board2;
		private Square[,] _currentBoard;
		private TickFinished Tf;
		private int _currentGeneration = 0;
		public delegate void TickFinished(Square[,] _board);


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

		private void IncreaseGeneration(Square[,] board){
			_currentGeneration += 1;
		}

		private Boolean InBounds(Tuple<int, int> coord){
			if(coord.Item1 < 0 || coord.Item1 >= Height) {
				return false;
			}

			if(coord.Item2 < 0 || coord.Item2 >= Width) {
				return false;
			}

			return true;
		}
			

		private int NumberOfNeighbours(int row, int col){
			int nNeighbours = 0;
			foreach(Tuple<int, int> coord in _mg.GetNeighbour(row, col)){
				if(InBounds(coord)){
					if(_currentBoard[coord.Item1, coord.Item2].State == State.ALIVE){
						nNeighbours++;
					}
				}
			}
			return nNeighbours;
		}

		private State NewState(State currentState, int nNeighbours){

			if (nNeighbours == 2 && currentState == State.ALIVE)
			{
				return State.ALIVE;
			} 
			else if (nNeighbours == 3) 
			{
				return State.ALIVE;
			}
			return State.DEAD;
		}

		private void Tick(){
			for(int row = 0; row < Height; row++) {
				for(int col = 0; col < Width; col++) {
					_board2[row, col].State = NewState(_currentBoard[row, col].State, NumberOfNeighbours(row, col));
				}
			}
			_currentBoard = _board2;
			_board2 = _board1;
			Tf(_currentBoard);
		}

		private void Print(Square[,] b){
			for(int row = 0; row < Height; row++) {
				for(int col = 0; col < Width; col++) {
					b[row, col].Print();
				}
				Console.WriteLine("");
			}

		}

		public void Run(){
			while(_currentGeneration < _maximumIterations) {
				Console.Clear();
				Tick();
				Thread.Sleep(_REFRESH_RATE_MS);
			}

		}

	}
}

