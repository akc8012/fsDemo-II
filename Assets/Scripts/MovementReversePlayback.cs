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

	// Do this (absolute trash code) to make sure we're not calling MovementReseter twice
	[SerializeField]
	bool ShouldResetMovements = false;

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
	}

	// ToDo: Extract this logic to a script - ScriptToggler - Should listen to event
	void PreparePlaybackReverse()
	{
		Recorder.Off();
		foreach (var script in ScriptsToDisable)
			script.enabled = false;
	}

	void FinishPlaybackReversed()
	{
		Recorder.On();
		foreach (var script in ScriptsToDisable)
			script.enabled = true;

		if (ShouldResetMovements)
			GameObject.Find("GameplayPlane").GetComponent<MovementReseter>().Load();
	}
}
