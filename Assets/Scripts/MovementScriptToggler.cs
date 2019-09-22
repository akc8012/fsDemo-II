using UnityEngine;

public class MovementScriptToggler : MonoBehaviour
{
	[SerializeField]
	MonoBehaviour[] ScriptsToDisable;

	void Awake()
	{
		MovementPlaybackDispatcher.MovementReverseStart += Off;
		MovementReversePlayback.MovementReverseFinish += On;
	}

	void On()
	{
		foreach (var script in ScriptsToDisable)
			script.enabled = true;
	}

	void Off()
	{
		foreach (var script in ScriptsToDisable)
			script.enabled = false;
	}
}
