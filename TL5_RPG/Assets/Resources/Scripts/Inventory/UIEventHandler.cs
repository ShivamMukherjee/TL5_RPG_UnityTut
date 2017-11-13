using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
	public delegate void ItemEventHandler(ItemMeta item);
	public static event ItemEventHandler OnAddItem;

	public static void AddItem(ItemMeta item)
	{
		Debug.Log($"Event exists? {OnAddItem != null} | Item: {item}");
		OnAddItem(item);
	}
}
