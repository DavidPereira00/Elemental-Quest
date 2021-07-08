using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolderNPCTalk : MonoBehaviour {

	public int questNumber;
	public string dialogue;
	private DialogueManager dMAn;
	private QuestManager theQM;
	private NPC theNPC;
	public bool startQuest;
	public bool endQuest;

	public bool bulletOf = false;

	public string[] dialogueLines;
	//public GameObject dzone;
	// Use this for initialization
	void Start () {
		dMAn = FindObjectOfType <DialogueManager>();
		theQM = FindObjectOfType <QuestManager>();
		theNPC = FindObjectOfType<NPC>();
	}

	// Update is called once per frame
	void Update () {

		/*if (dMAn.currentLine >= dMAn.dialogLines.Length) {
			InitiateQuest ();
		}*/

	}

	void OnTriggerStay2D (Collider2D other){ //if it collides with the player, shows dialogue
		if (other.gameObject.name == "Player") 
		{
			if (Input.GetKeyUp (KeyCode.Z)&&!theQM.questCompleted[questNumber])
			{
				//dMAn.ShowBox (dialogue);
				if (!dMAn.dialogActive) {
					dMAn.dialogLines = dialogueLines;
					dMAn.currentLine = 0;
					//InitiateQuest ();
					dMAn.ShowDialogue();
					theQM.talked = 1;
					//dzone.SetActive (true);
				}
			}
		}
	}
}

