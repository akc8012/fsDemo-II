using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Movement
{
	[RequireComponent(typeof(CinemachineDollyCart))]
	public class MovementReseter : MonoBehaviour
	{
		CinemachineDollyCart CinemachineDollyCart;
		List<Movement> Movements = new List<Movement>();
		float LastCartPosition;

		void Awake()
		{
			CinemachineDollyCart = GetComponent<CinemachineDollyCart>();

			MovementEventOrchestrator.WipeRecordedMovementsEvent += Save;
			MovementEventOrchestrator.PlaybackFinishedEvent += Load;
		}

		// ToDo: Fix this? Leave this to Start - There may be fucky wucki-ness with speed of CinemachineDollyCart
		void Start() => Save();

		void Save()
		{
			Movements.Clear();

			foreach (var transform in transform.GetComponentsInChildren<Transform>())
				Movements.Add(new Movement { Position = transform.position, Rotation = transform.rotation });

			LastCartPosition = CinemachineDollyCart.m_Position;
		}

		void Load()
		{
			var childTransforms = transform.GetComponentsInChildren<Transform>();
			for (int i = 0; i < Movements.Count; i++)
				childTransforms[i].SetPositionAndRotation(Movements[i].Position, Movements[i].Rotation);
				
			CinemachineDollyCart.m_Position = LastCartPosition;
		}
	}
}
