using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
	static public InventoryManager Instance { get; private set; }
	public List<ItemMeta> Items { get; private set; }
	[SerializeField] private WeaponController weaponController;
	[SerializeField] private ConsumableController consumableController;
	private InventoryUIInfo itemDetails;

	// Use this for initialization
	void Start()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}

		Items = new List<ItemMeta>();
		weaponController = GetComponent<WeaponController>();
		consumableController = GetComponent<ConsumableController>();
		PlaceItem("ShitStick");
		PlaceItem("PotionDebug");
		PlaceItem("SpitwadLauncher");
	}

	public void PlaceItem(string info)
	{
		Debug.Log(ItemDatabase.Instance != null);
		//Items.Add(ItemDatabase.Instance.GetItem(info));
		//UIEventHandler.AddItem(Items.Last());
	}

	public void SetupItemDetails(ItemMeta item, UnityEngine.UI.Button selectedElement)
	{
		itemDetails.SetItem(item, selectedElement);
	}

	public void PerformEquipActon(ItemMeta weapon)
	{
		weaponController.Equip(weapon);
	}

	public void PerformConsumeAction(ItemMeta consumable)
	{
		consumableController.Consume(consumable);
	}
}
