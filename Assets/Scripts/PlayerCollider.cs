using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCollider : MonoBehaviour
{
	[SerializeField]
	CinemachineDollyCart CinemachineDollyCart;

	[SerializeField]
	Legacy.PlayerMovement PlayerMovement;

	float LastCartSpeed;
	bool InCollisionPause = false;

	void OnTriggerEnter(Collider other)
	{
		if (InCollisionPause)
			return;

		switch (other.gameObject.tag)
		{
			case "Untagged":
				DoDelayedCartReset();
				break;

			case "Checkpoint":
				Movement.MovementEvents.DoWipeRecordedMovements();
				other.gameObject.SetActive(false);	// this is shit, but we can kill the checkpoint after use
				break;
		}
	}

	// ToDo: This should probably be handled elsewhere
	void DoDelayedCartReset()
	{
		InCollisionPause = true;

		LastCartSpeed = CinemachineDollyCart.m_Speed;
		CinemachineDollyCart.m_Speed = 0;
		PlayerMovement.enabled = false;
		Invoke("ResetCartPositionAndSpeed", time: 0.75f);
	}

	void ResetCartPositionAndSpeed()
	{
		Movement.MovementEvents.Go();

		// ToDo: THIS IS SO VERY BAD, FIX THIS!!!!!!!!!!!!
		Invoke("TurnOffInCollisionPause", 0.25f);
	}

	void TurnOffInCollisionPause() => InCollisionPause = false;
}
