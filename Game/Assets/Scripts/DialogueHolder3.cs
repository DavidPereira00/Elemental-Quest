using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder3 : MonoBehaviour {

	public int questNumber;
	public string dialogue;
	private DialogueManager dMAn;
	private QuestManager theQM;
	private QuestObject theQO;
	private Player P;
	private MeleePlayer MP;
	private NPC theNPC;
	public bool startQuest;
	public bool endQuest;
	public GameObject d4;

	public bool bulletOf = false;

	public string[] dialogueLines;

	// Use this for initialization
	void Start () {
		dMAn = FindObjectOfType <DialogueManager>();
		theQM = FindObjectOfType <QuestManager>();
		theQO = FindObjectOfType <QuestObject>();
		theNPC = FindObjectOfType<NPC>();
		P = FindObjectOfType<Player> ();
		MP = FindObjectOfType<MeleePlayer> ();
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
			if (Input.GetKeyUp (KeyCode.Z))
			{
				//dMAn.ShowBox (dialogue);
				if (!dMAn.dialogActive) {
					dMAn.dialogLines = dialogueLines;
					dMAn.currentLine = 0;
					//InitiateQuest ();
					dMAn.ShowDialogue();
					theQO.EndQuest ();
					UIManager._instance.CollectedCoin ();
					gameObject.SetActive (false);
					d4.SetActive (true);
					P.questsCompleted = P.questsCompleted + 1;
					MP.questsCompleted = MP.questsCompleted + 1;
					//gameObject.SetActive (true);
				}
			}
		}
	}
}
