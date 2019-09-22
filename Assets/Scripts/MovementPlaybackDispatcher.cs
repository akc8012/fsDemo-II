using UnityEngine;

public class MovementPlaybackDispatcher : MonoBehaviour
{
	public delegate void Event();
	public static event Event MovementReverseStart;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			MovementReverseStart();
	}
}
