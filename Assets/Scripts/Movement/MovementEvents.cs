using UnityEngine;

namespace Movement
{
    // ToDo: Make this MovementEvents
    public class MovementEvents : MonoBehaviour
    {
        public delegate void Event();
        public static event Event StartMovementReverse;
        public static event Event WipeRecordedMovements;

        // ToDo: I dunno if this is bad, but ... it certainly seems not good
        public static void Go() => StartMovementReverse();
        public static void DoWipeRecordedMovements() => WipeRecordedMovements();

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))	// bug: dont press R while we're being movement reset
                Go();
        }
    }
}
