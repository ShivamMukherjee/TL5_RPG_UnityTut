using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	public List<BaseStat> Stats { get; private set; }
	
	void Start()
	{
		Stats = new List<BaseStat>();
		Stats.Add(new BaseStat(4, "Power", "Your power level."));
		Stats.Add(new BaseStat(2, "Vitality", "Your current vitality."));
	}

	public void AddStatBonuses(List<BaseStat> stats)
	{
		foreach (var stat in stats)
		{
			Stats.Find(x => x.name == stat.name).AddBonus(new StatBonus(stat.baseValue));
		}
	}

	public void RemoveStatBonuses(List<BaseStat> stats)
	{
		foreach (var stat in stats)
		{
			Stats.Find(x => x.name == stat.name).RemoveBonus(new StatBonus(stat.baseValue));
		}
	}
}
