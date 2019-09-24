using UnityEngine;

public class MovementReverseNotifier : MonoBehaviour
{
	public delegate void Event();
	public static event Event StartMovementReverse;

	// ToDo: I dunno if this is bad, but ... it certainly seems not good
	public static void Go() => StartMovementReverse();

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			Go();
	}
}
