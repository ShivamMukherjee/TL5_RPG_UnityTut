using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	public static DialogueSystem Instance { get; private set; }

	public GameObject panel;
	Button continueButton;
	Text text;
	Text nameText;
	int index;

	public List<string> lines = new List<string>();
	public string npcName;

	void Awake()
	{
		continueButton = panel.transform.Find("Continue").GetComponent<Button>();
		continueButton.onClick.AddListener(ContinueDialogue);

		text = panel.transform.Find("Text").GetComponent<Text>();
		nameText = panel.transform.Find("Name").GetComponentInChildren<Text>();
		panel.SetActive(false);

		if (Instance && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	public void AddNewDialogue(string[] lines, string npcName)
	{
		index = 0;
		this.lines = new List<string>(lines);
		this.npcName = npcName;
		Debug.Log(this.lines.Count);
		CreateDialogue();
	}
	
	public void CreateDialogue()
	{
		text.text = lines[index];
		nameText.text = npcName;
		panel.SetActive(true);
	}

	public void ContinueDialogue()
	{
		if (index < lines.Count - 1)
		{
			index++;
			text.text = lines[index];
		}
		else
		{
			panel.SetActive(false);
		}
	}
}
