using UnityEngine;

public class ScriptToggler : MonoBehaviour
{
	[SerializeField]
	MonoBehaviour[] ScriptsToDisable = null;

	public void On()
	{
		foreach (var script in ScriptsToDisable)
			script.enabled = true;
	}

	public void Off()
	{
		foreach (var script in ScriptsToDisable)
			script.enabled = false;
	}
}
