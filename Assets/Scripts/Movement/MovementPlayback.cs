using System.Collections;
using UnityEngine;

namespace Movement
{
	[RequireComponent(typeof(MovementRecorder))]
	public class MovementPlayback : MonoBehaviour
	{
		MovementRecorder Recorder;

		void Awake()
		{
			Recorder = GetComponent<MovementRecorder>();
			Recorder.On();

			MovementEventOrchestrator.StartReversePlaybackEvent += () => StartCoroutine(PauseAfterDeath());
		}

		IEnumerator PauseAfterDeath()
		{
			yield return new WaitForSeconds(MovementEventOrchestrator.PauseAfterDeathTime);
			StartCoroutine(PlaybackReversed());
		}

		IEnumerator PlaybackReversed()
		{
			Recorder.Off();

			while (Recorder.MovementStack.Count != 0)
			{
				var movement = Recorder.MovementStack.Pop();
				transform.SetPositionAndRotation(movement.Position, movement.Rotation);

				// ToDo: Control the timing via a dank-ass time spline thing
				yield return new WaitForSeconds(MovementEventOrchestrator.PlaybackInterval);
			}

			Recorder.On();
			MovementEventOrchestrator.PlaybackFinished();
		}
	}
}
