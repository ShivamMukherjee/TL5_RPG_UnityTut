using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public PlayerWeaponController weaponController;
	public ItemMeta Stick { get; set; }

	// Use this for initialization
	void Start()
	{
		List<BaseStat> stats = new List<BaseStat>();
		weaponController = GetComponent<PlayerWeaponController>();
		stats.Add(new BaseStat(6, "Power", "Your power level."));
		Stick = new ItemMeta(stats, "Shit stick");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			weaponController.Equip(Stick);
		}
	}
}
