using System.Collections;
using System.Collections.Generic;

namespace Movement
{
	public class MovementStack
	{
		Stack<Movement> Stack = new Stack<Movement>();

		public int Count => Stack.Count;

		public void Push(Movement movement) => Stack.Push(movement);

		public Movement Pop() => Stack.Pop();

		public void Clear() => Stack.Clear();

		// ToDo: THIS IS BAD, MAKE IT INHERIT IENUMBERABLE INSTEAD !!!!!
		public Stack<Movement> GetStack() => Stack;
	}
}
