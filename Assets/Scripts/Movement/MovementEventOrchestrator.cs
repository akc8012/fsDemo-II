using UnityEngine;

namespace Movement
{
	public class MovementEventOrchestrator : MonoBehaviour
	{
		public delegate void Event();
		public static event Event StartReversePlaybackEvent;
		public static event Event WipeRecordedMovementsEvent;

		public static void StartReversePlayback() => StartReversePlaybackEvent();
		public static void WipeRecordedMovements() => WipeRecordedMovementsEvent();

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.R))	// bug: dont press R while we're being movement reset
				StartReversePlayback();
		}
	}
}
