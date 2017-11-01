using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBonus
{
	public int Value { get; set; }

	public StatBonus(int value)
	{
		Value = value;
		Debug.Log("New stat bonus created!");
	}
}
