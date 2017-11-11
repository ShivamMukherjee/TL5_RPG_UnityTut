using UnityEngine;
using System.Collections.Generic;

public class BaseStat
{
	public string name;
	public int baseValue;
	public string description;
	public List<StatBonus> baseAdditives;

	[Newtonsoft.Json.JsonConstructor]
	public BaseStat(int value, string name, string description = "")
	{
		baseAdditives = new List<StatBonus>();
		baseValue = value;
		this.name = name;
		this.description = description;
	}

	public void AddBonus(StatBonus bonus)
	{
		baseAdditives.Add(bonus);
	}

	public void RemoveBonus(StatBonus bonus)
	{
		baseAdditives.Remove(baseAdditives.Find(x => x.Value == bonus.Value));
	}

	public int FinalValue()
	{
		int finalValue = 0;
		baseAdditives.ForEach(x => finalValue += x.Value);
		finalValue += baseValue;
		return finalValue;
	}
}
