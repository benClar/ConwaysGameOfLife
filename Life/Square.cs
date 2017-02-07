using System;

namespace Life
{

	public enum State{

		ALIVE,
		DEAD

	}
	public class Square
	{
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

		public static State randState(){
			return new Random().Next(2);
		}
	}
}

