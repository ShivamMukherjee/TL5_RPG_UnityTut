using System.Collections.Generic;
using UnityEngine;

public class EvilCube : Interactable, IEnemy
{
	// Incorporate later as BaseStats, maybe?
	[SerializeField] private float currentHealth, power, toughness, maxHealth;

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public void Attack()
	{
		throw new System.NotImplementedException();
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
