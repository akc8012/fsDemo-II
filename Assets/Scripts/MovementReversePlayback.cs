using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MovementRecorder))]
public class MovementReversePlayback : MonoBehaviour
{
	MovementRecorder MovementRecorder;

	[SerializeField]
	MonoBehaviour[] ScriptsToDisable;

	[SerializeField]
	float WaitInterval = 0.1f;

	[SerializeField]
	bool ShouldLog = true;

	void Awake() => MovementRecorder = GetComponent<MovementRecorder>();

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (ShouldLog)
				MovementRecorder.PrintStack();

			StartCoroutine(PlaybackReversed());
		}
	}

	IEnumerator PlaybackReversed()
	{
		// ToDo: Extract this logic to a script - ScriptToggler - Should listen to event
		foreach (var script in ScriptsToDisable)
		{
			script.enabled = false;
			script.StopAllCoroutines(); // ToDo: Coroutines have to restart - It breaks stuff!! (MovementRecorder)
		}

		while (MovementRecorder.MovementStack.Count != 0)
		{
			var movement = MovementRecorder.MovementStack.Pop();
			transform.SetPositionAndRotation(movement.Position, movement.Rotation);

			if (ShouldLog)
				Debug.Log(movement.Position);

			yield return new WaitForSeconds(WaitInterval);
		}

		if (ShouldLog)
			Debug.Log("Done");

		// when we enter this point: welcome to undefined behavior land!
		// foreach (var script in ScriptsToDisable)
		// 	script.enabled = true;
	}
}
