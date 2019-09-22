using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MovementRecorder))]
public class MovementReversePlayback : MonoBehaviour
{
	MovementRecorder Recorder;

	[SerializeField]
	MonoBehaviour[] ScriptsToDisable;

	[SerializeField]
	float WaitInterval = 0.1f;

	[SerializeField]
	bool ShouldLog = true;

	void Start()
	{
		Recorder = GetComponent<MovementRecorder>();
		Recorder.On();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (ShouldLog)
				Debug.Log("Got key R");

			StartCoroutine(PlaybackReversed());
		}
	}

	IEnumerator PlaybackReversed()
	{
		PreparePlaybackReverse();

		while (Recorder.MovementStack.Count != 0)
		{
			var movement = Recorder.MovementStack.Pop();
			transform.SetPositionAndRotation(movement.Position, movement.Rotation);

			if (ShouldLog)
				Debug.Log(movement.Position);

			yield return new WaitForSeconds(WaitInterval);
		}

		FinishPlaybackReversed();
		// Undefined behavior land!!
	}

	void PreparePlaybackReverse()
	{
		Recorder.Off();
		// ToDo: Extract this logic to a script - ScriptToggler - Should listen to event
		foreach (var script in ScriptsToDisable)
			script.enabled = false;

		if (ShouldLog)
		{
			Debug.Log("Recorder off, here's my stack:");
			Recorder.PrintStack();
		}
	}

	void FinishPlaybackReversed()
	{
		if (ShouldLog)
			Debug.Log("Done");

		Recorder.On();
		foreach (var script in ScriptsToDisable)
			script.enabled = true;
	}
}
