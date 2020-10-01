using UnityEngine;
using UnityEngine.UI;

public class ReticleController : MonoBehaviour
{
	[SerializeField]
	private Graphic Reticle = null;

	[SerializeField]
	private bool Lerp = true;

	[SerializeField]
	private float LerpAdjust = 1;

	void Awake()
	{
		Cursor.visible = false;
	}

	void Update()
	{
		if (Lerp)
			Reticle.rectTransform.position = Vector3.Lerp(Reticle.rectTransform.position, Input.mousePosition, Time.deltaTime * LerpAdjust);
		else
			Reticle.rectTransform.position = Input.mousePosition;

	}
}
