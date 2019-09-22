using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementReversePlayback : MonoBehaviour
{
	[SerializeField]
	MovementRecorder MovementRecorder;

	[SerializeField]
	MonoBehaviour[] ScriptsToDisable;

	[SerializeField]
	float WaitInterval = 0.1f;

	[SerializeField]
	bool ShouldLog = true;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			StartCoroutine(PlaybackReversed());
	}

	IEnumerator PlaybackReversed()
	{
		// ToDo: Extract this logic to a script - ScriptToggler
		foreach (var script in ScriptsToDisable)
		{
			script.enabled = false;
			script.StopAllCoroutines(); // ToDo: Coroutines have to restart - It breaks stuff!! (MovementRecorder)
		}

		var stack = MovementRecorder.MovementStack.GetStack();
		while (stack.Count != 0)
		{
			var movement = stack.Pop();

			transform.position = movement.Position;
			transform.rotation = movement.Rotation;

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
