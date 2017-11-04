using System.Collections.Generic;

public class ItemMeta
{
	public List<BaseStat> Stats { get; set; }
	public string Info { get; set; }

	public ItemMeta(List<BaseStat> stats, string info)
	{
		Stats = stats;
		Info = info;
	}
}
