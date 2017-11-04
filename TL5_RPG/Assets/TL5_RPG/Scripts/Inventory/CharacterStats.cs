using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	public List<BaseStat> stats = new List<BaseStat>();
	
	void Start()
	{
		stats.Add(new BaseStat(4, "Power", "Your power level."));
		stats.Add(new BaseStat(2, "Vitality", "Your current vitality."));
	}

	public void AddStatBonuses(List<BaseStat> stats)
	{
		foreach (var stat in stats)
		{
			this.stats.Find(x => x.Name == stat.Name).AddBonus(new StatBonus(stat.BaseValue));
		}
	}

	public void RemoveStatBonuses(List<BaseStat> stats)
	{
		foreach (var stat in stats)
		{
			this.stats.Find(x => x.Name == stat.Name).RemoveBonus(new StatBonus(stat.BaseValue));
		}
	}
}
