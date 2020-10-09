using UnityEngine;

public class ColorfulPipeGenerator : MonoBehaviour
{
	[SerializeField] GameObject ColorfulPipe = null;
	[SerializeField] int Amount = 50;
	[SerializeField] Vector3 SpawnOffset = Vector3.zero;

	void Start()
	{
		Vector3 position = transform.position;
		for (int i = 0; i < Amount; i++)
		{
			Instantiate(ColorfulPipe, position, Quaternion.identity, transform.parent);
			position += SpawnOffset;
		}
	}
}
