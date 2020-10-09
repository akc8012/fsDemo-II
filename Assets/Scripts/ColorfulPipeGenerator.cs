using UnityEngine;

public class ColorfulPipeGenerator : MonoBehaviour
{
	[SerializeField] GameObject ColorfulPipe = null;
	[SerializeField] int Count = 50;
	[SerializeField] Vector3 SpawnOffset = Vector3.zero;

	const float RotationAmount = 3;

	void Start()
	{
		Vector3 position = transform.position;
		float yRotation = 0;

		for (int i = 0; i < Count; i++)
		{
			var rotation = Quaternion.Euler(0, yRotation, 0);
			Instantiate(ColorfulPipe, position, rotation, transform.parent);

			position += SpawnOffset;
			yRotation += RotationAmount;
		}
	}
}
