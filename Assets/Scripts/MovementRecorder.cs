using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MovementRecorder : MonoBehaviour
{
	[SerializeField]
	Transform TargetTransform;

	[SerializeField]
	float WaitInterval = 0.1f;

	[SerializeField]
	bool ShouldLog = true;

	// ToDo: public bad
	public MovementStack MovementStack = new MovementStack();

	void Awake() => StartCoroutine(RecordMovement());

	IEnumerator RecordMovement()
	{
		while (true)
		{
			MovementStack.Push(new Movement { Position = TargetTransform.position, Rotation = TargetTransform.rotation });
			PrintStack();

			yield return new WaitForSeconds(WaitInterval);
		}
	}

	// ToDo: We should be printing to a file or something
	void PrintStack()
	{
		if (!ShouldLog)
			return;

		var log = new StringBuilder();
		foreach (var movement in MovementStack.GetStack())
		{
			if (log.Length != 0)
				log.Append(", ");

			log.Append(movement.Position);
		}

		Debug.Log(log);
	}
}
