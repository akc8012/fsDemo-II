using System;
using System.Collections;
using System.Collections.Generic;
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
			case "Untagged":
				InCollisionPause = true;
				Movement.MovementEventOrchestrator.StartReversePlayback();
				break;

			case "Checkpoint":
				Movement.MovementEventOrchestrator.WipeRecordedMovements();
				other.gameObject.SetActive(false);	// this is shit, but we can kill the checkpoint after use
				break;
		}
	}
}
