using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

public class ItemMeta
{
	public enum ItemType
	{
		Weapon, Consumable, Quest
	}

	public string info;
	public string name;
	[JsonConverter(typeof(StringEnumConverter))] public ItemType type;
	public string moreInfo;
	public string action;
	public List<BaseStat> stats;
	public bool isModifier;

	public ItemMeta(ItemMeta item)
		: this(item.stats, item.info, item.name, item.type, item.moreInfo, item.action, item.isModifier) { }

	[JsonConstructor]
	public ItemMeta(List<BaseStat> stats, string info, string name, ItemType type, string moreInfo, string action, bool isModifier)
	{
		this.stats = stats;
		this.info = info;
		this.name = name;
		this.type = type;
		this.moreInfo = moreInfo;
		this.action = action;
		this.isModifier = isModifier;
	}
}
