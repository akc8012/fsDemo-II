﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCollider : MonoBehaviour
{
	[SerializeField]
	CinemachineDollyCart CinemachineDollyCart;
	
	[SerializeField]
	PlayerMovement PlayerMovement;
	
	float LastCartSpeed;
	bool InCollisionPause = false;

	void OnTriggerEnter(Collider other)
	{
		if (InCollisionPause)
			return;

		Debug.Log($"Collided with {other.gameObject.name}!");
		DoDelayedCartReset();		
	}

	// ToDo: This should probably be handled elsewhere
	void DoDelayedCartReset()
	{
		InCollisionPause = true;

		LastCartSpeed = CinemachineDollyCart.m_Speed;
		CinemachineDollyCart.m_Speed = 0;
		PlayerMovement.enabled = false;
		Invoke("ResetCartPositionAndSpeed", 1);
	}

	void ResetCartPositionAndSpeed()
	{
		InCollisionPause = false;

		CinemachineDollyCart.m_Position = 0;
		CinemachineDollyCart.m_Speed = LastCartSpeed;
		PlayerMovement.enabled = true;
	}
}
