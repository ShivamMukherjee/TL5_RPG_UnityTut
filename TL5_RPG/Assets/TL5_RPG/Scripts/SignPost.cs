using UnityEngine;

public class SignPost : ActionTrigger
{
	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue(dialogue, alias);
		Debug.Log("Interacting with sign post.");
	}
}