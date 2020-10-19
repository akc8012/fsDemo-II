using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorfulPipeMovementController : MonoBehaviour
{
	[SerializeField] Transform ColorfulPipeParent = null;

	List<GameObject> ColorfulPipes;

	void Start()
	{
		ColorfulPipes = GetColorfulPipes().ToList();

		if (!ColorfulPipes.Any())
			Debug.LogWarning("Warning: ColorfulPipeMovementController found 0 pipes. This may be a problem!");
	}

	IEnumerable<GameObject> GetColorfulPipes()
	{
		for (int i = 0; i < ColorfulPipeParent.childCount; i++)
			yield return ColorfulPipeParent.GetChild(i).gameObject;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
			EnableMovement();

		Destroy(gameObject);
	}

	void EnableMovement()
	{
		foreach (GameObject colorfulPipe in ColorfulPipes)
		{
			colorfulPipe.GetComponent<Rotation>().enabled = true;
			colorfulPipe.GetComponent<ForwardMover>().enabled = true;
		}
	}
}
