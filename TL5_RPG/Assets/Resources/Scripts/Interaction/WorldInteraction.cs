using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
	NavMeshAgent playerAgent;

	void Start()
	{
		playerAgent = GetComponent<NavMeshAgent>();
	}

	void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactable = interactionInfo.collider.gameObject;

			if (interactable.tag == "Interactable")
			{
				interactable.GetComponent<Interactable>().MoveToInteraction(playerAgent);
			}
			else
			{
				playerAgent.stoppingDistance = 0f;
				playerAgent.destination = interactionInfo.point;
			}
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }
}
