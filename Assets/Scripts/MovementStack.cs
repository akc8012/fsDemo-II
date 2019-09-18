using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStack
{
	Stack<Movement> Stack = new Stack<Movement>();

    public void Push(Movement movement) => Stack.Push(movement);

	// ToDo: THIS IS BAD, MAKE IT INHERIT IENUMBERABLE INSTEAD !!!!!
	public Stack<Movement> GetStack() => Stack;
}
