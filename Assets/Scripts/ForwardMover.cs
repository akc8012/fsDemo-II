using UnityEngine;

public class ForwardMover : MonoBehaviour
{
	float Speed = 2;

	void Update()
	{
		transform.Translate(transform.forward * Speed * Time.deltaTime);
	}
}
