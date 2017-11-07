using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	[SerializeField] private PlayerWeaponController weaponController;
	[SerializeField] private ConsumableController consumableController;
	public ItemMeta Weapon { get; private set; }
	public ItemMeta Consumable { get; private set; }

	// Use this for initialization
	void Start()
	{
		List<BaseStat> stats = new List<BaseStat>();
		weaponController = GetComponent<PlayerWeaponController>();
		consumableController = GetComponent<ConsumableController>();
		stats.Add(new BaseStat(6, "Power", "Your power level."));
		Weapon = new ItemMeta(stats, "SpitwadLauncher");
		Consumable = new ItemMeta(new List<BaseStat>(),
			"PotionDebug", "Logs out debug info. No in-game use really.", "Drinkity", "Debug Potion", false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			weaponController.Equip(Weapon);
		}

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			consumableController.Consume(Consumable);
		}
	}
}
