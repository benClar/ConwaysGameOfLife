using System;

namespace Life
{

	public enum State{

		ALIVE,
		DEAD

	}
	public class Square
	{

		private static int DENSITY = 5;
			
		private State _state;
		public State State {
			get{ return _state; }
			set{ _state = value; }
		}

		public Square(State s)
		{
			State = s;
		}

		public Square()
		{
			State = State.DEAD;
		}

		public static State RandState(){
			int state = new Random().Next(DENSITY);
			if(state == 1) {
				return State.ALIVE;
			}
			return State.DEAD;
		}

		public void Print(){
			if(State == State.ALIVE) {
				Console.Write(" * ");
			} else {
				Console.Write("   ");
			}
		}

	}
}

