using System.Collections;
using UnityEngine;

namespace Movement
{
	[RequireComponent(typeof(MovementRecorder))]
	[RequireComponent(typeof(ScriptToggler))]
	public class MovementPlayback : MonoBehaviour
	{
		MovementRecorder Recorder;
		ScriptToggler ScriptToggler;

		[SerializeField]
		float WaitInterval = 0.1f;

		// Do this (absolute trash code) to make sure we're not calling MovementReseter twice
		[SerializeField]
		bool ShouldResetMovements = false;

		void Awake()
		{
			Recorder = GetComponent<MovementRecorder>();
			Recorder.On();

			ScriptToggler = GetComponent<ScriptToggler>();
			MovementEventOrchestrator.StartReversePlaybackEvent += () => StartCoroutine(PlaybackReversed());
		}

		IEnumerator PlaybackReversed()
		{
			PreparePlaybackReverse();

			while (Recorder.MovementStack.Count != 0)
			{
				var movement = Recorder.MovementStack.Pop();
				transform.SetPositionAndRotation(movement.Position, movement.Rotation);

				// ToDo: Control the timing via a dank-ass time spline thing
				yield return new WaitForSeconds(WaitInterval);
			}

			FinishPlaybackReversed();
		}

		// ToDo: Extract this logic to a script - ScriptToggler - Should listen to event
		void PreparePlaybackReverse()
		{
			Recorder.Off();
			ScriptToggler.Off();
		}

		void FinishPlaybackReversed()
		{
			Recorder.On();
			ScriptToggler.On();

			if (ShouldResetMovements)
				GameObject.Find("GameplayPlane").GetComponent<MovementReseter>().Load();
		}
	}
}
