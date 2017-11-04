using System.Collections.Generic;

public class BaseStat
{
	public List<StatBonus> BaseAdditives { get; set; }

	public int BaseValue { get; set; }
	public int FinalValue { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	public BaseStat(int value, string name, string description)
	{
		BaseAdditives = new List<StatBonus>();
		BaseValue = value;
		Name = name;
		Description = description;
	}

	public void AddBonus(StatBonus bonus)
	{
		BaseAdditives.Add(bonus);
	}

	public void RemoveBonus(StatBonus bonus)
	{
		BaseAdditives.Remove(BaseAdditives.Find(x => x.Value == bonus.Value));
	}

	public int CalculateStat()
	{
		FinalValue = 0;
		BaseAdditives.ForEach(x => FinalValue += x.Value);
		FinalValue += BaseValue;
		return FinalValue;
	}
}
