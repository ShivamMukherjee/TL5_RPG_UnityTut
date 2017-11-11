using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
	public delegate void ItemEventHandler(ItemMeta item);
	public static event ItemEventHandler OnItemAddedToInventory;

	public static void ItemAddedToInventory(ItemMeta item)
	{
		OnItemAddedToInventory(item);
	}
}
