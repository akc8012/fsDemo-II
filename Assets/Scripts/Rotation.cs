using UnityEngine;

public class Rotation : MonoBehaviour
{
	[SerializeField]
	float Speed = 25;

	void Update()
	{
		transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));
	}
}
