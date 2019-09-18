using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCollider : MonoBehaviour
{
	[SerializeField]
	CinemachineDollyCart CinemachineDollyCart;

    void OnTriggerEnter(Collider other) => ResetCartPosition();

    // TODO: This should be done in a different script
    void ResetCartPosition() => CinemachineDollyCart.m_Position = 0;
}
