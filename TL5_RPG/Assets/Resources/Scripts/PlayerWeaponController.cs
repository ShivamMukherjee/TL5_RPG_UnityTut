using UnityEngine;
using System.IO;

public class PlayerWeaponController : MonoBehaviour
{
	public GameObject hand;
	public GameObject EquippedWeapon { get; set; }
	CharacterStats stats;

	public void Equip(ItemMeta toEquip)
	{
		stats = GetComponent<CharacterStats>();
		if (EquippedWeapon != null)
		{
			stats.RemoveStatBonuses(EquippedWeapon.GetComponent<IWeapon>().Stats);
			Destroy(hand.transform.GetChild(0).gameObject);
		}
		EquippedWeapon = Instantiate(
			Resources.Load<GameObject>(Path.Combine("Weapons", toEquip.Info)),
			hand.transform.position,
			hand.transform.rotation
		);
		EquippedWeapon.GetComponent<IWeapon>().Stats = toEquip.Stats;
		EquippedWeapon.transform.SetParent(hand.transform);
		stats.AddStatBonuses(toEquip.Stats);
		Debug.Log(EquippedWeapon);
	}

	public void Attack()
	{
		EquippedWeapon.GetComponent<IWeapon>().Attack();
	}
}
