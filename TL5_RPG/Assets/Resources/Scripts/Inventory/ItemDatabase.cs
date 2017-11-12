using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
	public static ItemDatabase Instance { get; private set; }
	private List<ItemMeta> items;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
		BuildDatabase();
	}

	private void BuildDatabase()
	{
		items = JsonConvert.DeserializeObject<List<ItemMeta>>(Resources.Load<TextAsset>("json/Items").ToString());
	}

	public ItemMeta GetItem(string info)
	{
		foreach (ItemMeta item in items)
		{
			if (item.info == info)
			{
				return item;
			}
		}

		Debug.LogWarning($"Couldn't find item with info \"{info}\"");
		return null;
	}
}
