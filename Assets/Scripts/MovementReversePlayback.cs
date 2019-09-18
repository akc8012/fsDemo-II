using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementReversePlayback : MonoBehaviour
{
	[SerializeField]
	Transform TargetTransform;

	[SerializeField]
	MovementRecorder MovementRecorder;

	[SerializeField]
	MonoBehaviour[] ScriptsToDisable;


	[SerializeField]
	float WaitInterval = 0.1f;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			StartCoroutine(PlaybackReversed());
	}

	IEnumerator PlaybackReversed()
	{
		foreach (var script in ScriptsToDisable)
		{
			script.enabled = false;
			script.StopAllCoroutines();
		}

		var stack = MovementRecorder.MovementStack.GetStack();
		while (stack.Count != 0)
		{
			var movement = stack.Pop();

			TargetTransform.position = movement.Position;
			TargetTransform.rotation = movement.Rotation;

			Debug.Log(movement.Position);

			yield return new WaitForSeconds(WaitInterval);
		}

		Debug.Log("Done");

		// when we enter this point: welcome to undefined behavior land!
		// foreach (var script in ScriptsToDisable)
		// 	script.enabled = true;
	}
}
