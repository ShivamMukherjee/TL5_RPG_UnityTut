using System.Collections.Generic;

public class BaseStat
{
	public List<StatBonus> BaseAdditives { get; private set; }
	public int BaseValue { get; private set; }
	public int FinalValue { get; private set; }
	public string Name { get; private set; }
	public string Description { get; private set; }

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
