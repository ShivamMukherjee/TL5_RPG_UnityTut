using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	public static DialogueSystem Instance { get; private set; }
	public List<string> Lines { get; private set; }
	public string NpcName { get; private set; }

	[SerializeField] private GameObject panel;
	private Button continueButton;
	private Text text;
	private Text nameText;
	private int index;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}

		continueButton = panel.transform.Find("Continue").GetComponent<Button>();
		continueButton.onClick.AddListener(ContinueDialogue);

		text = panel.transform.Find("Text").GetComponent<Text>();
		nameText = panel.transform.Find("Name").GetComponentInChildren<Text>();
		panel.SetActive(false);
	}

	public void AddNewDialogue(string[] lines, string npcName)
	{
		index = 0;
		Lines = new List<string>(lines);
		NpcName = npcName;
		Debug.Log(Lines.Count);
		CreateDialogue();
	}
	
	public void CreateDialogue()
	{
		text.text = Lines[index];
		nameText.text = NpcName;
		panel.SetActive(true);
	}

	public void ContinueDialogue()
	{
		if (index < Lines.Count - 1)
		{
			index++;
			text.text = Lines[index];
		}
		else
		{
			panel.SetActive(false);
		}
	}
}
