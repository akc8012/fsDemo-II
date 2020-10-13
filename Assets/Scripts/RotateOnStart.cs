using UnityEngine;

public class RotateOnStart : MonoBehaviour
{
	[SerializeField] Vector3 Rotation = Vector3.zero;

	void Start()
	{
		transform.Rotate(Rotation);
	}
}
