using UnityEngine;

namespace Movement
{
	public class MovementEventOrchestrator : MonoBehaviour
	{
		public static float RecorderInterval = 0.0025f;
		public static float PlaybackInterval = 0.0025f;	 // ToDo: I think you can speed up playback by making this smaller, but I'm not sure if it breaks things
		public static float PauseAfterDeathTime = 0.25f;

		public delegate void Event();
		public static event Event StartReversePlaybackEvent;
		public static event Event PlaybackFinishedEvent;
		public static event Event WipeRecordedMovementsEvent;
		static int FinishedPlaybackCount = 0;

		public static void StartReversePlayback() => StartReversePlaybackEvent();
		public static void WipeRecordedMovements() => WipeRecordedMovementsEvent();

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.R))	// bug: dont press R while we're being movement reset
				StartReversePlayback();
		}

		// ToDo: We need some way of *only* sending the *one* event when BOTH Playbacks have finished
		public static void PlaybackFinished()
		{
			FinishedPlaybackCount++;
			if (FinishedPlaybackCount == 2)//StartReversePlaybackEvent.GetInvocationList().Length)
			{
				// Debug.Log($"Done with {FinishedPlaybackCount} count. Sending event!");

				FinishedPlaybackCount = 0;
				PlaybackFinishedEvent();
			}
		}
	}
}
