using UnityEngine;

public class NPC : Interactable
{
	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue(dialogue, alias);
		Debug.Log("Interacting with NPC.");
	}
}
