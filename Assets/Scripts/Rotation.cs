using UnityEngine;

public class Rotation : MonoBehaviour
{
	[SerializeField] float Speed = 25;
	[SerializeField] Vector3 Axis = new Vector3(0, 0, 1);
	[SerializeField] bool Randomize = false;

	const float MaxSpeed = 125;
	const float MinSpeed = 60;

	void Start()
	{
		if (Randomize)
		{
			do
				Speed = Random.Range(-MaxSpeed, MaxSpeed);
			while (Mathf.Abs(Speed) < MinSpeed);
		}
	}

	void Update()
	{
		Vector3 rotation = Axis * (Speed * Time.deltaTime);
		transform.Rotate(rotation);
	}
}
