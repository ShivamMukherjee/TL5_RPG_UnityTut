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
			Stats.Find(x => x.Name == stat.Name).AddBonus(new StatBonus(stat.BaseValue));
		}
	}

	public void RemoveStatBonuses(List<BaseStat> stats)
	{
		foreach (var stat in stats)
		{
			Stats.Find(x => x.Name == stat.Name).RemoveBonus(new StatBonus(stat.BaseValue));
		}
	}
}
