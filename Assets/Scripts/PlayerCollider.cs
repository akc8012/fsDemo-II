using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
	bool InCollisionPause = false;

	void Awake()
	{
		Movement.MovementEventOrchestrator.PlaybackFinishedEvent += () => InCollisionPause = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (InCollisionPause)
			return;

		switch (other.gameObject.tag)
		{
			// TODO: This should be an explicit check on tags marked for player collision?
			// It is a problem when we need something to act as a "safe" pass-through trigger that
			// shouldn't kill the player.
			case "Untagged":
				InCollisionPause = true;
				Movement.MovementEventOrchestrator.StartReversePlayback();
				break;

			case "Checkpoint":
				Movement.MovementEventOrchestrator.WipeRecordedMovements();
				other.gameObject.SetActive(false);  // this is shit, but we can kill the checkpoint after use
				break;
		}
	}
}
