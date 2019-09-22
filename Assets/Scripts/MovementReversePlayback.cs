using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MovementRecorder))]
public class MovementReversePlayback : MonoBehaviour
{
	public static event MovementPlaybackDispatcher.Event MovementReverseFinish;

	MovementRecorder Recorder;

	[SerializeField]
	float WaitInterval = 0.1f;

	[SerializeField]
	bool ShouldLog = true;

	void Awake()
	{
		Recorder = GetComponent<MovementRecorder>();
		MovementPlaybackDispatcher.MovementReverseStart += () => StartCoroutine(PlaybackReversed());
	}

	IEnumerator PlaybackReversed()
	{
		while (Recorder.MovementStack.Count != 0)
		{
			var movement = Recorder.MovementStack.Pop();
			transform.SetPositionAndRotation(movement.Position, movement.Rotation);

			if (ShouldLog)
				Debug.Log(movement.Position);

			yield return new WaitForSeconds(WaitInterval);
		}

		MovementReverseFinish();
		Debug.Log($"{this.name} done. Entering Undefined Behavior Land");
	}
}
