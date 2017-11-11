using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
	public ItemMeta Item
	{
		get
		{
			return Item;
		}
		set
		{
			Item = value;
			Setup();
		}
	}

	void Setup()
	{
		transform.Find("Name").GetComponent<Text>().text = Item.name;
	}

	public void OnSelect()
	{
		InventoryManager.Instance.SetupItemDetails(Item, GetComponent<Button>());
	}
}
