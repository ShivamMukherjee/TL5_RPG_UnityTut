using System.Collections.Generic;
using UnityEngine;

public class SpitwadLauncher : MonoBehaviour, IWeapon, IProjectileLauncher
{
	private Animator animator;
	public List<BaseStat> Stats { get; set; }
	public Transform ProjectileSpawnPoint { get; set; }
	private Spitwad spitwad;
	
	public void SetProjectileSpawnPoint(Transform point)
	{
		ProjectileSpawnPoint = point;
	}

	void Start()
	{
		spitwad = Resources.Load<Spitwad>("Weapons/Spitwad");
		animator = GetComponent<Animator>();
	}

	public void Attack()
	{
		animator.SetTrigger("Attack");
	}

	public void SpecialAttack()
	{
		animator.SetTrigger("Special_Attack");
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("Enemy"))
		{
			collider.GetComponent<IEnemy>().TakeDamage(Stats[0].CalculateStat());
			Debug.Log("Schtuck a(n) " + collider.name);
		}
	}

	public void LaunchProjectile()
	{
		Spitwad wad = Instantiate(spitwad, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
		wad.Direction = ProjectileSpawnPoint.forward;
	}
}
