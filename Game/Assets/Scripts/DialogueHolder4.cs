using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder4 : MonoBehaviour {

	public int questNumber;
	public string dialogue;
	private DialogueManager dMAn;
	private QuestManager theQM;
	private QuestObject theQO;
	private NPC theNPC;
	public bool startQuest;
	public bool endQuest;

	public bool bulletOf = false;

	public string[] dialogueLines;

	// Use this for initialization
	void Start () {
		dMAn = FindObjectOfType <DialogueManager>();
		theQM = FindObjectOfType <QuestManager>();
		theQO = FindObjectOfType <QuestObject>();
		theNPC = FindObjectOfType<NPC>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D (Collider2D other){ //if it collides with the player, shows dialogue
		if (other.gameObject.name == "Player") 
		{
			if (Input.GetKeyUp (KeyCode.Z))
			{
				//dMAn.ShowBox (dialogue);
				if (!dMAn.dialogActive) {
					dMAn.dialogLines = dialogueLines;
					dMAn.currentLine = 0;
					//InitiateQuest ();
					dMAn.ShowDialogue();
					//gameObject.SetActive (true);
				}
			}
		}
	}
}
