using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
	[HideInInspector]
	public NavMeshAgent playerAgent;
	public string[] dialogue;
	public string alias;

	private bool hasInteracted;

	public void Start()
	{
		if (alias.Equals(""))
		{
			alias = name;
		}
	}

	public virtual void MoveToInteraction(NavMeshAgent playerAgent)
	{
		hasInteracted = false;
		this.playerAgent = playerAgent;
		// FIXME: potential architectural fault
		playerAgent.stoppingDistance = 5f;
		playerAgent.destination = this.transform.position;
	}

	private void Update()
	{
		if (!hasInteracted && playerAgent && !playerAgent.pathPending)
		{
			if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
			{
				Interact();
				hasInteracted = true;
			}
		}
	}

	public virtual void Interact()
	{
		Debug.Log("Interacting with base Interactable.");
	}
}
