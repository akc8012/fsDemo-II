using System.Collections;
using System.Collections.Generic;

public class MovementStack
{
	Stack<Movement> Stack = new Stack<Movement>();

	public int Count => Stack.Count;

    public void Push(Movement movement) => Stack.Push(movement);

    public Movement Pop() => Stack.Pop();

	// ToDo: THIS IS BAD, MAKE IT INHERIT IENUMBERABLE INSTEAD !!!!!
	public Stack<Movement> GetStack() => Stack;
}
