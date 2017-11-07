using System.Collections.Generic;

public class ItemMeta
{
	public List<BaseStat> Stats { get; }
	public string Info { get; }
	public string MoreInfo { get; }
	public string Name { get; }
	public string ActionName { get; }
	public bool IsModifier { get; }

	public ItemMeta(List<BaseStat> stats, string info)
	{
		Stats = stats;
		Info = info;
	}

	public ItemMeta(List<BaseStat> stats, string info, string moreInfo, string actionName, string name, bool isModifier)
	{
		Stats = stats;
		Info = info;
		MoreInfo = moreInfo;
		ActionName = actionName;
		Name = name;
		IsModifier = isModifier;
	}
}
