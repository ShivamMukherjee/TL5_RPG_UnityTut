using UnityEngine;
using UnityEngine.UI;

public class InventoryUIInfo : MonoBehaviour
{
	private ItemMeta item;
	private Button selectedElement, useButton;
	private Text itemName, moreInfo, action;

	// Use this for initialization
	void Start()
	{
		itemName = transform.Find("Name").GetComponent<Text>();
		moreInfo = transform.Find("MoreInfo").GetComponent<Text>();
		useButton = transform.Find("Use").GetComponent<Button>();
		action = useButton.transform.Find("Text").GetComponent<Text>();
	}

	public void SetItem(ItemMeta item, Button selectedElement)
	{
		this.item = item;
		this.selectedElement = selectedElement;
		itemName.text = item.name;
		moreInfo.text = item.moreInfo;
		action.text = item.action;
		useButton.onClick.AddListener(OnUseItem);
	}

	private void OnUseItem()
	{
		switch (item.type)
		{
			case ItemMeta.Type.Consumable:
				InventoryManager.Instance.PerformConsumeAction(item);
				Destroy(selectedElement.gameObject);
				break;

			case ItemMeta.Type.Weapon:
				InventoryManager.Instance.PerformEquipActon(item);
				Destroy(selectedElement.gameObject);
				break;
		}
	}
}
