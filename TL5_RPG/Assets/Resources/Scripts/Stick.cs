using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour, IWeapon
{
	public List<BaseStat> Stats { get; set; }

	public void Attack()
	{
		Debug.Log("Get schticked!");
	}
}
