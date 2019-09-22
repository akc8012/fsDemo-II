using System.Collections;
using System.Text;
using UnityEngine;

public class MovementRecorder : MonoBehaviour
{
	[SerializeField]
	float WaitInterval = 0.1f;

    public MovementStack MovementStack { get; private set; } = new MovementStack();

    public void On() => StartCoroutine(RecordMovement());

	public void Off() => StopAllCoroutines();

	IEnumerator RecordMovement()
	{
		while (true)
		{
			MovementStack.Push(new Movement { Position = transform.position, Rotation = transform.rotation });
			yield return new WaitForSeconds(WaitInterval);
		}
	}

	// ToDo: We should be printing to a file or something
	public void PrintStack()
	{
		var log = new StringBuilder();
		foreach (var movement in MovementStack.GetStack())
		{
			if (log.Length != 0)
				log.Append("\n");

			log.Append(movement.Position);
		}

		Debug.Log(log);
	}
}
