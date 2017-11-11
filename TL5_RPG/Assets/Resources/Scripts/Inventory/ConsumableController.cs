using UnityEngine;
using System.IO;

public class ConsumableController : MonoBehaviour
{
	private CharacterStats stats;
	
	// Use this for initialization
	void Start()
	{
		stats = GetComponent<CharacterStats>();
	}

	public void Consume(ItemMeta item)
	{
		GameObject toSpawn = Instantiate(Resources.Load<GameObject>(Path.Combine("Consumables", item.info)));

		if (item.isModifier)
		{
			toSpawn.GetComponent<IConsumable>().Consume(stats);
		}
		else
		{
			toSpawn.GetComponent<IConsumable>().Consume();
		}
	}
}
