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

	void Start()
	{
		Recorder = GetComponent<MovementRecorder>();
		Recorder.On();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			StartCoroutine(PlaybackReversed());
	}

	IEnumerator PlaybackReversed()
	{
		PreparePlaybackReverse();

		while (Recorder.MovementStack.Count != 0)
		{
			var movement = Recorder.MovementStack.Pop();
			transform.SetPositionAndRotation(movement.Position, movement.Rotation);

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

		Debug.Log($"{name} start reverse.");
	}

	void FinishPlaybackReversed()
	{
		Recorder.On();
		foreach (var script in ScriptsToDisable)
			script.enabled = true;

		Debug.Log($"{name} done reverse.");
	}
}
