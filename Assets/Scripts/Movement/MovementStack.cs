using System.Collections;
using System.Collections.Generic;

namespace Movement
{
	public class MovementStack : IEnumerable<Movement>
	{
		Stack<Movement> Stack = new Stack<Movement>();

		public IEnumerator<Movement> GetEnumerator() => Stack.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		public int Count => Stack.Count;

		public void Push(Movement movement) => Stack.Push(movement);

		public Movement Pop() => Stack.Pop();

		public void Clear() => Stack.Clear();
	}
}
