using System;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
	private NavMeshAgent playerAgent;
	[SerializeField] protected string[] dialogue;
	[SerializeField] protected string alias;
	private bool hasInteracted;
	private bool isEnemy;

	void Start()
	{
		if (alias == "")
		{
			alias = name;
		}
	}

	public virtual void MoveToInteraction(NavMeshAgent playerAgent)
	{
		isEnemy = (this.gameObject.tag == "Enemy");
		hasInteracted = false;
		this.playerAgent = playerAgent;
		// FIXME: potential architectural fault
		playerAgent.stoppingDistance = 5f;
		playerAgent.destination = this.transform.position;
	}

	void Update()
	{
		if (!hasInteracted && playerAgent && !playerAgent.pathPending)
		{
			if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
			{
				if (!isEnemy)
				{
					Interact();
				}
				EnsureLookDirection();
				hasInteracted = true;
			}
		}
	}

	private void EnsureLookDirection()
	{
		playerAgent.updateRotation = false;
		Vector3 lookDirection = this.transform.position;
		lookDirection.y = playerAgent.transform.position.y;
		playerAgent.transform.LookAt(lookDirection);
		playerAgent.updateRotation = true;
	}

	public virtual void Interact()
	{
		Debug.Log("Interacting with base Interactable.");
	}
}
