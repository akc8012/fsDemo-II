using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Movement
{
	public class MovementReseter : MonoBehaviour
	{
		[SerializeField]
		CinemachineDollyCart CinemachineDollyCart;

		List<Movement> Movements = new List<Movement>();
		float LastCartSpeed;
		float LastCartPosition;

		void Awake() => MovementEvents.WipeRecordedMovements += Save;

		// Leave this to Start - There may be fucky wucki-ness with speed of CinemachineDollyCart
		void Start() => Save();

		public void Save()
		{
			Movements.Clear();

			foreach (var transform in transform.GetComponentsInChildren<Transform>())
				Movements.Add(new Movement { Position = transform.position, Rotation = transform.rotation });

			LastCartSpeed = CinemachineDollyCart.m_Speed;
			LastCartPosition = CinemachineDollyCart.m_Position;
		}

		public void Load()
		{
			var childTransforms = transform.GetComponentsInChildren<Transform>();
			for (int i = 0; i < Movements.Count; i++)
				childTransforms[i].SetPositionAndRotation(Movements[i].Position, Movements[i].Rotation);
				
			CinemachineDollyCart.m_Speed = LastCartSpeed;
			CinemachineDollyCart.m_Position = LastCartPosition;
		}
	}
}
