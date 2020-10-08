using UnityEngine;

public class RandomMaterialPicker : MonoBehaviour
{
	[SerializeField]
	private Material[] Materials = null;

	void Start()
	{
		var renderer = GetComponent<Renderer>();
		renderer.material = Materials[Random.Range(0, Materials.Length)];
	}
}
