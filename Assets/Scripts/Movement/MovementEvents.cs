using UnityEngine;

namespace Movement
{
    public class MovementEvents : MonoBehaviour
    {
        public delegate void Event();
        public static event Event StartMovementReverse;
        public static event Event WipeRecordedMovements;

        public static void Go() => StartMovementReverse();
        public static void DoWipeRecordedMovements() => WipeRecordedMovements();

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))	// bug: dont press R while we're being movement reset
                Go();
        }
    }
}
