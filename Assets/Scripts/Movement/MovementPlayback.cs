using System.Collections;
using UnityEngine;

namespace Movement
{
	[RequireComponent(typeof(MovementRecorder))]
	public class MovementPlayback : MonoBehaviour
	{
		MovementRecorder Recorder;

		// ToDo: This should live in once place and one place only.
		[SerializeField]
		float WaitInterval = 0.1f;

		void Awake()
		{
			Recorder = GetComponent<MovementRecorder>();
			Recorder.On();

			MovementEventOrchestrator.StartReversePlaybackEvent += () => StartCoroutine(PauseAfterDeath());
		}

		IEnumerator PauseAfterDeath()
		{
			yield return new WaitForSeconds(0.75f);
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
				yield return new WaitForSeconds(WaitInterval);
			}

			Recorder.On();
			MovementEventOrchestrator.PlaybackFinished();
		}
	}
}
