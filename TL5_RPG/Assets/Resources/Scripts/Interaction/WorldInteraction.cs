using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
	private NavMeshAgent playerAgent;

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
            GameObject clickedObject = interactionInfo.collider.gameObject;

			if (clickedObject.tag == "Enemy")
			{
				Debug.Log("Approaching enemy.");
				clickedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
			}
			else if (clickedObject.tag == "Interactable")
			{
				clickedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
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
