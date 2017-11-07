using System.Collections.Generic;
using UnityEngine;

public class PotionDebug : MonoBehaviour, IConsumable
{
	public void Consume()
	{
		Debug.Log("OHHH YEEAHHHH DEBUGGED");
	}

	public void Consume(CharacterStats stats)
	{
		Debug.Log("OHHH YEEAHHHH DEBUGGED; " + stats);
	}
}
