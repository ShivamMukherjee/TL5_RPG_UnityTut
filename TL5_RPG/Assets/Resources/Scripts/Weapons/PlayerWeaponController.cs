using UnityEngine;
using System.IO;

public class PlayerWeaponController : MonoBehaviour
{
	[SerializeField] private GameObject hand;
	public GameObject EquippedWeapon { get; private set; }
	private CharacterStats stats;
	private Transform projectileSpawnPoint;

	void Start()
	{
		projectileSpawnPoint = transform.Find("ProjectileSpawnPoint");
		stats = GetComponent<CharacterStats>();
	}

	public void Equip(ItemMeta toEquip)
	{
		if (EquippedWeapon)
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
		EquippedWeapon.GetComponent<IProjectileLauncher>()?.SetProjectileSpawnPoint(projectileSpawnPoint);
		EquippedWeapon.transform.SetParent(hand.transform);
		stats.AddStatBonuses(toEquip.Stats);
		Debug.Log(EquippedWeapon);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Attack();
		}
		else if (Input.GetMouseButtonDown(2))
		{
			SpecialAttack();
		}
	}

	public void Attack()
	{
		EquippedWeapon?.GetComponent<IWeapon>().Attack();
	}

	public void SpecialAttack()
	{
		EquippedWeapon?.GetComponent<IWeapon>().SpecialAttack();
	}
}
