using UnityEngine;

[RequireComponent(typeof(Legacy.PlayerMovement))]
public class PlayerToggler : MonoBehaviour
{
	[SerializeField]
	MonoBehaviour[] ScriptsToDisable = null;

	void Awake()
	{
		Movement.MovementEventOrchestrator.StartReversePlaybackEvent += Off;
		Movement.MovementEventOrchestrator.PlaybackFinishedEvent += On;
	}

	void Off()
	{
		foreach (var script in ScriptsToDisable)
			script.enabled = false;
	}

	void On()
	{
		foreach (var script in ScriptsToDisable)
			script.enabled = true;
	}
}
