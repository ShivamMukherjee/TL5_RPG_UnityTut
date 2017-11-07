using System.Collections.Generic;
using UnityEngine;

public class ShitStick : MonoBehaviour, IWeapon
{
	private Animator animator;
	public List<BaseStat> Stats { get; set; }

	void Start()
	{
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
}
