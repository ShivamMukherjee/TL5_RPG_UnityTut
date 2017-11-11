using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] private RectTransform panel;
	[SerializeField] private RectTransform scrollViewContent;
	private InventoryUIItem itemContainer;
	private bool menuIsActive;
	private ItemMeta current;

	// Use this for initialization
	void Start()
	{
		itemContainer = Resources.Load<InventoryUIItem>("UI/ItemContainer");
		UIEventHandler.OnItemAddedToInventory += ItemAdded;
		panel.gameObject.SetActive(false);
	}

	void ItemAdded(ItemMeta item)
	{
		InventoryUIItem empty = Instantiate(itemContainer);
		empty.Item = item;
		empty.transform.SetParent(scrollViewContent);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
